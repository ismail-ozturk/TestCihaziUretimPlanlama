using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Services
{
    public class PlanlamaService : IPlanlamaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IVardiyaService _vardiyaService;

        public PlanlamaService(ApplicationDbContext context, IVardiyaService vardiyaService)
        {
            _context = context;
            _vardiyaService = vardiyaService;
        }

        public async Task<bool> SiparisiPlanlaAsync(int siparisId)
        {
            try
            {
                var siparis = await _context.Siparisler
                    .Include(s => s.UretimGorevleri)
                        .ThenInclude(ug => ug.Gorev)
                            .ThenInclude(g => g.Departman)
                    .Include(s => s.UretimGorevleri)
                        .ThenInclude(ug => ug.OncuBagimliliklar)
                    .Include(s => s.UretimGorevleri)
                        .ThenInclude(ug => ug.ArdilBagimliliklar)
                    .FirstOrDefaultAsync(s => s.Id == siparisId);

                if (siparis == null || !siparis.UretimGorevleri.Any())
                    return false;

                var siralanmisGorevler = TopolojikSiralama(siparis.UretimGorevleri.ToList());
                var siparisPersonelAtamalari = new Dictionary<int, int>();

                foreach (var gorev in siralanmisGorevler)
                {
                    await GoreviPlanlaAsync(gorev, siparisPersonelAtamalari);
                }

                siparis.Durum = SiparisDurum.Planli;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SiparisiPlanlaAsync Hata: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> TumSiparisleriYenidenPlanlaAsync()
        {
            var planlanacakSiparisler = await _context.Siparisler
                .Where(s => s.Durum == SiparisDurum.Beklemede || s.Durum == SiparisDurum.Planli)
                .OrderBy(s => s.Oncelik)
                .ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();

            var temizlenecekGorevler = await _context.UretimGorevleri
                .Where(ug => ug.Durum == GorevDurum.Beklemede || ug.Durum == GorevDurum.Planli)
                .ToListAsync();

            foreach (var gorev in temizlenecekGorevler)
            {
                gorev.AtananPersonelId = null;
                gorev.PlanlananBaslangic = null;
                gorev.PlanlananBitis = null;
                gorev.Durum = GorevDurum.Beklemede;
            }

            await _context.SaveChangesAsync();

            foreach (var siparis in planlanacakSiparisler)
            {
                await SiparisiPlanlaAsync(siparis.Id);
            }

            return true;
        }

        public async Task<bool> GorevZamaniGuncelleAsync(int uretimGoreviId, DateTime yeniBaslangic)
        {
            try
            {
                var gorev = await _context.UretimGorevleri
                    .Include(ug => ug.AtananPersonel)
                    .Include(ug => ug.Siparis)
                    .FirstOrDefaultAsync(ug => ug.Id == uretimGoreviId);

                if (gorev == null || gorev.AtananPersonel == null)
                    return false;

                // BAŞLAMIŞ GÖREVLERİN ÖTELENMESİNİ ENGELLE
                if (gorev.Durum == GorevDurum.Basladi ||
                    gorev.Durum == GorevDurum.DevamEdiyor ||
                    gorev.Durum == GorevDurum.Tamamlandi)
                {
                    Console.WriteLine($"DEBUG: Görev {gorev.Id} başlamış durumda, ötelenemiyor. Durum: {gorev.Durum}");
                    return false; // Başlamış görevleri öteleme
                }

                // Eski başlangıç zamanını referans al
                var eskiBaslangic = gorev.PlanlananBaslangic.Value;

                var (yeniBaslangicZamani, yeniBitisZamani) = _vardiyaService.GorevZamanlariniHesapla(
                    gorev.AtananPersonel, yeniBaslangic, gorev.Sure, yeniBaslangic);

                gorev.PlanlananBaslangic = yeniBaslangicZamani;
                gorev.PlanlananBitis = yeniBitisZamani;

                // YENİ: Referans tarihten sonraki tüm görevleri sipariş sırasıyla yeniden planla
                await ReferansTarihSonrasiTumGorevleriYenidenPlanlaAsync(eskiBaslangic);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GorevZamaniGuncelleAsync Hata: {ex.Message}");
                return false;
            }
        }
        private async Task ReferansTarihSonrasiTumGorevleriYenidenPlanlaAsync(DateTime referansTarih)
        {
            Console.WriteLine($"DEBUG: {referansTarih} sonrası tüm görevler yeniden planlanıyor...");

            // 1. Referans tarihten sonraki TÜM görevleri bul
            var etkilenenGorevler = await _context.UretimGorevleri
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev).ThenInclude(g => g.Departman)
                .Include(ug => ug.AtananPersonel)
                .Include(ug => ug.OncuBagimliliklar)
                .Include(ug => ug.ArdilBagimliliklar)
                .Where(ug => !ug.IsDeleted &&
                            ug.Durum != GorevDurum.Tamamlandi &&
                            ug.PlanlananBaslangic.HasValue &&
                            ug.PlanlananBaslangic > referansTarih)
                .ToListAsync();

            Console.WriteLine($"DEBUG: {etkilenenGorevler.Count} görev etkilendi");

            if (!etkilenenGorevler.Any()) return;

            // 2. Mevcut personel atamalarını sakla
            var mevcutAtamalar = etkilenenGorevler
                .Where(g => g.AtananPersonelId.HasValue)
                .ToDictionary(g => g.Id, g => g.AtananPersonelId.Value);

            // 3. Etkilenen görevleri sıfırla
            foreach (var gorev in etkilenenGorevler)
            {
                gorev.AtananPersonelId = null;
                gorev.PlanlananBaslangic = null;
                gorev.PlanlananBitis = null;
                gorev.Durum = GorevDurum.Beklemede;
            }
            await _context.SaveChangesAsync();

            // 4. Etkilenen siparişleri sipariş sırasına göre al
            var etkilenenSiparisIds = etkilenenGorevler.Select(g => g.SiparisId).Distinct().ToList();
            var etkilenenSiparisler = await _context.Siparisler
                .Where(s => etkilenenSiparisIds.Contains(s.Id))
                .OrderBy(s => s.Oncelik)
                .ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();

            // 5. SIRALAMA: Her siparişi TEK TEK sıralı olarak planla
            foreach (var siparis in etkilenenSiparisler)
            {
                Console.WriteLine($"DEBUG: {siparis.UretimNumarasi} planlanıyor...");

                var siparisGorevleri = etkilenenGorevler
                    .Where(g => g.SiparisId == siparis.Id)
                    .ToList();

                var siralanmisGorevler = TopolojikSiralama(siparisGorevleri);
                var siparisPersonelAtamalari = new Dictionary<int, int>();

                // Mevcut atamaları koru
                foreach (var gorev in siralanmisGorevler)
                {
                    if (mevcutAtamalar.ContainsKey(gorev.Id))
                    {
                        var departmanId = gorev.Gorev.DepartmanId;
                        var personelId = mevcutAtamalar[gorev.Id];

                        if (!siparisPersonelAtamalari.ContainsKey(departmanId))
                        {
                            siparisPersonelAtamalari[departmanId] = personelId;
                        }
                    }
                }

                // Her görevi sıralı planla
                foreach (var gorev in siralanmisGorevler)
                {
                    await GoreviSiraliPlanlaAsync(gorev, siparisPersonelAtamalari);
                }

                siparis.Durum = SiparisDurum.Planli;
                await _context.SaveChangesAsync();
            }
        }

        private async Task SiparisiMevcutAtamalarlaYenidenPlanlaAsync(int siparisId, Dictionary<int, int> mevcutAtamalar)
        {
            var siparis = await _context.Siparisler
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.Gorev)
                        .ThenInclude(g => g.Departman)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.OncuBagimliliklar)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.ArdilBagimliliklar)
                .FirstOrDefaultAsync(s => s.Id == siparisId);

            if (siparis == null) return;

            // Sadece beklemedeki görevleri al (sıfırlanmış olanlar)
            var bekleyenGorevler = siparis.UretimGorevleri
                .Where(g => g.Durum == GorevDurum.Beklemede)
                .ToList();

            if (!bekleyenGorevler.Any()) return;

            var siralanmisGorevler = TopolojikSiralama(bekleyenGorevler);
            var siparisPersonelAtamalari = new Dictionary<int, int>(); // DepartmanId -> PersonelId

            // Mevcut atamaları sipariş personel atamalarına aktar
            foreach (var gorev in siralanmisGorevler)
            {
                if (mevcutAtamalar.ContainsKey(gorev.Id))
                {
                    var departmanId = gorev.Gorev.DepartmanId;
                    var personelId = mevcutAtamalar[gorev.Id];

                    if (!siparisPersonelAtamalari.ContainsKey(departmanId))
                    {
                        siparisPersonelAtamalari[departmanId] = personelId;
                    }
                }
            }

            // Her görevi mevcut GoreviSiraliPlanlaAsync metodu ile planla
            foreach (var gorev in siralanmisGorevler)
            {
                await GoreviSiraliPlanlaAsync(gorev, siparisPersonelAtamalari);
            }

            siparis.Durum = SiparisDurum.Planli;
            Console.WriteLine($"DEBUG: {siparis.UretimNumarasi} planlandı");
        }
        public async Task<IEnumerable<UretimGorevi>> GetPersonelPlaniniAsync(int personelId, DateTime baslangic, DateTime bitis)
        {
            return await _context.UretimGorevleri
                .Include(ug => ug.Siparis)
                .Include(ug => ug.Gorev)
                .Where(ug => ug.AtananPersonelId == personelId)
                .Where(ug => ug.PlanlananBaslangic <= bitis && ug.PlanlananBitis >= baslangic)
                .OrderBy(ug => ug.PlanlananBaslangic)
                .ToListAsync();
        }

        public async Task<double> PersonelIsYukuHesaplaAsync(int personelId, DateTime baslangic, DateTime bitis)
        {
            var personel = await _context.Personeller.FindAsync(personelId);
            if (personel == null) return 0;

            var atanmisGorevler = await GetPersonelPlaniniAsync(personelId, baslangic, bitis);
            var toplamGorevSuresi = atanmisGorevler.Sum(g => g.Sure);

            var toplamCalismaSaati = 0.0;
            var tarih = baslangic.Date;

            while (tarih <= bitis.Date)
            {
                var sonrakiCalismaGunu = _vardiyaService.SonrakiCalismaGunuBul(personel, tarih);
                if (sonrakiCalismaGunu > bitis.Date) break;

                var gunlukSaat = _vardiyaService.GunlukCalismaSaatiHesapla(personel, sonrakiCalismaGunu);
                toplamCalismaSaati += gunlukSaat.TotalHours;

                tarih = sonrakiCalismaGunu.AddDays(1);
            }

            return toplamCalismaSaati > 0 ? (toplamGorevSuresi / toplamCalismaSaati) * 100 : 0;
        }

        private async Task KaydirmaSonrasiYenidenPlanlaAsync(UretimGorevi kaydirilanGorev)
        {
            await KendiSiparisindekiSonrakiGorevleriPlanlaAsync(kaydirilanGorev);
            await DigerSiparislerdeCakisanGorevleriPlanlaAsync(kaydirilanGorev);
        }

        private async Task KendiSiparisindekiSonrakiGorevleriPlanlaAsync(UretimGorevi kaydirilanGorev)
        {
            var sonrakiGorevler = await _context.UretimGorevleri
                .Include(ug => ug.AtananPersonel)
                .Include(ug => ug.Gorev).ThenInclude(g => g.Departman)
                .Include(ug => ug.OncuBagimliliklar).Include(ug => ug.ArdilBagimliliklar)
                .Where(ug => ug.SiparisId == kaydirilanGorev.SiparisId && ug.Id != kaydirilanGorev.Id && !ug.IsDeleted && ug.Durum != GorevDurum.Tamamlandi)
                .ToListAsync();

            var siralanmisGorevler = TopolojikSiralama(sonrakiGorevler);
            var siparisPersonelAtamalari = new Dictionary<int, int>();

            foreach (var gorev in siralanmisGorevler.Where(g => g.AtananPersonelId.HasValue))
            {
                var departmanId = gorev.Gorev.DepartmanId;
                if (!siparisPersonelAtamalari.ContainsKey(departmanId))
                {
                    siparisPersonelAtamalari[departmanId] = gorev.AtananPersonelId.Value;
                }
            }

            foreach (var gorev in siralanmisGorevler)
            {
                await GoreviSiraliPlanlaAsync(gorev, siparisPersonelAtamalari);
            }
        }

        private async Task DigerSiparislerdeCakisanGorevleriPlanlaAsync(UretimGorevi kaydirilanGorev)
        {
            var sonrakiSiparisler = await _context.Siparisler
                .Where(s => s.Id != kaydirilanGorev.SiparisId && !s.IsDeleted)
                .OrderBy(s => s.Oncelik).ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();

            foreach (var siparis in sonrakiSiparisler)
            {
                if (await SipariseCakismaKontrolEtAsync(siparis.Id, kaydirilanGorev))
                {
                    await SiparisiYenidenPlanlaAsync(siparis.Id);
                }
            }
        }

        private async Task<bool> SipariseCakismaKontrolEtAsync(int siparisId, UretimGorevi kaydirilanGorev)
        {
            return await _context.UretimGorevleri
                .AnyAsync(ug => ug.SiparisId == siparisId &&
                               ug.AtananPersonelId == kaydirilanGorev.AtananPersonelId && !ug.IsDeleted &&
                               ug.Durum != GorevDurum.Tamamlandi && ug.PlanlananBaslangic.HasValue &&
                               ug.PlanlananBitis.HasValue &&
                               ug.PlanlananBaslangic < kaydirilanGorev.PlanlananBitis &&
                               ug.PlanlananBitis > kaydirilanGorev.PlanlananBaslangic);
        }

        private async Task SiparisiYenidenPlanlaAsync(int siparisId)
        {
            var siparis = await _context.Siparisler
                .Include(s => s.UretimGorevleri).ThenInclude(ug => ug.Gorev).ThenInclude(g => g.Departman)
                .Include(s => s.UretimGorevleri).ThenInclude(ug => ug.OncuBagimliliklar)
                .Include(s => s.UretimGorevleri).ThenInclude(ug => ug.ArdilBagimliliklar)
                .FirstOrDefaultAsync(s => s.Id == siparisId);

            if (siparis == null) return;

            var gorevler = siparis.UretimGorevleri.Where(g => !g.IsDeleted && g.Durum != GorevDurum.Tamamlandi).ToList();
            var siralanmisGorevler = TopolojikSiralama(gorevler);
            var siparisPersonelAtamalari = new Dictionary<int, int>();

            foreach (var gorev in siralanmisGorevler.Where(g => g.AtananPersonelId.HasValue))
            {
                var departmanId = gorev.Gorev.DepartmanId;
                if (!siparisPersonelAtamalari.ContainsKey(departmanId))
                {
                    siparisPersonelAtamalari[departmanId] = gorev.AtananPersonelId.Value;
                }
            }

            foreach (var gorev in siralanmisGorevler)
            {
                await GoreviSiraliPlanlaAsync(gorev, siparisPersonelAtamalari);
            }
        }

        private async Task GoreviSiraliPlanlaAsync(UretimGorevi gorev, Dictionary<int, int> siparisPersonelAtamalari)
        {
            Personel personel = null;
            if (gorev.AtananPersonelId.HasValue)
            {
                personel = await _context.Personeller.FindAsync(gorev.AtananPersonelId.Value);
            }
            else
            {
                var departmanId = gorev.Gorev.DepartmanId;
                if (siparisPersonelAtamalari.ContainsKey(departmanId))
                {
                    personel = await _context.Personeller.FindAsync(siparisPersonelAtamalari[departmanId]);
                }
                else
                {
                    personel = await DepartmanIcinEnUygunPersoneliBul(gorev);
                    if (personel != null)
                    {
                        siparisPersonelAtamalari[departmanId] = personel.Id;
                    }
                }
            }

            if (personel == null) return;

            var enErkenBaslangic = await EnErkenBaslangicHesaplaAsync(gorev);
            var sonrakiMusaitZaman = await PersonelSonrakiSiraliMusaitZamaniBulAsync(personel, enErkenBaslangic);
            var gercekBaslangic = sonrakiMusaitZaman > enErkenBaslangic ? sonrakiMusaitZaman : enErkenBaslangic;
            var (baslangic, bitis) = _vardiyaService.GorevZamanlariniHesapla(personel, gercekBaslangic, gorev.Sure, gercekBaslangic);

            gorev.AtananPersonelId = personel.Id;
            gorev.PlanlananBaslangic = baslangic;
            gorev.PlanlananBitis = bitis;
            gorev.Durum = GorevDurum.Planli;
        }

        private async Task<DateTime> PersonelSonrakiSiraliMusaitZamaniBulAsync(Personel personel, DateTime baslangicTarihi)
        {
            var sonGorev = await _context.UretimGorevleri
                .Where(ug => ug.AtananPersonelId == personel.Id && !ug.IsDeleted &&
                               ug.Durum != GorevDurum.Tamamlandi && ug.PlanlananBitis.HasValue)
                .OrderByDescending(ug => ug.PlanlananBitis).FirstOrDefaultAsync();

            DateTime enErkenMusaitZaman = sonGorev?.PlanlananBitis.Value ?? baslangicTarihi;
            var gercekBaslangic = enErkenMusaitZaman > baslangicTarihi ? enErkenMusaitZaman : baslangicTarihi;
            return _vardiyaService.SonrakiUygunCalismaZamaniBul(personel, gercekBaslangic);
        }

        private async Task GoreviPlanlaAsync(UretimGorevi gorev, Dictionary<int, int> siparisPersonelAtamalari)
        {
            if (gorev.Durum == GorevDurum.Basladi ||
       gorev.Durum == GorevDurum.DevamEdiyor ||
       gorev.Durum == GorevDurum.Tamamlandi)
            {
                Console.WriteLine($"DEBUG: Görev {gorev.Id} başlamış durumda, planlamayı atla");
                return; // Başlamış görevleri yeniden planlama
            }
            var departmanId = gorev.Gorev.DepartmanId;
            var siparis = await _context.Siparisler
     .Include(s => s.ZorunluPmdPersonel)
     .Include(s => s.ZorunluCncPersonel)
     .Include(s => s.ZorunluTeknikPersonel)
     .FirstOrDefaultAsync(s => s.Id == gorev.SiparisId);

            var zorunluPersonel = await ZorunluPersonelKontrolEtAsync(siparis, departmanId, gorev.GorevId);

            if (zorunluPersonel != null)
            {
                siparisPersonelAtamalari[departmanId] = zorunluPersonel.Id;
                await GoreviPersoneleAtaAsync(gorev, zorunluPersonel);
                Console.WriteLine($"DEBUG: Zorunlu personel atandı - {zorunluPersonel.Ad} {zorunluPersonel.Soyad}");
                return;
            }

            if (siparisPersonelAtamalari.ContainsKey(departmanId))
            {
                var oncekiPersonelId = siparisPersonelAtamalari[departmanId];
                var oncekiPersonel = await _context.Personeller.FindAsync(oncekiPersonelId);

                if (oncekiPersonel?.Aktif == true && await PersonelGorevYetkinMi(oncekiPersonelId, gorev.GorevId))
                {
                    await GoreviPersoneleAtaAsync(gorev, oncekiPersonel);
                    return;
                }
            }

            var uygunPersonel = await DepartmanIcinEnUygunPersoneliBul(gorev);
            if (uygunPersonel != null)
            {
                siparisPersonelAtamalari[departmanId] = uygunPersonel.Id;
                await GoreviPersoneleAtaAsync(gorev, uygunPersonel);
            }
            else
            {
                throw new InvalidOperationException($"Görev {gorev.Id} için uygun personel bulunamadı.");
            }
        }
        private async Task<Personel> ZorunluPersonelKontrolEtAsync(Siparis siparis, int departmanId, int gorevId)
        {
            int? zorunluPersonelId = null;

            var departman = await _context.Departmanlar.FindAsync(departmanId);

            switch (departman?.Ad?.ToUpper())
            {
                case "PMD":
                    zorunluPersonelId = siparis.ZorunluPmdPersonelId;
                    break;
                case "CNC":
                    zorunluPersonelId = siparis.ZorunluCncPersonelId;
                    break;
                case "TEKNİK":
                    zorunluPersonelId = siparis.ZorunluTeknikPersonelId;
                    break;
            }

            if (!zorunluPersonelId.HasValue) return null;

            var zorunluPersonel = await _context.Personeller.FindAsync(zorunluPersonelId.Value);

            if (zorunluPersonel?.Aktif == true && await PersonelGorevYetkinMi(zorunluPersonelId.Value, gorevId))
            {
                return zorunluPersonel;
            }

            return null;
        }
        private async Task<Personel> DepartmanIcinEnUygunPersoneliBul(UretimGorevi gorev)
        {
            var departmanId = gorev.Gorev.DepartmanId;
            var yetkinPersoneller = await YetkinPersonelleriGetirAsync(gorev.GorevId);

            if (!yetkinPersoneller.Any())
            {
                yetkinPersoneller = await _context.Personeller
                    .Where(p => p.DepartmanId == departmanId && p.Aktif && !p.IsDeleted).ToListAsync();
            }
            if (!yetkinPersoneller.Any()) return null;

            var enErkenBaslangic = await EnErkenBaslangicHesaplaAsync(gorev);
            var personelAnalizleri = new List<(Personel personel, double puan)>();

            foreach (var personel in yetkinPersoneller)
            {
                personelAnalizleri.Add((personel, await PersonelUygunlukPuaniHesaplaAsync(personel, gorev, enErkenBaslangic)));
            }
            return personelAnalizleri.OrderBy(p => p.puan).FirstOrDefault().personel;
        }

        private async Task<double> PersonelUygunlukPuaniHesaplaAsync(Personel personel, UretimGorevi gorev, DateTime enErkenBaslangic)
        {
            double puan = 0;
            var mevcutGorevler = await _context.UretimGorevleri
                .Where(ug => ug.AtananPersonelId == personel.Id && !ug.IsDeleted && ug.Durum != GorevDurum.Tamamlandi && ug.PlanlananBaslangic >= DateTime.UtcNow).ToListAsync();
            puan += mevcutGorevler.Sum(g => g.Sure) * 0.4;
            var sonrakiMusaitZaman = await PersonelSonrakiSiraliMusaitZamaniBulAsync(personel, enErkenBaslangic);
            puan += Math.Max(0, (sonrakiMusaitZaman - enErkenBaslangic).TotalDays) * 10;
            if (!await PersonelGorevYetkinMi(personel.Id, gorev.GorevId)) puan += 50;
            var sonAtama = await _context.UretimGorevleri.Where(ug => ug.AtananPersonelId == personel.Id && !ug.IsDeleted).OrderByDescending(ug => ug.CreatedDate).FirstOrDefaultAsync();
            if (sonAtama != null) puan -= Math.Min(24, (DateTime.UtcNow - sonAtama.CreatedDate).TotalHours);
            return puan;
        }

        private async Task<List<Personel>> YetkinPersonelleriGetirAsync(int gorevId)
        {
            return await _context.PersonelGorevYetkinlikleri
                .Include(y => y.Personel).ThenInclude(p => p.Departman)
                .Where(y => y.GorevId == gorevId && !y.IsDeleted && y.Personel.Aktif).Select(y => y.Personel).ToListAsync();
        }

        private async Task<DateTime> EnErkenBaslangicHesaplaAsync(UretimGorevi gorev)
        {
            var siparis = await _context.Siparisler.FindAsync(gorev.SiparisId);
            var enErkenBaslangic = siparis.IstenilenBaslangicTarihi;
            var oncuBagimliliklar = await _context.UretimGorevBagimliliklari
                .Include(b => b.OncuGorev).Where(b => b.ArdilUretimGoreviId == gorev.Id && !b.IsDeleted).ToListAsync();
            foreach (var bagimlilik in oncuBagimliliklar.Where(b => b.OncuGorev.PlanlananBitis.HasValue))
            {
                var oncuBitis = bagimlilik.OncuGorev.PlanlananBitis.Value.AddDays(bagimlilik.GecikmeGunu);
                if (oncuBitis > enErkenBaslangic) enErkenBaslangic = oncuBitis;
            }
            return enErkenBaslangic;
        }

        private async Task GoreviPersoneleAtaAsync(UretimGorevi gorev, Personel personel)
        {
            var enErkenBaslangic = await EnErkenBaslangicHesaplaAsync(gorev);
            var sonrakiMusaitZaman = await PersonelSonrakiSiraliMusaitZamaniBulAsync(personel, enErkenBaslangic);
            var gercekBaslangic = sonrakiMusaitZaman > enErkenBaslangic ? sonrakiMusaitZaman : enErkenBaslangic;
            var (baslangic, bitis) = _vardiyaService.GorevZamanlariniHesapla(personel, gercekBaslangic, gorev.Sure, gercekBaslangic);
            gorev.AtananPersonelId = personel.Id;
            gorev.PlanlananBaslangic = baslangic;
            gorev.PlanlananBitis = bitis;
            gorev.Durum = GorevDurum.Planli;
        }

        private async Task<bool> PersonelGorevYetkinMi(int personelId, int gorevId)
        {
            return await _context.PersonelGorevYetkinlikleri
                .AnyAsync(y => y.PersonelId == personelId && y.GorevId == gorevId && !y.IsDeleted);
        }

        private List<UretimGorevi> TopolojikSiralama(List<UretimGorevi> gorevler)
        {
            var siralanmis = new List<UretimGorevi>();
            var ziyaretEdilen = new HashSet<int>();
            var geciciZiyaret = new HashSet<int>();
            var gorevDict = gorevler.ToDictionary(g => g.Id);
            var ardillar = new Dictionary<int, List<UretimGorevi>>();

            foreach (var gorev in gorevler)
            {
                ardillar[gorev.Id] = new List<UretimGorevi>();
            }

            foreach (var gorev in gorevler)
            {
                foreach (var oncu in gorev.OncuBagimliliklar)
                {
                    if (gorevDict.ContainsKey(oncu.OncuUretimGoreviId))
                    {
                        if (!ardillar.ContainsKey(oncu.OncuUretimGoreviId))
                        {
                            ardillar[oncu.OncuUretimGoreviId] = new List<UretimGorevi>();
                        }
                        ardillar[oncu.OncuUretimGoreviId].Add(gorev);
                    }
                }
            }

            foreach (var gorev in gorevler)
            {
                if (!ziyaretEdilen.Contains(gorev.Id))
                {
                    TopolojikSiralamaYardimci(gorev, siralanmis, ziyaretEdilen, geciciZiyaret, ardillar);
                }
            }

            return siralanmis;
        }

        private void TopolojikSiralamaYardimci(UretimGorevi gorev, List<UretimGorevi> siralanmis, HashSet<int> ziyaretEdilen, HashSet<int> geciciZiyaret, Dictionary<int, List<UretimGorevi>> ardillar)
        {
            if (geciciZiyaret.Contains(gorev.Id)) throw new InvalidOperationException("Döngüsel bağımlılık tespit edildi!");
            if (ziyaretEdilen.Contains(gorev.Id)) return;

            geciciZiyaret.Add(gorev.Id);
            if (ardillar.ContainsKey(gorev.Id))
            {
                foreach (var ardil in ardillar[gorev.Id])
                {
                    var ardilGorev = _context.UretimGorevleri.Find(ardil.Id);
                    if (ardilGorev != null && !ziyaretEdilen.Contains(ardilGorev.Id))
                    {
                        TopolojikSiralamaYardimci(ardilGorev, siralanmis, ziyaretEdilen, geciciZiyaret, ardillar);
                    }
                }
            }
            geciciZiyaret.Remove(gorev.Id);
            ziyaretEdilen.Add(gorev.Id);
            siralanmis.Insert(0, gorev);
        }
    }
}

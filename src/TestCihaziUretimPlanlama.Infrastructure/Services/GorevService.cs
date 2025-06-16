using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Services
{
    public class GorevService : IGorevService
    {
        private readonly ApplicationDbContext _context;

        public GorevService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UretimGorevi>> SablondanUretimGorevleriOlusturAsync(int siparisId, int kategoriId)
        {
            var sablonGorevler = await _context.KategoriGorevSablonlari
                .Include(s => s.Gorev)
                .Where(s => s.KategoriId == kategoriId)
                .OrderBy(s => s.Sira)
                .ToListAsync();

            var uretimGorevleri = new List<UretimGorevi>();

            foreach (var sablon in sablonGorevler)
            {
                var uretimGorevi = new UretimGorevi
                {
                    SiparisId = siparisId,
                    GorevId = sablon.GorevId,
                    Sure = sablon.OzelSure ?? sablon.Gorev.Sure,
                     Durum = GorevDurum.Beklemede,
                    Notlar = string.Empty // Varsayılan boş notlar
                };

                _context.UretimGorevleri.Add(uretimGorevi);
                uretimGorevleri.Add(uretimGorevi);
            }

            await _context.SaveChangesAsync();

            // Bağımlılıkları kopyala
            await SablonBagimliliklariniKopyalaAsync(siparisId, kategoriId, uretimGorevleri);

            return uretimGorevleri;
        }

        public async Task<IEnumerable<UretimGorevi>> ManuelUretimGorevleriOlusturAsync(int siparisId, List<GorevCreateModel> gorevler)
        {
            var uretimGorevleri = new List<UretimGorevi>();

            foreach (var gorevModel in gorevler)
            {
                var gorev = await _context.Gorevler.FindAsync(gorevModel.GorevId);

                var uretimGorevi = new UretimGorevi
                {
                    SiparisId = siparisId,
                    GorevId = gorevModel.GorevId,
                    Sure = gorevModel.OzelSure ?? gorev.Sure,
                    Notlar = gorevModel.OzelAciklama
                };

                _context.UretimGorevleri.Add(uretimGorevi);
                uretimGorevleri.Add(uretimGorevi);
            }

            await _context.SaveChangesAsync();

            // Manuel bağımlılıkları ekle
            await ManuelBagimliliklarEkleAsync(siparisId, gorevler, uretimGorevleri);

            return uretimGorevleri;
        }

        public async Task<bool> GorevBagimlilikKontrolAsync(int oncuGorevId, int ardilGorevId)
        {
            // Döngüsel bağımlılık kontrolü
            return !await DongusalBagimlilikVarMiAsync(oncuGorevId, ardilGorevId);
        }

        public async Task<IEnumerable<UretimGorevi>> KritikYoluHesaplaAsync(int siparisId)
        {
            var uretimGorevleri = await _context.UretimGorevleri
                .Include(ug => ug.OncuBagimliliklar)
                .Include(ug => ug.ArdilBagimliliklar)
                .Where(ug => ug.SiparisId == siparisId)
                .ToListAsync();

            // Critical Path Method (CPM) algoritması
            var kritikYol = new List<UretimGorevi>();

            // En uzun sürecek yolu bul
            var enUzunSure = 0;
            UretimGorevi sonGorev = null;

            foreach (var gorev in uretimGorevleri.Where(g => !g.ArdilBagimliliklar.Any()))
            {
                var toplamSure = ToplamSureHesapla(gorev, uretimGorevleri);
                if (toplamSure > enUzunSure)
                {
                    enUzunSure = toplamSure;
                    sonGorev = gorev;
                }
            }

            // Kritik yolu oluştur
            if (sonGorev != null)
            {
                KritikYoluOlustur(sonGorev, kritikYol, uretimGorevleri);
            }

            return kritikYol;
        }

        private async Task SablonBagimliliklariniKopyalaAsync(int siparisId, int kategoriId, List<UretimGorevi> uretimGorevleri)
        {
            var sablonBagimliliklar = await _context.KategoriGorevBagimliliklari
                .Include(b => b.OncuGorev)
                .Include(b => b.ArdilGorev)
                .Where(b => b.OncuGorev.KategoriId == kategoriId)
                .ToListAsync();

            foreach (var sablonBagimlilik in sablonBagimliliklar)
            {
                var oncuUretimGorevi = uretimGorevleri.FirstOrDefault(ug => ug.GorevId == sablonBagimlilik.OncuGorev.GorevId);
                var ardilUretimGorevi = uretimGorevleri.FirstOrDefault(ug => ug.GorevId == sablonBagimlilik.ArdilGorev.GorevId);

                if (oncuUretimGorevi != null && ardilUretimGorevi != null)
                {
                    var uretimBagimlilik = new UretimGorevBagimlilik
                    {
                        OncuUretimGoreviId = oncuUretimGorevi.Id,
                        ArdilUretimGoreviId = ardilUretimGorevi.Id,
                        BagimlilikTipi = sablonBagimlilik.BagimlilikTipi,
                        GecikmeGunu = sablonBagimlilik.GecikmeGunu
                    };

                    _context.UretimGorevBagimliliklari.Add(uretimBagimlilik);
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task ManuelBagimliliklarEkleAsync(int siparisId, List<GorevCreateModel> gorevler, List<UretimGorevi> uretimGorevleri)
        {
            foreach (var gorevModel in gorevler)
            {
                var ardilUretimGorevi = uretimGorevleri.FirstOrDefault(ug => ug.GorevId == gorevModel.GorevId);

                foreach (var oncuGorevId in gorevModel.OncuGorevIds)
                {
                    var oncuUretimGorevi = uretimGorevleri.FirstOrDefault(ug => ug.GorevId == oncuGorevId);

                    if (oncuUretimGorevi != null && ardilUretimGorevi != null)
                    {
                        var bagimlilik = new UretimGorevBagimlilik
                        {
                            OncuUretimGoreviId = oncuUretimGorevi.Id,
                            ArdilUretimGoreviId = ardilUretimGorevi.Id
                        };

                        _context.UretimGorevBagimliliklari.Add(bagimlilik);
                    }
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task<bool> DongusalBagimlilikVarMiAsync(int oncuGorevId, int ardilGorevId)
        {
            // Basit döngü kontrolü - daha gelişmiş algoritma gerekebilir
            var bagimliliklar = await _context.UretimGorevBagimliliklari.ToListAsync();

            return BagimlilikZinciriKontrol(ardilGorevId, oncuGorevId, bagimliliklar, new HashSet<int>());
        }

        private bool BagimlilikZinciriKontrol(int baslangicGorev, int hedefGorev, List<UretimGorevBagimlilik> bagimliliklar, HashSet<int> ziyaretEdilen)
        {
            if (ziyaretEdilen.Contains(baslangicGorev))
                return false;

            ziyaretEdilen.Add(baslangicGorev);

            var ardilGorevler = bagimliliklar
                .Where(b => b.OncuUretimGoreviId == baslangicGorev)
                .Select(b => b.ArdilUretimGoreviId);

            foreach (var ardilGorev in ardilGorevler)
            {
                if (ardilGorev == hedefGorev)
                    return true;

                if (BagimlilikZinciriKontrol(ardilGorev, hedefGorev, bagimliliklar, ziyaretEdilen))
                    return true;
            }

            return false;
        }

        private int ToplamSureHesapla(UretimGorevi gorev, List<UretimGorevi> tumGorevler)
        {
            var toplamSure = gorev.Sure;

            foreach (var oncuBagimlilik in gorev.OncuBagimliliklar)
            {
                var oncuGorev = tumGorevler.FirstOrDefault(g => g.Id == oncuBagimlilik.OncuUretimGoreviId);
                if (oncuGorev != null)
                {
                    toplamSure += ToplamSureHesapla(oncuGorev, tumGorevler);
                }
            }

            return toplamSure;
        }

        private void KritikYoluOlustur(UretimGorevi gorev, List<UretimGorevi> kritikYol, List<UretimGorevi> tumGorevler)
        {
            kritikYol.Insert(0, gorev);

            var enUzunOncuGorev = gorev.OncuBagimliliklar
                .Select(b => tumGorevler.FirstOrDefault(g => g.Id == b.OncuUretimGoreviId))
                .Where(g => g != null)
                .OrderByDescending(g => ToplamSureHesapla(g, tumGorevler))
                .FirstOrDefault();

            if (enUzunOncuGorev != null)
            {
                KritikYoluOlustur(enUzunOncuGorev, kritikYol, tumGorevler);
            }
        }
    }
}

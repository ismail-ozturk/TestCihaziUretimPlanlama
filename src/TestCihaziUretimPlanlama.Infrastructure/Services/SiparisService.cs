using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Services
{
    public class SiparisService : ISiparisService
    {
        private readonly ApplicationDbContext _context;
        private readonly IGorevService _gorevService;

        public SiparisService(ApplicationDbContext context, IGorevService gorevService)
        {
            _context = context;
            _gorevService = gorevService;
        }

        public async Task<Siparis> SiparisOlusturAsync(SiparisCreateModel model)
        {
            // Üretim numarası kontrolü
            var mevcutSiparis = await _context.Siparisler
                .FirstOrDefaultAsync(s => s.UretimNumarasi == model.UretimNumarasi);

            if (mevcutSiparis != null)
            {
                throw new InvalidOperationException($"Üretim numarası '{model.UretimNumarasi}' zaten mevcut.");
            }

            var siparis = new Siparis
            {
                UretimNumarasi = model.UretimNumarasi,
                Musteri = model.Musteri,
                IstenilenBaslangicTarihi = model.IstenilenBaslangicTarihi,
                KategoriId = model.KategoriId,
                KategoriSablonuKullan = model.KategoriSablonuKullan,
                Oncelik = model.Oncelik,
                SonTeslimTarihi = model.SonTeslimTarihi,
                Notlar = model.Notlar,
                ZorunluCncPersonelId=model.ZorunluCncPersonelId,
                ZorunluPmdPersonelId=model.ZorunluPmdPersonelId,
                ZorunluTeknikPersonelId=model.ZorunluTeknikPersonelId
            };

            _context.Siparisler.Add(siparis);
            await _context.SaveChangesAsync();

            // Üretim görevlerini oluştur
            if (model.KategoriSablonuKullan && model.KategoriId.HasValue)
            {
                await _gorevService.SablondanUretimGorevleriOlusturAsync(siparis.Id, model.KategoriId.Value);
            }
            else if (model.Gorevler?.Any() == true)
            {
                await _gorevService.ManuelUretimGorevleriOlusturAsync(siparis.Id, model.Gorevler);
            }

            return await GetDetayliSiparisAsync(siparis.Id);
        }

        public async Task<bool> SiparisDurumGuncelleAsync(int siparisId, SiparisDurum yeniDurum)
        {
            var siparis = await _context.Siparisler.FindAsync(siparisId);
            if (siparis == null)
                return false;

            siparis.Durum = yeniDurum;
            siparis.UpdatedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Siparis>> GetPlanlanacakSiparislerAsync()
        {
            return await _context.Siparisler
                .Include(s => s.Kategori)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.Gorev)
                .Where(s => s.Durum == SiparisDurum.Beklemede)
                .OrderBy(s => s.Oncelik)
                .ThenBy(s => s.IstenilenBaslangicTarihi)
                .ToListAsync();
        }

        public async Task<Siparis> GetDetayliSiparisAsync(int id)
        {
            return await _context.Siparisler
                .Include(s => s.Kategori)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.Gorev)
                        .ThenInclude(g => g.Departman)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.AtananPersonel)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.OncuBagimliliklar)
                .Include(s => s.UretimGorevleri)
                    .ThenInclude(ug => ug.ArdilBagimliliklar)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> SiparisIptalAsync(int siparisId)
        {
            var siparis = await _context.Siparisler
                .Include(s => s.UretimGorevleri)
                .FirstOrDefaultAsync(s => s.Id == siparisId);

            if (siparis == null)
                return false;

            // Başlamış görevler varsa iptal edilemez
            var baslamisGorev = siparis.UretimGorevleri
                .Any(ug => ug.Durum == GorevDurum.DevamEdiyor || ug.Durum == GorevDurum.Tamamlandi);

            if (baslamisGorev)
            {
                throw new InvalidOperationException("Başlamış görevleri olan sipariş iptal edilemez.");
            }

            siparis.Durum = SiparisDurum.Iptal;

            // Tüm görevleri iptal et
            foreach (var gorev in siparis.UretimGorevleri)
            {
                gorev.Durum = GorevDurum.Iptal;
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

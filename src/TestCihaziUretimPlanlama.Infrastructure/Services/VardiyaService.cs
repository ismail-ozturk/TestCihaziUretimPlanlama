using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Infrastructure.Services
{
    public class VardiyaService : IVardiyaService
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<VardiyaTipi, (TimeSpan Baslangic, TimeSpan Bitis)> _vardiyaSaatleri;

        public VardiyaService(ApplicationDbContext context)
        {
            _context = context;
            _vardiyaSaatleri = new Dictionary<VardiyaTipi, (TimeSpan, TimeSpan)>
            {
                { VardiyaTipi.Normal, (new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0)) },
                { VardiyaTipi.Gunduz, (new TimeSpan(7, 0, 0), new TimeSpan(15, 0, 0)) },
                { VardiyaTipi.A, (new TimeSpan(7, 0, 0), new TimeSpan(15, 0, 0)) },
                { VardiyaTipi.B, (new TimeSpan(15, 0, 0), new TimeSpan(23, 0, 0)) }
            };
        }

        public VardiyaTipi PersonelVardiyasiniGetir(Personel personel, DateTime tarih)
        {
            if (personel.CalismaSekli == CalismaSekli.Sabit)
            {
                return personel.SabitVardiyaTipi.GetValueOrDefault(VardiyaTipi.Normal);
            }

            if (!personel.DonerVardiyaBaslangicTarihi.HasValue) return VardiyaTipi.Normal;

            var baslangicTarihi = personel.DonerVardiyaBaslangicTarihi.Value;
            var baslangicVardiyasi = personel.DonerVardiyaBaslangicTipi.GetValueOrDefault(VardiyaTipi.A);
            var gecenGunSayisi = (tarih.Date - baslangicTarihi.Date).Days;
            var haftaSayisi = gecenGunSayisi / 7;

            return (haftaSayisi % 2 == 0) ? baslangicVardiyasi : (baslangicVardiyasi == VardiyaTipi.A ? VardiyaTipi.B : VardiyaTipi.A);
        }

        public (DateTime BaslangicZamani, DateTime BitisZamani) GorevZamanlariniHesapla(
            Personel personel,
            DateTime planTarihi,
            int gorevSuresi,
            DateTime? enErkenBaslangic = null)
        {
            double kalanSureSaat = gorevSuresi;
            DateTime gorevBaslangic = enErkenBaslangic ?? planTarihi;

            DateTime mevcutTarih = SonrakiUygunCalismaZamaniBul(personel, gorevBaslangic);
            gorevBaslangic = mevcutTarih;

            while (kalanSureSaat > 0)
            {
                var vardiyaTipi = PersonelVardiyasiniGetir(personel, mevcutTarih);
                var (vardiyaBaslangicSaati, vardiyaBitisSaati) = _vardiyaSaatleri[vardiyaTipi];

                DateTime gunBaslangic = mevcutTarih.Date.Add(vardiyaBaslangicSaati);
                DateTime gunBitis = mevcutTarih.Date.Add(vardiyaBitisSaati);

                DateTime gunIcindeBaslangic = mevcutTarih > gunBaslangic ? mevcutTarih : gunBaslangic;
                double gunIcindeCalisilabilirSaat = (gunBitis - gunIcindeBaslangic).TotalHours;

                if (gunIcindeCalisilabilirSaat <= 0)
                {
                    mevcutTarih = SonrakiCalismaGunuBul(personel, mevcutTarih.Date.AddDays(1));
                    mevcutTarih = mevcutTarih.Date.Add(vardiyaBaslangicSaati);
                    continue;
                }

                if (kalanSureSaat <= gunIcindeCalisilabilirSaat)
                {
                    mevcutTarih = mevcutTarih.AddHours(kalanSureSaat);
                    kalanSureSaat = 0;
                }
                else
                {
                    kalanSureSaat -= gunIcindeCalisilabilirSaat;
                    mevcutTarih = SonrakiCalismaGunuBul(personel, mevcutTarih.Date.AddDays(1));
                    mevcutTarih = mevcutTarih.Date.Add(vardiyaBaslangicSaati);
                }
            }

            return (gorevBaslangic, mevcutTarih);
        }

        public DateTime SonrakiCalismaGunuBul(Personel personel, DateTime baslangicTarihi)
        {
            var tarih = baslangicTarihi.Date;
            int denemeSayisi = 0;
            while (denemeSayisi < 365)
            {
                if (tarih.DayOfWeek != DayOfWeek.Sunday)
                {
                    bool isCumartesi = tarih.DayOfWeek == DayOfWeek.Saturday;
                    var vardiyaTipi = PersonelVardiyasiniGetir(personel, tarih);
                    var vardiyaTanimi = _context.VardiyaTanimlari.AsNoTracking().FirstOrDefault(v => v.VardiyaTipi == vardiyaTipi);

                    if (!isCumartesi || vardiyaTanimi?.CumartesiCalismasi == true)
                    {
                        bool planDisiTarih = _context.PlanDisiTarihler.AsNoTracking().Any(p => p.Tarih.Date == tarih.Date || (p.TekrarliMi && p.Tarih.Month == tarih.Month && p.Tarih.Day == tarih.Day));
                        bool izinli = _context.PersonelIzinleri.AsNoTracking().Any(i => i.PersonelId == personel.Id && i.BaslangicTarihi.Date <= tarih.Date && i.BitisTarihi.Date >= tarih.Date);

                        if (!planDisiTarih && !izinli)
                        {
                            return tarih;
                        }
                    }
                }
                tarih = tarih.AddDays(1);
                denemeSayisi++;
            }
            throw new Exception("Uygun çalışma günü bulunamadı.");
        }

        public DateTime SonrakiUygunCalismaZamaniBul(Personel personel, DateTime baslangicZamani)
        {
            DateTime mevcutZaman = baslangicZamani;
            int denemeSayisi = 0;
            while (denemeSayisi < 365)
            {
                var calismaGunu = SonrakiCalismaGunuBul(personel, mevcutZaman);
                var vardiyaTipi = PersonelVardiyasiniGetir(personel, calismaGunu);
                var (vardiyaBaslangicSaati, vardiyaBitisSaati) = _vardiyaSaatleri[vardiyaTipi];

                var gunBaslangic = calismaGunu.Add(vardiyaBaslangicSaati);
                var gunBitis = calismaGunu.Add(vardiyaBitisSaati);

                if (mevcutZaman <= gunBaslangic)
                {
                    return gunBaslangic;
                }

                if (mevcutZaman < gunBitis)
                {
                    return mevcutZaman;
                }

                mevcutZaman = calismaGunu.AddDays(1);
                denemeSayisi++;
            }
            throw new Exception("Uygun çalışma zamanı bulunamadı.");
        }

        public bool PersonelMusaitMi(Personel personel, DateTime baslangic, DateTime bitis)
        {
            var izinli = _context.PersonelIzinleri.Any(i => i.PersonelId == personel.Id && i.BaslangicTarihi <= bitis && i.BitisTarihi >= baslangic);
            if (izinli) return false;

            var mevcutGorev = _context.UretimGorevleri.Any(ug => ug.AtananPersonelId == personel.Id && ug.PlanlananBaslangic < bitis && ug.PlanlananBitis > baslangic);
            return !mevcutGorev;
        }

        public TimeSpan GunlukCalismaSaatiHesapla(Personel personel, DateTime tarih)
        {
            var vardiyaTipi = PersonelVardiyasiniGetir(personel, tarih);
            if (_vardiyaSaatleri.TryGetValue(vardiyaTipi, out var saatler))
            {
                return saatler.Bitis - saatler.Baslangic;
            }
            return TimeSpan.Zero;
        }
    }
}

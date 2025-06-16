using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Services
{
    /// <summary>
    /// Personel vardiyalarını, çalışma saatlerini ve tatil günlerini yöneten servis.
    /// </summary>
    public interface IVardiyaService
    {
        /// <summary>
        /// Bir personelin belirtilen tarihteki vardiya tipini getirir.
        /// </summary>
        /// <param name="personel">Personel nesnesi.</param>
        /// <param name="tarih">Vardiyanın öğrenileceği tarih.</param>
        /// <returns>VardiyaTipi enum değeri.</returns>
        VardiyaTipi PersonelVardiyasiniGetir(Personel personel, DateTime tarih);

        /// <summary>
        /// Bir görevin başlangıç ve bitiş zamanını, personelin vardiya, izin ve tatil günlerini
        /// dikkate alarak, gerçek çalışma saatlerine göre hesaplar.
        /// </summary>
        /// <param name="personel">Görevi yapacak personel.</param>
        /// <param name="planTarihi">Planlamanın başlayacağı tarih.</param>
        /// <param name="gorevSuresi">Görevin saat cinsinden süresi.</param>
        /// <param name="enErkenBaslangic">Görevin başlayabileceği en erken zaman (opsiyonel).</param>
        /// <returns>Hesaplanmış başlangıç ve bitiş zamanlarını içeren bir tuple döner.</returns>
        (DateTime BaslangicZamani, DateTime BitisZamani) GorevZamanlariniHesapla(
            Personel personel,
            DateTime planTarihi,
            int gorevSuresi,
            DateTime? enErkenBaslangic = null);

        /// <summary>
        /// Belirtilen bir tarihten sonraki ilk uygun çalışma gününü bulur (Pazar, resmi tatil ve izinler hariç).
        /// </summary>
        /// <param name="personel">Personel nesnesi.</param>
        /// <param name="baslangicTarihi">Aramaya başlanacak tarih.</param>
        /// <returns>Bir sonraki uygun çalışma günü.</returns>
        DateTime SonrakiCalismaGunuBul(Personel personel, DateTime baslangicTarihi);

        /// <summary>
        /// Belirtilen bir andan sonraki ilk uygun çalışma zamanını (saat ve dakika dahil) bulur.
        /// </summary>
        /// <param name="personel">Personel nesnesi.</param>
        /// <param name="baslangicZamani">Aramaya başlanacak an.</param>
        /// <returns>Bir sonraki uygun çalışma anı.</returns>
        DateTime SonrakiUygunCalismaZamaniBul(Personel personel, DateTime baslangicZamani);

        /// <summary>
        /// Bir personelin belirtilen zaman aralığında başka bir görevi veya izni olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="personel">Personel nesnesi.</param>
        /// <param name="baslangic">Kontrol edilecek zaman aralığının başlangıcı.</param>
        /// <param name="bitis">Kontrol edilecek zaman aralığının bitişi.</param>
        /// <returns>Personel müsait ise true döner.</returns>
        bool PersonelMusaitMi(Personel personel, DateTime baslangic, DateTime bitis);

        /// <summary>
        /// Bir personelin belirtilen tarihteki günlük toplam çalışma saatini hesaplar.
        /// </summary>
        /// <param name="personel">Personel nesnesi.</param>
        /// <param name="tarih">Hesaplama yapılacak tarih.</param>
        /// <returns>Günlük çalışma süresini TimeSpan olarak döner.</returns>
        TimeSpan GunlukCalismaSaatiHesapla(Personel personel, DateTime tarih);
    }
}

using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Core.Interfaces.Services
{
    /// <summary>
    /// Üretim planlama, görev atama ve zamanlama işlemlerini yöneten servis.
    /// </summary>
    public interface IPlanlamaService
    {
        /// <summary>
        /// Belirtilen bir siparişin tüm görevlerini sıralı ve çakışmasız bir şekilde planlar.
        /// </summary>
        /// <param name="siparisId">Planlanacak siparişin ID'si.</param>
        /// <returns>Planlama işlemi başarılı ise true döner.</returns>
        Task<bool> SiparisiPlanlaAsync(int siparisId);

        /// <summary>
        /// Beklemedeki veya planlanmış tüm siparişleri sıfırlayıp, öncelik sırasına göre yeniden planlar.
        /// </summary>
        /// <returns>Yeniden planlama işlemi başarılı ise true döner.</returns>
        Task<bool> TumSiparisleriYenidenPlanlaAsync();

        /// <summary>
        /// Belirli bir görevin başlangıç zamanını günceller ve bu değişiklikten etkilenen
        /// (aynı siparişteki ardıllar ve diğer siparişlerdeki çakışanlar) tüm görevleri yeniden planlar.
        /// </summary>
        /// <param name="uretimGoreviId">Zamanı güncellenecek görevin ID'si.</param>
        /// <param name="yeniBaslangic">Görevin yeni başlangıç zamanı.</param>
        /// <returns>Güncelleme ve yeniden planlama işlemi başarılı ise true döner.</returns>
        Task<bool> GorevZamaniGuncelleAsync(int uretimGoreviId, DateTime yeniBaslangic);

        /// <summary>
        /// Bir personelin belirtilen tarih aralığındaki planlanmış görevlerini getirir.
        /// </summary>
        /// <param name="personelId">Personelin ID'si.</param>
        /// <param name="baslangic">Tarih aralığının başlangıcı.</param>
        /// <param name="bitis">Tarih aralığının bitişi.</param>
        /// <returns>Personelin görev listesini döner.</returns>
        Task<IEnumerable<UretimGorevi>> GetPersonelPlaniniAsync(int personelId, DateTime baslangic, DateTime bitis);

        /// <summary>
        /// Bir personelin belirtilen tarih aralığındaki iş yükünü yüzde olarak hesaplar.
        /// </summary>
        /// <param name="personelId">Personelin ID'si.</param>
        /// <param name="baslangic">Tarih aralığının başlangıcı.</param>
        /// <param name="bitis">Tarih aralığının bitişi.</param>
        /// <returns>İş yükü yüzdesini (0-100) döner.</returns>
        Task<double> PersonelIsYukuHesaplaAsync(int personelId, DateTime baslangic, DateTime bitis);
    }
}

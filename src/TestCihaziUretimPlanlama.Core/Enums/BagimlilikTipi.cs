namespace TestCihaziUretimPlanlama.Core.Enums
{
    public enum BagimlilikTipi
    {
        /// <summary>
        /// Öncül görev bitmeden ardıl görev başlayamaz (En yaygın)
        /// </summary>
        FinishToStart = 1,

        /// <summary>
        /// Öncül görev başladıktan sonra ardıl görev başlayabilir
        /// </summary>
        StartToStart = 2,

        /// <summary>
        /// Öncül görev bittiğinde ardıl görev de bitmeli
        /// </summary>
        FinishToFinish = 3,

        /// <summary>
        /// Öncül görev başladığında ardıl görev bitmeli
        /// </summary>
        StartToFinish = 4
    }
}

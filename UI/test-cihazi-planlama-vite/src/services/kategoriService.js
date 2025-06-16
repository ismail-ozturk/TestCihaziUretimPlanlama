import apiClient from './api';

export const kategoriService = {
  // Tüm kategorileri getir
  getAll: async () => {
    try {
      const response = await apiClient.get('/Kategori');
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      return [];
    } catch (error) {
      console.error('Kategori listesi alınamadı:', error);
      throw error;
    }
  },

  // Kategori detayını ve şablonunu getir
  getById: async (kategoriId) => {
    try {
      const response = await apiClient.get(`/Kategori/${kategoriId}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Kategori bulunamadı');
    } catch (error) {
      console.error('Kategori detayı alınamadı:', error);
      throw error;
    }
  },

  // Kategori şablonunu getir
  getSablon: async (kategoriId) => {
    try {
      const kategoriDetay = await kategoriService.getById(kategoriId);
      
      if (kategoriDetay && kategoriDetay.gorevSablonlari) {
        return {
          gorevler: kategoriDetay.gorevSablonlari,
          bagimliliklar: kategoriDetay.bagimliliklar || []
        };
      }
      
      return { gorevler: [], bagimliliklar: [] };
    } catch (error) {
      console.error('Kategori şablonu alınamadı:', error);
      throw error;
    }
  }
};

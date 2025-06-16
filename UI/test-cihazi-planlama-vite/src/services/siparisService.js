import apiClient from './api';

export const siparisService = {
  // Tüm siparişleri getir
  getAll: async () => {
    try {
      const response = await apiClient.get('/Siparis');
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      console.warn('API yanıtı beklenmeyen formatta:', response.data);
      return [];
    } catch (error) {
      console.error('Sipariş listesi alınamadı:', error);
      throw error;
    }
  },

  // Sipariş detayını getir
  getById: async (id) => {
    try {
      const response = await apiClient.get(`/Siparis/${id}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Sipariş bulunamadı');
    } catch (error) {
      console.error('Sipariş detayı alınamadı:', error);
      throw error;
    }
  },

  // Yeni sipariş oluştur
  create: async (siparisData) => {
    try {
      const response = await apiClient.post('/Siparis', siparisData);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Sipariş oluşturulamadı');
    } catch (error) {
      console.error('Sipariş oluşturulamadı:', error);
      throw error;
    }
  },

  // Siparişi iptal et
  cancel: async (id) => {
    try {
      const response = await apiClient.delete(`/Siparis/${id}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Sipariş iptal edilemedi');
    } catch (error) {
      console.error('Sipariş iptal edilemedi:', error);
      throw error;
    }
  },
  getSiparisDetay: async (siparisId) => {
    try {
      const response = await apiClient.get(`/Siparis/${siparisId}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Sipariş detayı bulunamadı');
    } catch (error) {
      console.error('Sipariş detayı alınamadı:', error);
      throw error;
    }
  }
};

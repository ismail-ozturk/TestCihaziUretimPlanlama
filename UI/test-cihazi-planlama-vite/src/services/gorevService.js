import apiClient from './api';

export const gorevService = {
  // Tüm görevleri getir
  getAll: async () => {
    try {
      const response = await apiClient.get('/Gorev');
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      console.warn('Görev API yanıtı beklenmeyen formatta:', response.data);
      return [];
    } catch (error) {
      console.error('Görev listesi alınamadı:', error);
      throw error;
    }
  },

  // Görev detayını getir
  getById: async (id) => {
    try {
      const response = await apiClient.get(`/Gorev/${id}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev bulunamadı');
    } catch (error) {
      console.error('Görev detayı alınamadı:', error);
      throw error;
    }
  },

  // Görev durumunu güncelle
   updateGorevDurum: async (gorevId, yeniDurum, aciklama = '') => {
    try {
      const payload = {
        gorevId: gorevId,
        yeniDurum: yeniDurum,
        aciklama: aciklama
       
      };
      
      const response = await apiClient.put(`/Gorev/${gorevId}/durum`, payload);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev durumu güncellenemedi');
    } catch (error) {
      console.error('Görev durumu güncellenemedi:', error);
      throw error;
    }
  },

  // Yeni görev oluştur
  create: async (gorevData) => {
    try {
      const response = await apiClient.post('/Gorev', gorevData);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev oluşturulamadı');
    } catch (error) {
      console.error('Görev oluşturulamadı:', error);
      throw error;
    }
  },

  // Görev güncelle
  update: async (gorevId, gorevData) => {
    try {
      const response = await apiClient.put(`/Gorev/${gorevId}`, gorevData);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev güncellenemedi');
    } catch (error) {
      console.error('Görev güncellenemedi:', error);
      throw error;
    }
  },

  // Görev sil
  delete: async (gorevId) => {
    try {
      const response = await apiClient.delete(`/Gorev/${gorevId}`);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev silinemedi');
    } catch (error) {
      console.error('Görev silinemedi:', error);
      throw error;
    }
  },

  // Departmana göre görevleri getir
  getByDepartman: async (departmanId) => {
    try {
      const response = await apiClient.get(`/Gorev/departman/${departmanId}`);
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      return [];
    } catch (error) {
      console.error('Departman görevleri alınamadı:', error);
      throw error;
    }
  }
};

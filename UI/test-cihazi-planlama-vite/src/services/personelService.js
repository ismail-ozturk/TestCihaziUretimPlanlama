import apiClient from './api';

export const personelService = {
  getAll: async () => {
    try {
      const response = await apiClient.get('/Personel');
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      return [];
    } catch (error) {
      console.error('Personel listesi alınamadı:', error);
      throw error;
    }
  },

  getByDepartman: async (departmanId) => {
    try {
      const response = await apiClient.get(`/Personel/departman/${departmanId}`);
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      return [];
    } catch (error) {
      console.error('Departman personeli alınamadı:', error);
      throw error;
    }
  }
};

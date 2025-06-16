// src/services/departmanService.js
import apiClient from './api';

export const departmanService = {
  getAll: async () => {
    try {
      const response = await apiClient.get('/Departman');
      if (response.data && response.data.success && Array.isArray(response.data.data)) {
        return response.data.data;
      }
      return [];
    } catch (error) {
      console.error('Departman listesi alınamadı:', error);
      throw error;
    }
  }
};

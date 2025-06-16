// src/services/planlamaService.js
import apiClient from './api';

export const planlamaService = {
  // Planlama yapar (tek sipariş veya tüm siparişler)
  planla: async (siparisId = null, tumSiparisleriPlanla = false) => {
    try {
      const payload = {
        siparisId: siparisId,
        tumSiparisleriPlanla: tumSiparisleriPlanla
      };
      const response = await apiClient.post('/Planlama/planla', payload);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Planlama yapılamadı');
    } catch (error) {
      console.error('Planlama yapılamadı:', error);
      throw error;
    }
  },

  // Personel planını getirir
  getPersonelPlan: async (personelId, baslangicTarihi, bitisTarihi) => {
    try {
      const payload = {
        personelId,
        baslangicTarihi,
        bitisTarihi
      };
      const response = await apiClient.post('/Planlama/personel-plan', payload);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Personel planı alınamadı');
    } catch (error) {
      console.error('Personel planı alınamadı:', error);
      throw error;
    }
  },

  // Görev zamanını günceller
  updateGorevZamani: async (uretimGoreviId, yeniBaslangicZamani) => {
    try {
      const payload = {
        uretimGoreviId,
        yeniBaslangicZamani
      };
      const response = await apiClient.put('/Planlama/gorev-zamani', payload);
      if (response.data && response.data.success) {
        return response.data.data;
      }
      throw new Error(response.data?.message || 'Görev zamanı güncellenemedi');
    } catch (error) {
      console.error('Görev zamanı güncellenemedi:', error);
      throw error;
    }
  },

  // Gantt Chart için planlama verilerini getirir (filtreleme parametreleri ile)
  getGanttData: async (filters = {}) => {
    try {
      const params = new URLSearchParams();
      
      // API dokümantasyonuna göre query parametreleri
      if (filters.baslangic) {
        params.append('baslangic', filters.baslangic);
      }
      if (filters.bitis) {
        params.append('bitis', filters.bitis);
      }
      if (filters.siparisNo) {
        params.append('siparisNo', filters.siparisNo);
      }
      if (filters.departman) {
        params.append('departman', filters.departman);
      }
      if (filters.personel) {
        params.append('personel', filters.personel);
      }

      const url = `/Planlama/gantt-data${params.toString() ? `?${params.toString()}` : ''}`;
      const response = await apiClient.get(url);
      
      if (response.data && response.data.success) {
        return response.data.data;
      }
      return { tasks: [], links: [], filters: {} };
    } catch (error) {
      console.error('Gantt verileri alınamadı:', error);
      throw error;
    }
  }
};

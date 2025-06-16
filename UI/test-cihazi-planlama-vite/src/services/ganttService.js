// src/services/ganttService.js
import apiClient from './api';

export const ganttService = {
  // API verilerini DHTMLX Gantt formatına dönüştür
  transformToGanttFormat: (apiResponse) => {
    // API'den gelen veri zaten doğru formatta
    if (!apiResponse || !apiResponse.tasks || !apiResponse.links) {
      return { tasks: [], links: [] };
    }

    // Tasks'ları DHTMLX formatına dönüştür
    const tasks = apiResponse.tasks.map(task => ({
      id: task.id,
      text: task.text,
      start_date: new Date(task.startDate),
      duration: task.duration,
      progress: task.progress,
      parent: task.parent || 0,
      type: task.type,
      color: task.color,
      
      // Ek bilgiler
      siparisNo: task.siparisNo,
      departmanAdi: task.departmanAdi,
      personelAdi: task.personelAdi,
      gorevAdi: task.gorevAdi,
      durum: task.durum,
      sure: task.sure,
      musteri: task.musteri,
      oncelik: task.oncelik,
      resourceId: task.resourceId
    }));

    // Links'leri DHTMLX formatına dönüştür
    const links = apiResponse.links.map(link => ({
      id: link.id,
      source: link.source,
      target: link.target,
      type: link.type === 'finish_to_start' ? '0' : 
            link.type === 'start_to_start' ? '1' :
            link.type === 'finish_to_finish' ? '2' :
            link.type === 'start_to_finish' ? '3' : '0'
    }));

    return { 
      tasks, 
      links,
      filters: apiResponse.filters || {}
    };
  },

  // Gantt Chart verilerini API'den çek
  fetchGanttData: async () => {
    try {
      const response = await apiClient.get('/Planlama/gantt-data');
      if (response.data && response.data.success) {
        return ganttService.transformToGanttFormat(response.data.data);
      }
      return { tasks: [], links: [], filters: {} };
    } catch (error) {
      console.error('Gantt verileri alınamadı:', error);
      throw error;
    }
  }
};

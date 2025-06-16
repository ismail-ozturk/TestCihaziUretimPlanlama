// src/hooks/useGantt.js
import { useState, useEffect } from 'react';
import { planlamaService } from '../services/planlamaService';
import { useGorevZamaniGuncelle } from './usePlanlama';

export const useGantt = (initialFilters = {}) => {
  const [ganttData, setGanttData] = useState({ tasks: [], links: [], filters: {} });
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [currentFilters, setCurrentFilters] = useState(initialFilters);
  
  const gorevZamaniGuncelle = useGorevZamaniGuncelle();

  const fetchData = async (filters = currentFilters) => {
    try {
      setLoading(true);
      const data = await planlamaService.getGanttData(filters);
      
      // API'den gelen veriyi DHTMLX Gantt formatına dönüştür
      const transformedData = transformToGanttFormat(data);
      setGanttData(transformedData);
    } catch (err) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  // API verilerini DHTMLX Gantt formatına dönüştür
  const transformToGanttFormat = (apiData) => {
    if (!apiData || !apiData.tasks || !apiData.links) {
      return { tasks: [], links: [], filters: {} };
    }

    const tasks = apiData.tasks.map(task => ({
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
      uretimGoreviId: task.uretimGoreviId
    }));

    const links = apiData.links.map(link => ({
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
      filters: apiData.filters || {}
    };
  };

  useEffect(() => {
    fetchData();
  }, []);

  const applyFilters = async (newFilters) => {
    setCurrentFilters(newFilters);
    await fetchData(newFilters);
  };

  const clearFilters = async () => {
    const emptyFilters = {};
    setCurrentFilters(emptyFilters);
    await fetchData(emptyFilters);
  };

  const handleTaskUpdate = async (id, task) => {
    try {
      if (task.type !== 'project' && task.uretimGoreviId) {
        await gorevZamaniGuncelle.mutateAsync({
          uretimGoreviId: task.uretimGoreviId,
          yeniBaslangicZamani: task.start_date.toISOString()
        });
        // Güncelleme sonrası verileri yenile
        await fetchData();
      }
    } catch (error) {
      console.error('Görev güncellenemedi:', error);
    }
  };

  const handleLinkUpdate = (id, link) => {
    console.log('Bağımlılık güncellendi:', id, link);
    // Burada bağımlılık güncelleme API'si çağrılabilir
  };

  return {
    ganttData,
    loading,
    error,
    currentFilters,
    refetch: () => fetchData(),
    applyFilters,
    clearFilters,
    handleTaskUpdate,
    handleLinkUpdate
  };
};

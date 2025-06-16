// src/hooks/usePlanlama.js
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { planlamaService } from '../services/planlamaService';
import { message } from 'antd';

// Tek sipariş planlama
export const useTekSiparisPlanlama = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: (siparisId) => planlamaService.planla(siparisId, false),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['siparisler'] });
      queryClient.invalidateQueries({ queryKey: ['gantt-data'] });
      message.success('Sipariş başarıyla planlandı!');
    },
    onError: (error) => {
      message.error(`Planlama yapılamadı: ${error.message}`);
    },
  });
};

// Tüm siparişler planlama
export const useTumSiparislerPlanlama = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: () => planlamaService.planla(null, true),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['siparisler'] });
      queryClient.invalidateQueries({ queryKey: ['gantt-data'] });
      message.success('Tüm siparişler başarıyla planlandı!');
    },
    onError: (error) => {
      message.error(`Toplu planlama yapılamadı: ${error.message}`);
    },
  });
};

// Personel planı
export const usePersonelPlan = (personelId, baslangicTarihi, bitisTarihi) => {
  return useQuery({
    queryKey: ['personel-plan', personelId, baslangicTarihi, bitisTarihi],
    queryFn: () => planlamaService.getPersonelPlan(personelId, baslangicTarihi, bitisTarihi),
    enabled: !!personelId && !!baslangicTarihi && !!bitisTarihi,
    staleTime: 2 * 60 * 1000,
  });
};

// Görev zamanı güncelleme
export const useGorevZamaniGuncelle = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: ({ uretimGoreviId, yeniBaslangicZamani }) => 
      planlamaService.updateGorevZamani(uretimGoreviId, yeniBaslangicZamani),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['gantt-data'] });
      queryClient.invalidateQueries({ queryKey: ['siparisler'] });
      message.success('Görev zamanı güncellendi!');
    },
    onError: (error) => {
      message.error(`Görev zamanı güncellenemedi: ${error.message}`);
    },
  });
};

// Gantt Chart verileri
export const useGanttData = (filters = {}) => {
  return useQuery({
    queryKey: ['gantt-data', filters],
    queryFn: () => planlamaService.getGanttData(filters),
    staleTime: 2 * 60 * 1000,
    refetchInterval: 30000, // 30 saniyede bir otomatik yenile
  });
};

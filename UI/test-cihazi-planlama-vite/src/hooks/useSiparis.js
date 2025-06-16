import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { siparisService } from '../services/siparisService';
import { message } from 'antd';

export const useSiparisler = () => {
  return useQuery({
    queryKey: ['siparisler'],
    queryFn: siparisService.getAll,
    staleTime: 5 * 60 * 1000,
  });
};

export const useSiparis = (id) => {
  return useQuery({
    queryKey: ['siparis', id],
    queryFn: () => siparisService.getById(id),
    enabled: !!id,
  });
};

export const useSiparisOlustur = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: siparisService.create,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['siparisler'] });
      message.success('Sipariş başarıyla oluşturuldu!');
    },
    onError: (error) => {
      message.error(`Sipariş oluşturulamadı: ${error.message}`);
    },
  });
};

export const useSiparisIptal = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: siparisService.cancel,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['siparisler'] });
      message.success('Sipariş başarıyla iptal edildi!');
    },
    onError: (error) => {
      message.error(`Sipariş iptal edilemedi: ${error.message}`);
    },
  });

};
export const useSiparisDetay = (siparisId) => {
  return useQuery({
    queryKey: ['siparis-detay', siparisId],
    queryFn: () => siparisService.getSiparisDetay(siparisId),
    enabled: !!siparisId,
    staleTime: 2 * 60 * 1000,
  });
};

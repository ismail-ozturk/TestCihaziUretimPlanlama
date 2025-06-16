import { useQuery } from '@tanstack/react-query';
import { personelService } from '../services/personelService';
import { departmanService } from '../services/departmanService';

export const usePersoneller = () => {
  return useQuery({
    queryKey: ['personeller'],
    queryFn: personelService.getAll,
    staleTime: 10 * 60 * 1000,
  });
};

export const usePersonelByDepartman = (departmanId) => {
  return useQuery({
    queryKey: ['personel-departman', departmanId],
    queryFn: () => personelService.getByDepartman(departmanId),
    enabled: !!departmanId,
    staleTime: 5 * 60 * 1000,
  });
};

export const useDepartmanlar = () => {
  return useQuery({
    queryKey: ['departmanlar'],
    queryFn: departmanService.getAll,
    staleTime: 15 * 60 * 1000,
  });
};

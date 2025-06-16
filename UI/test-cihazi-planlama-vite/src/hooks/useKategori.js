import { useQuery } from '@tanstack/react-query';
import { kategoriService } from '../services/kategoriService';

export const useKategoriler = () => {
  return useQuery({
    queryKey: ['kategoriler'],
    queryFn: kategoriService.getAll,
    staleTime: 10 * 60 * 1000,
  });
};

export const useKategoriDetay = (kategoriId) => {
  return useQuery({
    queryKey: ['kategori-detay', kategoriId],
    queryFn: () => kategoriService.getById(kategoriId),
    enabled: !!kategoriId,
    staleTime: 5 * 60 * 1000,
  });
};

export const useKategoriSablon = (kategoriId) => {
  return useQuery({
    queryKey: ['kategori-sablon', kategoriId],
    queryFn: () => kategoriService.getSablon(kategoriId),
    enabled: !!kategoriId,
    staleTime: 5 * 60 * 1000,
  });
};

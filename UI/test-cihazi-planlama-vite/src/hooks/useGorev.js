// src/hooks/useGorev.js
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { gorevService } from '../services/gorevService';
import { message } from 'antd';

// Görev durumu sabitlerini import et
import { GOREV_DURUMLARI } from '../utils/constants';

// Tüm görevleri getir
export const useGorevler = () => {
  return useQuery({
    queryKey: ['gorevler'],
    queryFn: gorevService.getAll,
    staleTime: 10 * 60 * 1000, // 10 dakika
    refetchOnWindowFocus: false,
  });
};

// Görev detayını getir
export const useGorev = (gorevId) => {
  return useQuery({
    queryKey: ['gorev', gorevId],
    queryFn: () => gorevService.getById(gorevId),
    enabled: !!gorevId,
    staleTime: 5 * 60 * 1000,
  });
};

// Ana görev durum güncelleme hook'u
export const useGorevDurumGuncelle = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: ({ gorevId, yeniDurum, aciklama = '', islemYapanPersonelId = null }) => 
      gorevService.updateGorevDurum(gorevId, yeniDurum, aciklama, islemYapanPersonelId),
    onSuccess: (data, variables) => {
      // İlgili query'leri invalidate et
      queryClient.invalidateQueries({ queryKey: ['siparis-detay'] });
      queryClient.invalidateQueries({ queryKey: ['gantt-data'] });
      queryClient.invalidateQueries({ queryKey: ['gorevler'] });
      queryClient.invalidateQueries({ queryKey: ['gorev', variables.gorevId] });
      
      message.success('Görev durumu başarıyla güncellendi!');
    },
    onError: (error) => {
      console.error('Görev durum güncelleme hatası:', error);
      message.error(`Görev durumu güncellenemedi: ${error.message}`);
    },
  });
};

// Görev başlatma hook'u
export const useGorevBaslat = () => {
  const durumGuncelle = useGorevDurumGuncelle();
  
  return {
    ...durumGuncelle,
    mutateAsync: (params) => {
      console.log('Görev başlatılıyor:', params);
      return durumGuncelle.mutateAsync({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.BASLADI,
        aciklama: params.aciklama || 'Görev başlatıldı',
        islemYapanPersonelId: params.islemYapanPersonelId
      });
    },
    mutate: (params, options) => {
      return durumGuncelle.mutate({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.BASLADI,
        aciklama: params.aciklama || 'Görev başlatıldı',
        islemYapanPersonelId: params.islemYapanPersonelId
      }, options);
    }
  };
};

// Görev tamamlama hook'u
export const useGorevTamamla = () => {
  const durumGuncelle = useGorevDurumGuncelle();
  
  return {
    ...durumGuncelle,
    mutateAsync: (params) => {
      console.log('Görev tamamlanıyor:', params);
      return durumGuncelle.mutateAsync({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.TAMAMLANDI,
        aciklama: params.aciklama || 'Görev tamamlandı',
        islemYapanPersonelId: params.islemYapanPersonelId
      });
    },
    mutate: (params, options) => {
      return durumGuncelle.mutate({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.TAMAMLANDI,
        aciklama: params.aciklama || 'Görev tamamlandı',
        islemYapanPersonelId: params.islemYapanPersonelId
      }, options);
    }
  };
};

// Görev bekletme hook'u
export const useGorevBeklet = () => {
  const durumGuncelle = useGorevDurumGuncelle();
  
  return {
    ...durumGuncelle,
    mutateAsync: (params) => {
      console.log('Görev bekletiliyor:', params);
      return durumGuncelle.mutateAsync({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.BEKLETILDI,
        aciklama: params.aciklama || 'Görev bekletildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      });
    },
    mutate: (params, options) => {
      return durumGuncelle.mutate({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.BEKLETILDI,
        aciklama: params.aciklama || 'Görev bekletildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      }, options);
    }
  };
};

// Görev devam ettirme hook'u
export const useGorevDevamEttir = () => {
  const durumGuncelle = useGorevDurumGuncelle();
  
  return {
    ...durumGuncelle,
    mutateAsync: (params) => {
      console.log('Görev devam ettiriliyor:', params);
      return durumGuncelle.mutateAsync({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.DEVAM_EDIYOR,
        aciklama: params.aciklama || 'Görev devam ettirildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      });
    },
    mutate: (params, options) => {
      return durumGuncelle.mutate({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.DEVAM_EDIYOR,
        aciklama: params.aciklama || 'Görev devam ettirildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      }, options);
    }
  };
};

// Görev iptal etme hook'u
export const useGorevIptal = () => {
  const durumGuncelle = useGorevDurumGuncelle();
  
  return {
    ...durumGuncelle,
    mutateAsync: (params) => {
      console.log('Görev iptal ediliyor:', params);
      return durumGuncelle.mutateAsync({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.IPTAL,
        aciklama: params.aciklama || 'Görev iptal edildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      });
    },
    mutate: (params, options) => {
      return durumGuncelle.mutate({
        gorevId: params.gorevId,
        yeniDurum: GOREV_DURUMLARI.IPTAL,
        aciklama: params.aciklama || 'Görev iptal edildi',
        islemYapanPersonelId: params.islemYapanPersonelId
      }, options);
    }
  };
};

// Toplu görev durum güncelleme hook'u
export const useTopluGorevDurumGuncelle = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: async ({ gorevIds, yeniDurum, aciklama = '', islemYapanPersonelId = null }) => {
      // Tüm görevleri sırayla güncelle
      const promises = gorevIds.map(gorevId => 
        gorevService.updateGorevDurum(gorevId, yeniDurum, aciklama, islemYapanPersonelId)
      );
      
      const results = await Promise.allSettled(promises);
      
      // Başarılı ve başarısız işlemleri ayır
      const successful = results.filter(result => result.status === 'fulfilled').length;
      const failed = results.filter(result => result.status === 'rejected').length;
      
      return { successful, failed, total: gorevIds.length };
    },
    onSuccess: (data) => {
      // İlgili query'leri invalidate et
      queryClient.invalidateQueries({ queryKey: ['siparis-detay'] });
      queryClient.invalidateQueries({ queryKey: ['gantt-data'] });
      queryClient.invalidateQueries({ queryKey: ['gorevler'] });
      
      if (data.failed === 0) {
        message.success(`${data.successful} görevin durumu başarıyla güncellendi!`);
      } else {
        message.warning(`${data.successful} görev güncellendi, ${data.failed} görev güncellenemedi.`);
      }
    },
    onError: (error) => {
      console.error('Toplu görev durum güncelleme hatası:', error);
      message.error(`Toplu güncelleme başarısız: ${error.message}`);
    },
  });
};

// Departmana göre görevleri getir
export const useGorevlerByDepartman = (departmanId) => {
  return useQuery({
    queryKey: ['gorevler-departman', departmanId],
    queryFn: () => gorevService.getByDepartman(departmanId),
    enabled: !!departmanId,
    staleTime: 5 * 60 * 1000,
  });
};

// Personele göre görevleri getir
export const useGorevlerByPersonel = (personelId) => {
  return useQuery({
    queryKey: ['gorevler-personel', personelId],
    queryFn: () => gorevService.getByPersonel(personelId),
    enabled: !!personelId,
    staleTime: 5 * 60 * 1000,
  });
};

// Görev istatistikleri
export const useGorevIstatistikleri = () => {
  return useQuery({
    queryKey: ['gorev-istatistikleri'],
    queryFn: async () => {
      const gorevler = await gorevService.getAll();
      
      const istatistikler = {
        toplam: gorevler.length,
        beklemede: gorevler.filter(g => g.durum === GOREV_DURUMLARI.BEKLEMEDE).length,
        planli: gorevler.filter(g => g.durum === GOREV_DURUMLARI.PLANLI).length,
        basladi: gorevler.filter(g => g.durum === GOREV_DURUMLARI.BASLADI).length,
        devamEdiyor: gorevler.filter(g => g.durum === GOREV_DURUMLARI.DEVAM_EDIYOR).length,
        tamamlandi: gorevler.filter(g => g.durum === GOREV_DURUMLARI.TAMAMLANDI).length,
        bekletildi: gorevler.filter(g => g.durum === GOREV_DURUMLARI.BEKLETILDI).length,
        iptal: gorevler.filter(g => g.durum === GOREV_DURUMLARI.IPTAL).length
      };
      
      return istatistikler;
    },
    staleTime: 2 * 60 * 1000, // 2 dakika
  });
};

// Aktif görevleri getir (Başladı + Devam Ediyor)
export const useAktifGorevler = () => {
  return useQuery({
    queryKey: ['aktif-gorevler'],
    queryFn: async () => {
      const gorevler = await gorevService.getAll();
      return gorevler.filter(g => 
        g.durum === GOREV_DURUMLARI.BASLADI || 
        g.durum === GOREV_DURUMLARI.DEVAM_EDIYOR
      );
    },
    staleTime: 1 * 60 * 1000, // 1 dakika
    refetchInterval: 30000, // 30 saniyede bir otomatik yenile
  });
};

// Geciken görevleri getir
export const useGecikenGorevler = () => {
  return useQuery({
    queryKey: ['geciken-gorevler'],
    queryFn: async () => {
      const gorevler = await gorevService.getAll();
      const simdi = new Date();
      
      return gorevler.filter(g => {
        // Sadece aktif görevleri kontrol et
        if (g.durum !== GOREV_DURUMLARI.BASLADI && g.durum !== GOREV_DURUMLARI.DEVAM_EDIYOR) {
          return false;
        }
        
        // Planlanan bitiş tarihi geçmiş mi?
        if (g.planlananBitis) {
          const planlananbitis = new Date(g.planlananBitis);
          return simdi > planlananbitis;
        }
        
        return false;
      });
    },
    staleTime: 2 * 60 * 1000,
    refetchInterval: 60000, // 1 dakikada bir kontrol et
  });
};

// Görev notları güncelleme
export const useGorevNotlariGuncelle = () => {
  const queryClient = useQueryClient();
  
  return useMutation({
    mutationFn: ({ gorevId, notlar }) => gorevService.updateNotlar(gorevId, notlar),
    onSuccess: (data, variables) => {
      queryClient.invalidateQueries({ queryKey: ['gorev', variables.gorevId] });
      queryClient.invalidateQueries({ queryKey: ['siparis-detay'] });
      message.success('Görev notları güncellendi!');
    },
    onError: (error) => {
      message.error(`Notlar güncellenemedi: ${error.message}`);
    },
  });
};

// Hook kullanım örnekleri ve yardımcı fonksiyonlar
export const gorevHookUtils = {
  // Görev durumu kontrolü
  isGorevAktif: (durum) => {
    return durum === GOREV_DURUMLARI.BASLADI || durum === GOREV_DURUMLARI.DEVAM_EDIYOR;
  },
  
  // Görev tamamlanmış mı kontrolü
  isGorevTamamlandi: (durum) => {
    return durum === GOREV_DURUMLARI.TAMAMLANDI;
  },
  
  // Görev bekletilmiş mi kontrolü
  isGorevBekletildi: (durum) => {
    return durum === GOREV_DURUMLARI.BEKLETILDI;
  },
  
  // Görev başlatılabilir mi kontrolü
  isGorevBaslatilabilir: (durum) => {
    return durum === GOREV_DURUMLARI.BEKLEMEDE || durum === GOREV_DURUMLARI.PLANLI;
  },
  
  // Görev devam ettirilebilir mi kontrolü
  isGorevDevamEttirilebilir: (durum) => {
    return durum === GOREV_DURUMLARI.BEKLETILDI;
  }
};

// Default export
export default {
  useGorevler,
  useGorev,
  useGorevDurumGuncelle,
  useGorevBaslat,
  useGorevTamamla,
  useGorevBeklet,
  useGorevDevamEttir,
  useGorevIptal,
  useTopluGorevDurumGuncelle,
  useGorevlerByDepartman,
  useGorevlerByPersonel,
  useGorevIstatistikleri,
  useAktifGorevler,
  useGecikenGorevler,
  useGorevNotlariGuncelle,
  gorevHookUtils
};

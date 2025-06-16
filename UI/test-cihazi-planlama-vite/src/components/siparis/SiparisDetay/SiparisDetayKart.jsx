// src/components/siparis/SiparisDetay/SiparisDetayKart.jsx
import React from 'react';
import { Card, Descriptions, Tag, Progress, Space, Button, Popconfirm } from 'antd';
import { 
  CalendarOutlined, 
  UserOutlined, 
  FlagOutlined,
  ReloadOutlined,
  DeleteOutlined,
  EditOutlined
} from '@ant-design/icons';
import { useTekSiparisPlanlama } from '../../../hooks/usePlanlama';
import { useSiparisIptal } from '../../../hooks/useSiparis';
import dayjs from 'dayjs';

const SiparisDetayKart = ({ siparis }) => {
  const tekSiparisPlanlama = useTekSiparisPlanlama();
  const siparisIptal = useSiparisIptal();

  const handleYenidenPlanla = async () => {
    await tekSiparisPlanlama.mutateAsync(siparis.id);
  };

  const handleSiparisIptal = async () => {
    await siparisIptal.mutateAsync(siparis.id);
  };

  const getDurumTag = (durumText) => {
    const durumConfig = {
      'Beklemede': { color: 'orange', text: 'Beklemede' },
      'Planli': { color: 'blue', text: 'Planlı' },
      'DevamEdiyor': { color: 'processing', text: 'Devam Ediyor' },
      'Tamamlandi': { color: 'success', text: 'Tamamlandı' },
      'Iptal': { color: 'error', text: 'İptal' }
    };
    
    const config = durumConfig[durumText] || { color: 'default', text: durumText };
    return <Tag color={config.color}>{config.text}</Tag>;
  };

  const getMusteriTag = (musteriText) => {
    return (
      <Tag color={musteriText === 'Almanya' ? 'blue' : 'green'}>
        {musteriText === 'Almanya' ? '🇩🇪' : '🇹🇷'} {musteriText}
      </Tag>
    );
  };

  const getOncelikTag = (oncelik) => {
    const oncelikConfig = {
      1: { color: 'red', text: '🔴 Çok Yüksek' },
      3: { color: 'orange', text: '🟠 Yüksek' },
      5: { color: 'gold', text: '🟡 Normal' },
      7: { color: 'green', text: '🟢 Düşük' },
      9: { color: 'default', text: '⚪ Çok Düşük' }
    };
    
    const config = oncelikConfig[oncelik] || oncelikConfig[5];
    return <Tag color={config.color}>{config.text}</Tag>;
  };

  return (
    <Card 
      className="modern-card"
      title={
        <Space>
          <FlagOutlined />
          <span>Sipariş Bilgileri</span>
        </Space>
      }
      extra={getDurumTag(siparis.durumText)}
    >
      <Descriptions column={1} size="small">
        <Descriptions.Item label="Sipariş No">
          <strong>#{siparis.id}</strong>
        </Descriptions.Item>
        
        <Descriptions.Item label="Üretim Numarası">
          <strong>{siparis.uretimNumarasi}</strong>
        </Descriptions.Item>
        
        <Descriptions.Item label="Müşteri">
          {getMusteriTag(siparis.musteriText)}
        </Descriptions.Item>
        
        <Descriptions.Item label="Kategori">
          {siparis.kategoriAdi ? (
            <Tag color="purple">{siparis.kategoriAdi}</Tag>
          ) : (
            <span style={{ color: '#999' }}>Kategori yok</span>
          )}
        </Descriptions.Item>
        
        <Descriptions.Item label="Öncelik">
          {getOncelikTag(siparis.oncelik)}
        </Descriptions.Item>
        
        <Descriptions.Item label="İstenilen Başlangıç">
          <Space>
            <CalendarOutlined />
            {dayjs(siparis.istenilenBaslangicTarihi).format('DD.MM.YYYY HH:mm')}
          </Space>
        </Descriptions.Item>
        
        <Descriptions.Item label="Son Teslim">
          <Space>
            <CalendarOutlined />
            {siparis.sonTeslimTarihi ? 
              dayjs(siparis.sonTeslimTarihi).format('DD.MM.YYYY') : 
              <span style={{ color: '#999' }}>Belirtilmemiş</span>
            }
          </Space>
        </Descriptions.Item>
        
        <Descriptions.Item label="Oluşturulma">
          {dayjs(siparis.createdDate).format('DD.MM.YYYY HH:mm')}
        </Descriptions.Item>
      </Descriptions>

      {/* İlerleme Bilgisi */}
      <div style={{ marginTop: '24px' }}>
        <h4 style={{ marginBottom: '12px' }}>
          <UserOutlined /> Görev İlerlemesi
        </h4>
        <Progress 
          percent={Math.round(siparis.tamamlanmaYuzdesi)} 
          status={siparis.tamamlanmaYuzdesi === 100 ? 'success' : 'active'}
          strokeColor={{
            '0%': '#108ee9',
            '100%': '#87d068',
          }}
        />
        <div style={{ 
          display: 'flex', 
          justifyContent: 'space-between', 
          marginTop: '8px',
          fontSize: '12px',
          color: '#666'
        }}>
          <span>Tamamlanan: {siparis.tamamlananGorevSayisi}</span>
          <span>Toplam: {siparis.toplamGorevSayisi}</span>
        </div>
      </div>

      {/* Notlar */}
      {siparis.notlar && (
        <div style={{ marginTop: '24px' }}>
          <h4 style={{ marginBottom: '8px' }}>Notlar</h4>
          <div style={{ 
            background: '#f6f6f6', 
            padding: '12px', 
            borderRadius: '6px',
            fontSize: '13px'
          }}>
            {siparis.notlar}
          </div>
        </div>
      )}

      {/* Aksiyon Butonları */}
      <div style={{ marginTop: '24px' }}>
        <Space direction="vertical" style={{ width: '100%' }}>
          {(siparis.durumText === 'Planli' || siparis.durumText === 'DevamEdiyor') && (
            <Button
              type="primary"
              icon={<ReloadOutlined />}
              onClick={handleYenidenPlanla}
              loading={tekSiparisPlanlama.isPending}
              block
            >
              Yeniden Planla
            </Button>
          )}
          
          <Button
            icon={<EditOutlined />}
            block
          >
            Düzenle
          </Button>
          
          {siparis.durumText === 'Beklemede' && (
            <Popconfirm
              title="Siparişi iptal etmek istediğinize emin misiniz?"
              description="Bu işlem geri alınamaz."
              onConfirm={handleSiparisIptal}
              okText="Evet"
              cancelText="Hayır"
            >
              <Button
                danger
                icon={<DeleteOutlined />}
                loading={siparisIptal.isPending}
                block
              >
                Siparişi İptal Et
              </Button>
            </Popconfirm>
          )}
        </Space>
      </div>
    </Card>
  );
};

export default SiparisDetayKart;

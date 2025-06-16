// src/components/siparis/SiparisListesi/SiparisListesi.jsx
import React from 'react';
import { Table, Button, Tag, Space, Spin, Alert, Progress, Popconfirm } from 'antd';
import { 
  EyeOutlined, 
  DeleteOutlined, 
  CalendarOutlined, 
  ReloadOutlined
} from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import { useSiparisler, useSiparisIptal } from '../../../hooks/useSiparis';
import { useTekSiparisPlanlama } from '../../../hooks/usePlanlama';
import dayjs from 'dayjs';

const SiparisListesi = () => {
  const navigate = useNavigate();
  const { data: siparisler, isLoading, error } = useSiparisler();
  const siparisIptal = useSiparisIptal();
  const tekSiparisPlanlama = useTekSiparisPlanlama();

  const handleDetayGor = (siparisId) => {
    navigate(`/siparis/${siparisId}`);
  };

  const handleSiparisIptal = async (siparisId) => {
    await siparisIptal.mutateAsync(siparisId);
  };

  const handleTekSiparisPlanlama = async (siparisId) => {
    await tekSiparisPlanlama.mutateAsync(siparisId);
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


const columns = [
  {
    title: 'Sipariş No',
    dataIndex: 'id',
    key: 'id',
    width: 100,
    sorter: (a, b) => a.id - b.id,
    // fixed: 'left', ← Bu satırı kaldırın veya koşullu yapın
  },
  {
    title: 'Üretim Numarası',
    dataIndex: 'uretimNumarasi',
    key: 'uretimNumarasi',
    width: 150,
    ellipsis: true,
  },
  {
    title: 'Müşteri',
    dataIndex: 'musteriText',
    key: 'musteriText',
    width: 120,
    render: getMusteriTag,
    filters: [
      { text: 'Almanya', value: 'Almanya' },
      { text: 'Türkiye', value: 'Turkiye' },
    ],
    onFilter: (value, record) => record.musteriText === value,
  },
  {
    title: 'Kategori',
    dataIndex: 'kategoriAdi',
    key: 'kategoriAdi',
    width: 120,
    render: (kategori) => kategori || '-',
  },
  {
    title: 'Başlangıç Tarihi',
    dataIndex: 'istenilenBaslangicTarihi',
    key: 'istenilenBaslangicTarihi',
    width: 160,
    render: (tarih) => tarih ? dayjs(tarih).format('DD.MM.YYYY HH:mm') : '-',
    sorter: (a, b) => new Date(a.istenilenBaslangicTarihi) - new Date(b.istenilenBaslangicTarihi),
  },
  {
    title: 'Son Teslim',
    dataIndex: 'sonTeslimTarihi',
    key: 'sonTeslimTarihi',
    width: 120,
    render: (tarih) => tarih ? dayjs(tarih).format('DD.MM.YYYY') : '-',
  },
  {
    title: 'Durum',
    dataIndex: 'durumText',
    key: 'durumText',
    width: 120,
    render: getDurumTag,
    filters: [
      { text: 'Beklemede', value: 'Beklemede' },
      { text: 'Planlı', value: 'Planli' },
      { text: 'Devam Ediyor', value: 'DevamEdiyor' },
      { text: 'Tamamlandı', value: 'Tamamlandi' },
      { text: 'İptal', value: 'Iptal' },
    ],
    onFilter: (value, record) => record.durumText === value,
  },
  {
    title: 'İlerleme',
    key: 'progress',
    width: 180,
    render: (_, record) => (
      <div>
        <Progress 
          percent={Math.round(record.tamamlanmaYuzdesi)} 
          size="small"
          status={record.tamamlanmaYuzdesi === 100 ? 'success' : 'active'}
        />
        <small style={{ color: '#666', fontSize: '11px' }}>
          {record.tamamlananGorevSayisi}/{record.toplamGorevSayisi} görev
        </small>
      </div>
    ),
  },
  {
    title: 'Öncelik',
    dataIndex: 'oncelik',
    key: 'oncelik',
    width: 80,
    align: 'center',
    render: (oncelik) => (
      <Tag color={oncelik >= 8 ? 'red' : oncelik >= 5 ? 'orange' : 'green'}>
        {oncelik}
      </Tag>
    ),
    sorter: (a, b) => a.oncelik - b.oncelik,
  },
  {
    title: 'İşlemler',
    key: 'actions',
    width: 240,
    // fixed: 'right', ← Bu satırı da kaldırın
    render: (_, record) => (
      <Space size="small">
        <Button
          type="primary"
          size="small"
          icon={<EyeOutlined />}
          onClick={() => handleDetayGor(record.id)}
        >
          Detay
        </Button>
        
        {record.durumText === 'Beklemede' && (
          <Button
            type="default"
            size="small"
            icon={<CalendarOutlined />}
            onClick={() => handleTekSiparisPlanlama(record.id)}
            loading={tekSiparisPlanlama.isPending}
          >
            Planla
          </Button>
        )}
        
        {(record.durumText === 'Planli' || record.durumText === 'DevamEdiyor') && (
          <Button
            type="default"
            size="small"
            icon={<ReloadOutlined />}
            onClick={() => handleTekSiparisPlanlama(record.id)}
            loading={tekSiparisPlanlama.isPending}
          >
            Yeniden Planla
          </Button>
        )}
        
        {record.durumText === 'Beklemede' && (
          <Popconfirm
            title="Siparişi iptal etmek istediğinize emin misiniz?"
            description="Bu işlem geri alınamaz."
            onConfirm={() => handleSiparisIptal(record.id)}
            okText="Evet"
            cancelText="Hayır"
          >
            <Button
              danger
              size="small"
              icon={<DeleteOutlined />}
              loading={siparisIptal.isPending}
            >
              İptal
            </Button>
          </Popconfirm>
        )}
      </Space>
    ),
  },
];

  if (isLoading) {
    return (
      <div style={{ 
        display: 'flex', 
        justifyContent: 'center', 
        alignItems: 'center',
        height: '400px',
        flexDirection: 'column'
      }}>
        <Spin size="large" />
        <p style={{ marginTop: '16px' }}>Siparişler yükleniyor...</p>
      </div>
    );
  }

  if (error) {
    return (
      <Alert
        message="Hata"
        description={`Siparişler yüklenirken hata oluştu: ${error.message}`}
        type="error"
        showIcon
        style={{ margin: '20px 0' }}
        action={
          <Button onClick={() => window.location.reload()}>
            Yeniden Dene
          </Button>
        }
      />
    );
  }

  return (
    <div style={{ 
      background: 'white',
      borderRadius: '12px',
      overflow: 'hidden',
      boxShadow: '0 2px 8px rgba(0, 0, 0, 0.06)',
      border: '1px solid #f0f0f0'
    }}>
      <Table
        columns={columns}
        dataSource={siparisler || []}
        rowKey="id"
        pagination={{
          pageSize: 20,
          showSizeChanger: true,
          showQuickJumper: true,
          showTotal: (total, range) =>
            `${range[0]}-${range[1]} / ${total} sipariş`,
          pageSizeOptions: ['10', '20', '50', '100'],
        }}
        scroll={{ 
          x: 1600, // Minimum genişlik
          y: 'calc(100vh - 280px)' // Dinamik yükseklik
        }}
        size="middle"
        bordered={false}
        style={{
          width: '100%'
        }}
        className="siparis-listesi-table"
      />
    </div>
  );
};

export default SiparisListesi;

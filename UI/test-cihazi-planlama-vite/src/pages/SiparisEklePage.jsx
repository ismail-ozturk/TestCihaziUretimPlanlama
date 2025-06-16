// src/pages/SiparisEklePage.jsx
import React from 'react';
import { Button, Space, Breadcrumb } from 'antd';
import { ArrowLeftOutlined, HomeOutlined, UnorderedListOutlined, PlusOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import SiparisEkleForm from '../components/siparis/SiparisEkle/SiparisEkleForm';

const SiparisEklePage = () => {
  const navigate = useNavigate();

  return (
    <div style={{
      width: '100%',
      height: '100%',
      display: 'flex',
      flexDirection: 'column',
      overflow: 'hidden'
    }}>
      {/* Header - Diğer sayfalarla tutarlı */}
      <div style={{
        background: 'white',
        padding: '24px',
        borderBottom: '1px solid #e8e8e8',
        flexShrink: 0
      }}>
        {/* Breadcrumb */}
        <div style={{ marginBottom: '16px' }}>
          <Breadcrumb
            items={[
              {
                href: '/siparisler',
                title: <HomeOutlined />,
              },
              {
                href: '/siparisler',
                title: (
                  <Space>
                    <UnorderedListOutlined />
                    <span>Siparişler</span>
                  </Space>
                ),
              },
              {
                title: (
                  <Space>
                    <PlusOutlined />
                    <span>Yeni Sipariş</span>
                  </Space>
                ),
              },
            ]}
          />
        </div>
        
        {/* Başlık ve Butonlar */}
        <div style={{ 
          display: 'flex', 
          justifyContent: 'space-between', 
          alignItems: 'center' 
        }}>
          <div>
            <h1 style={{ margin: 0, fontSize: '24px', fontWeight: 600, color: '#262626' }}>
              Yeni Sipariş Oluştur
            </h1>
            <p style={{ margin: '4px 0 0 0', color: '#8c8c8c', fontSize: '14px' }}>
              Sipariş bilgilerini girin ve görevleri tanımlayın
            </p>
          </div>
          <Space>
            <Button
              icon={<ArrowLeftOutlined />}
              onClick={() => navigate('/siparisler')}
              size="large"
            >
              Sipariş Listesine Dön
            </Button>
          </Space>
        </div>
      </div>
      
      {/* İçerik */}
      <div style={{
        flex: 1,
        overflow: 'auto',
        padding: '24px'
      }}>
        <SiparisEkleForm />
      </div>
    </div>
  );
};

export default SiparisEklePage;

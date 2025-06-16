// src/pages/SiparisListesiPage.jsx
import React from 'react';
import { Button, Space, Breadcrumb } from 'antd';
import { PlusOutlined, ThunderboltOutlined, HomeOutlined, UnorderedListOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import SiparisListesi from '../components/siparis/SiparisListesi/SiparisListesi';
import { useTumSiparislerPlanlama } from '../hooks/usePlanlama';

const SiparisListesiPage = () => {
  const navigate = useNavigate();
  const tumSiparislerPlanlama = useTumSiparislerPlanlama();

  const handleTumSiparislerPlanlama = async () => {
    await tumSiparislerPlanlama.mutateAsync();
  };

  return (
    <div style={{
      width: '100%',
      height: '100%',
      display: 'flex',
      flexDirection: 'column',
      overflow: 'hidden'
    }}>
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
                title: <HomeOutlined />,
              },
              {
                title: (
                  <Space>
                    <UnorderedListOutlined />
                    <span>Sipariş Yönetimi</span>
                  </Space>
                ),
              },
            ]}
          />
        </div>

        <div style={{ 
          display: 'flex', 
          justifyContent: 'space-between', 
          alignItems: 'center' 
        }}>
          <div>
            <h1 style={{ margin: 0, fontSize: '24px', fontWeight: 600, color: '#262626' }}>
              Sipariş Yönetimi
            </h1>
            <p style={{ margin: '4px 0 0 0', color: '#8c8c8c', fontSize: '14px' }}>
              Tüm siparişlerinizi görüntüleyin, yönetin ve planlayın
            </p>
          </div>
          <Space size="middle">
            <Button
              icon={<ThunderboltOutlined />}
              onClick={handleTumSiparislerPlanlama}
              loading={tumSiparislerPlanlama.isPending}
              size="large"
            >
              Tümünü Planla
            </Button>
            <Button
              type="primary"
              icon={<PlusOutlined />}
              onClick={() => navigate('/siparis-ekle')}
              size="large"
            >
              Yeni Sipariş
            </Button>
          </Space>
        </div>
      </div>

      <div style={{ 
        flex: 1,
        padding: '24px',
        overflow: 'auto'
      }}>
        <SiparisListesi />
      </div>
    </div>
  );
};

export default SiparisListesiPage;

// src/pages/SiparisDetayPage.jsx
import React from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Button, Space, Breadcrumb } from 'antd';
import { ArrowLeftOutlined, HomeOutlined, UnorderedListOutlined } from '@ant-design/icons';
import SiparisDetay from '../components/siparis/SiparisDetay/SiparisDetay';

const SiparisDetayPage = () => {
  const { id } = useParams();
  const navigate = useNavigate();

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
                title: `Sipariş #${id}`,
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
              Sipariş Detayı
            </h1>
            <p style={{ margin: '4px 0 0 0', color: '#8c8c8c', fontSize: '14px' }}>
              Sipariş bilgileri, görevler ve planlama detayları
            </p>
          </div>
          <Space>
            <Button
              icon={<ArrowLeftOutlined />}
              onClick={() => navigate('/siparisler')}
            >
              Geri Dön
            </Button>
          </Space>
        </div>
      </div>

      <div style={{
        flex: 1,
        overflow: 'auto',
        padding: '24px'
      }}>
        <SiparisDetay siparisId={id} />
      </div>
    </div>
  );
};

export default SiparisDetayPage;

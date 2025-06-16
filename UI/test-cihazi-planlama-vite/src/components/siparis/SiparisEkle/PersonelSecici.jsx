import React, { useState } from 'react';
import { 
  Card, 
  Switch, 
  Select, 
  Space, 
  Typography, 
  Row, 
  Col,
  Tag,
  Divider,
  Alert
} from 'antd';
import { UserOutlined, TeamOutlined } from '@ant-design/icons';
import { useDepartmanlar } from '../../../hooks/usePersonel';
import { usePersonelByDepartman } from '../../../hooks/usePersonel';

const { Option } = Select;
const { Text } = Typography;

const PersonelSecici = ({ zorunluPersoneller, onChange }) => {
  const [zorunluPersonelAktif, setZorunluPersonelAktif] = useState(false);
  const { data: departmanlar, isLoading: departmanLoading } = useDepartmanlar();

  const handleZorunluPersonelChange = (checked) => {
    setZorunluPersonelAktif(checked);
    if (!checked) {
      onChange({});
    }
  };

  const handlePersonelSecim = (departmanId, personelIds) => {
    const yeniPersoneller = {
      ...zorunluPersoneller,
      [departmanId]: personelIds
    };
    
    // Boş departmanları temizle
    Object.keys(yeniPersoneller).forEach(key => {
      if (!yeniPersoneller[key] || yeniPersoneller[key].length === 0) {
        delete yeniPersoneller[key];
      }
    });
    
    onChange(yeniPersoneller);
  };

  const DepartmanPersonelSecici = ({ departman }) => {
    const { data: personeller, isLoading } = usePersonelByDepartman(departman.id);
    
    return (
      <div style={{ marginBottom: '16px' }}>
        <Text strong style={{ display: 'block', marginBottom: '8px' }}>
          <TeamOutlined /> {departman.ad} Departmanı
        </Text>
        <Select
          mode="multiple"
          placeholder={`${departman.ad} personeli seçin`}
          style={{ width: '100%' }}
          loading={isLoading}
          value={zorunluPersoneller[departman.id] || []}
          onChange={(values) => handlePersonelSecim(departman.id, values)}
          optionLabelProp="label"
        >
          {personeller?.map(personel => (
            <Option 
              key={personel.id} 
              value={personel.id}
              label={`${personel.ad} ${personel.soyad}`}
            >
              <Space>
                <UserOutlined />
                <span>{personel.ad} {personel.soyad}</span>
                <Tag size="small" color={
                  personel.vardiyaTipi === 'Sabit' ? 'blue' : 'orange'
                }>
                  {personel.vardiyaTipi}
                </Tag>
              </Space>
            </Option>
          ))}
        </Select>
      </div>
    );
  };

  const getSecilenPersonelSayisi = () => {
    return Object.values(zorunluPersoneller).reduce((total, personelIds) => {
      return total + (personelIds?.length || 0);
    }, 0);
  };

  return (
    <Card 
      title={
        <Space>
          <UserOutlined />
          <span>Zorunlu Personel Seçimi</span>
          {zorunluPersonelAktif && (
            <Tag color="blue">{getSecilenPersonelSayisi()} personel seçildi</Tag>
          )}
        </Space>
      }
      size="small"
      style={{ height: '100%' }}
    >
      <Space direction="vertical" style={{ width: '100%' }}>
        <div style={{ 
          padding: '12px', 
          background: '#f0f2f5', 
          borderRadius: '6px',
          marginBottom: '16px'
        }}>
          <Space align="center">
            <Switch
              checked={zorunluPersonelAktif}
              onChange={handleZorunluPersonelChange}
            />
            <Text>Zorunlu personel ataması yap</Text>
          </Space>
          <div style={{ marginTop: '8px' }}>
            <Text type="secondary" style={{ fontSize: '12px' }}>
              Belirli personellerin bu siparişte çalışmasını zorunlu kılmak için aktifleştirin.
            </Text>
          </div>
        </div>

        {zorunluPersonelAktif && (
          <>
            <Alert
              message="Bilgi"
              description="Seçilen personeller bu siparişteki görevlere öncelikli olarak atanacaktır. Yetkinliği olmayan görevler için yetkin personel otomatik atanacaktır."
              type="info"
              showIcon
              style={{ marginBottom: '16px' }}
            />

            <div>
              {departmanlar?.map(departman => (
                <DepartmanPersonelSecici 
                  key={departman.id} 
                  departman={departman} 
                />
              ))}
            </div>

            {getSecilenPersonelSayisi() > 0 && (
              <div style={{ 
                marginTop: '16px',
                padding: '12px',
                background: '#f6ffed',
                border: '1px solid #b7eb8f',
                borderRadius: '6px'
              }}>
                <Text style={{ color: '#52c41a' }}>
                  ✅ {getSecilenPersonelSayisi()} personel zorunlu atama için seçildi
                </Text>
              </div>
            )}
          </>
        )}

        {!zorunluPersonelAktif && (
          <div style={{ 
            textAlign: 'center', 
            padding: '40px 20px',
            color: '#999'
          }}>
            <UserOutlined style={{ fontSize: '48px', marginBottom: '16px' }} />
            <div>
              <Text type="secondary">
                Zorunlu personel ataması yapılmayacak
              </Text>
              <br />
              <Text type="secondary" style={{ fontSize: '12px' }}>
                Sistem otomatik olarak yetkinlik ve iş yüküne göre personel ataması yapacak
              </Text>
            </div>
          </div>
        )}
      </Space>
    </Card>
  );
};

export default PersonelSecici;

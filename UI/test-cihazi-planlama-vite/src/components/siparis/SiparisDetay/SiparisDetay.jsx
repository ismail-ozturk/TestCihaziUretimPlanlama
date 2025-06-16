// src/components/siparis/SiparisDetay/SiparisDetay.jsx
import React from 'react';
import { Row, Col, Spin, Alert } from 'antd';
import { useSiparisDetay } from '../../../hooks/useSiparis';
import SiparisDetayKart from './SiparisDetayKart';
import GorevTablosu from './GorevTablosu';

const SiparisDetay = ({ siparisId }) => {
  const { data: siparisDetay, isLoading, error } = useSiparisDetay(siparisId);

  if (isLoading) {
    return (
      <div className="loading-container">
        <Spin size="large" />
        <p className="loading-text">Sipariş detayları yükleniyor...</p>
      </div>
    );
  }

  if (error) {
    return (
      <Alert
        message="Hata"
        description={`Sipariş detayları yüklenemedi: ${error.message}`}
        type="error"
        showIcon
        style={{ margin: '20px 0' }}
      />
    );
  }

  if (!siparisDetay) {
    return (
      <Alert
        message="Sipariş Bulunamadı"
        description="Belirtilen sipariş bulunamadı veya erişim izniniz yok."
        type="warning"
        showIcon
        style={{ margin: '20px 0' }}
      />
    );
  }

  return (
    <div className="siparis-detay-container slide-up">
      <Row gutter={[24, 24]}>
        {/* Sipariş Bilgileri - Küçültüldü */}
        <Col xs={8} xl={5} lg={8} md={24}>
          <SiparisDetayKart siparis={siparisDetay} />
        </Col>

        {/* Görev Tablosu - Büyütüldü */}
        <Col xs={24} xl={19} lg={16} md={24}>
          <GorevTablosu 
            siparisId={siparisId} 
            siparis={siparisDetay}
            gorevler={siparisDetay.uretimGorevleri}
          />
        </Col>
      </Row>
    </div>
  );
};

export default SiparisDetay;

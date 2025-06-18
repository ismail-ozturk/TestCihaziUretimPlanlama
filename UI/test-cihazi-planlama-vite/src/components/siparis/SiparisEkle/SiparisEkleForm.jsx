// src/components/siparis/SiparisEkle/SiparisEkleForm.jsx
import React, { useState, useEffect } from 'react';
import { 
  Form, 
  Input, 
  Select, 
  DatePicker, 
  Button, 
  Card, 
  Row, 
  Col, 
  Switch,
  Divider,
  Space,
  message,
  Spin,
  Alert
} from 'antd';
import { SaveOutlined, ReloadOutlined } from '@ant-design/icons';
import { useForm } from 'antd/es/form/Form';
import dayjs from 'dayjs';
import { useKategoriler, useKategoriSablon } from '../../../hooks/useKategori';
import { useSiparisOlustur } from '../../../hooks/useSiparis';
import { useTekSiparisPlanlama } from '../../../hooks/usePlanlama';
import GorevYoneticisi from './GorevYoneticisi';
import PersonelSecici from './PersonelSecici';

const { Option } = Select;
const { TextArea } = Input;

const SiparisEkleForm = () => {
  const [form] = useForm();
  const [selectedKategori, setSelectedKategori] = useState(null);
  const [sablonKullan, setSablonKullan] = useState(true);
  const [gorevler, setGorevler] = useState([]);
  const [bagimliliklar, setBagimliliklar] = useState([]);
  const [zorunluPersoneller, setZorunluPersoneller] = useState({});

  // Hooks
  const { data: kategoriler, isLoading: kategoriLoading } = useKategoriler();
  const { data: kategoriSablon, isLoading: sablonLoading } = useKategoriSablon(selectedKategori);
  const siparisOlustur = useSiparisOlustur();
  const siparisPlanlama = useTekSiparisPlanlama();
useEffect(() => {
  console.log('=== BACKEND VERİ KONTROLÜ ===');
  console.log('kategoriSablon:', kategoriSablon);
  console.log('gorevSablonlari var mı?', !!kategoriSablon?.gorevSablonlari);
  console.log('gorevSablonlari uzunluğu:', kategoriSablon?.gorevSablonlari?.length);
  console.log('bagimliliklar var mı?', !!kategoriSablon?.bagimliliklar);
  console.log('bagimliliklar uzunluğu:', kategoriSablon?.bagimliliklar?.length);
}, [kategoriSablon]);
  // Kategori seçildiğinde şablon görevlerini yükle - ID MAPPING İLE
 useEffect(() => {
  if (selectedKategori && kategoriSablon && kategoriSablon.gorevler) { // gorevler kullan!
    console.log('Kategori şablonu yüklendi:', kategoriSablon);
    
    // Görevleri benzersiz ID ile set et
    const sablonGorevleri = kategoriSablon.gorevler.map(sablon => ({
      id: `gorev_${sablon.id}_${Date.now()}`, // Benzersiz ID oluştur
      originalSablonId: sablon.id, // Orijinal şablon ID'sini sakla
      gorevId: sablon.gorevId,
      tempId: `temp_${sablon.id}_${Date.now()}`,
      sira: sablon.sira,
      gorevAdi: sablon.gorevAdi,
      departmanAdi: sablon.departmanAdi,
      sure: sablon.ozelSure || sablon.varsayilanSure,
      aciklama: sablon.gorevAciklama,
      sablondan: true
    }));
    setGorevler(sablonGorevleri);
    
    // Bağımlılıkları ID mapping ile set et
    if (kategoriSablon.bagimliliklar && kategoriSablon.bagimliliklar.length > 0) {
      const sablonBagimliliklar = kategoriSablon.bagimliliklar.map(bagimlilik => {
        // Şablon ID'lerini görev ID'lerine maple
        const oncuGorev = sablonGorevleri.find(g => g.originalSablonId === bagimlilik.oncuKategoriGorevSablonuId);
        const ardilGorev = sablonGorevleri.find(g => g.originalSablonId === bagimlilik.ardilKategoriGorevSablonuId);
        
        return {
          id: `bagimlilik_${bagimlilik.id}_${Date.now()}`, // Benzersiz bağımlılık ID
          originalBagimlilikId: bagimlilik.id, // Orijinal bağımlılık ID
          oncuUretimGoreviId: oncuGorev?.id, // Yeni görev ID'si
          ardilUretimGoreviId: ardilGorev?.id, // Yeni görev ID'si
          oncuKategoriGorevSablonuId: bagimlilik.oncuKategoriGorevSablonuId,
          ardilKategoriGorevSablonuId: bagimlilik.ardilKategoriGorevSablonuId,
          bagimlilikTipi: bagimlilik.bagimlilikTipiText || 'FinishToStart',
          bagimlilikTipiNumeric: bagimlilik.bagimlilikTipi,
          gecikmeGunu: bagimlilik.gecikmeGunu || 0,
          oncuGorevAdi: bagimlilik.oncuGorevAdi,
          ardilGorevAdi: bagimlilik.ardilGorevAdi,
          oncuGorevSira: bagimlilik.oncuGorevSira,
          ardilGorevSira: bagimlilik.ardilGorevSira
        };
      }).filter(b => b.oncuUretimGoreviId && b.ardilUretimGoreviId);
      
      setBagimliliklar(sablonBagimliliklar);
      console.log('ID mapping ile bağımlılıklar yüklendi:', sablonBagimliliklar);
    }
    
    message.success(`${sablonGorevleri.length} görev ve ${kategoriSablon.bagimliliklar?.length || 0} bağımlılık yüklendi`);
  } else if (!selectedKategori) {
    setGorevler([]);
    setBagimliliklar([]);
  }
}, [selectedKategori, kategoriSablon]);

  const handleKategoriChange = (kategoriId) => {
    setSelectedKategori(kategoriId);
    setSablonKullan(true);
  };

  const handleSablonKullanChange = (checked) => {
    setSablonKullan(checked);
  };

  const handleGorevlerChange = (yeniGorevler) => {
    setGorevler([...yeniGorevler]);
  };

  // Bağımlılık yönetimi fonksiyonları - ID tabanlı
  const handleBagimlilikEkle = (yeniBagimlilik) => {
    setBagimliliklar(prev => [...prev, yeniBagimlilik]);
    message.success('Bağımlılık eklendi');
  };

  const handleBagimlilikSil = (bagimlilikId) => {
    setBagimliliklar(prev => prev.filter(b => b.id !== bagimlilikId));
    message.success('Bağımlılık silindi');
  };

  const handleFormSubmit = async (values) => {
    try {
      const siparisData = {
        uretimNumarasi: values.uretimNumarasi,
        musteri: values.musteri,
        istenilenBaslangicTarihi: values.istenilenBaslangicTarihi.toISOString(),
        kategoriId: values.kategoriId || null,
        kategoriSablonuKullan: sablonKullan,
        notlar: values.notlar || '',
        oncelik: values.oncelik || 5,
        zorunluPersoneller: zorunluPersoneller
      };

      // Sadece şablon kullanılmıyorsa görevleri ve bağımlılıkları gönder
      if (!sablonKullan || !selectedKategori) {
        siparisData.gorevler = gorevler.map(gorev => {
          const { tempId, sablondan, originalSablonId, ...cleanGorev } = gorev;
          return cleanGorev;
        });
        siparisData.bagimliliklar = bagimliliklar.map(b => {
          const { id, originalBagimlilikId, oncuKategoriGorevSablonuId, ardilKategoriGorevSablonuId, ...cleanBagimlilik } = b;
          return cleanBagimlilik;
        });
      }

      console.log('Gönderilecek sipariş verisi:', siparisData);

      // 1. Önce siparişi oluştur
      const yeniSiparis = await siparisOlustur.mutateAsync(siparisData);
      
      // 2. Sonra otomatik planla
      if (yeniSiparis && yeniSiparis.id) {
        await siparisPlanlama.mutateAsync(yeniSiparis.id);
      }
      
      // Form'u temizle
      form.resetFields();
      setSelectedKategori(null);
      setSablonKullan(true);
      setGorevler([]);
      setBagimliliklar([]);
      setZorunluPersoneller({});
      
    } catch (error) {
      message.error(`İşlem tamamlanamadı: ${error.message}`);
    }
  };

  const handleFormTemizle = () => {
    form.resetFields();
    setSelectedKategori(null);
    setSablonKullan(true);
    setGorevler([]);
    setBagimliliklar([]);
    setZorunluPersoneller({});
    message.info('Form temizlendi');
  };

  // Form submit durumu
  const isSubmitting = siparisOlustur.isPending || siparisPlanlama.isPending;
  const submitButtonText = siparisOlustur.isPending ? 'Sipariş Oluşturuluyor...' : 
                          siparisPlanlama.isPending ? 'Planlama Yapılıyor...' : 
                          'Siparişi Oluştur ve Planla';

  return (
    <div style={{ maxWidth: '1200px', margin: '0 auto' }}>
      <Card title="Yeni Sipariş Oluştur" style={{ marginBottom: '24px' }}>
        <Form
          form={form}
          layout="vertical"
          onFinish={handleFormSubmit}
          initialValues={{
            istenilenBaslangicTarihi: dayjs(),
            musteri: 1,
            oncelik: 5
          }}
        >
          <Row gutter={24}>
            {/* Sol Kolon - Temel Bilgiler */}
            <Col xs={24} lg={12}>
              <Card title="Temel Bilgiler" size="small" style={{ height: '100%' }}>
                <Form.Item
                  name="uretimNumarasi"
                  label="Üretim Numarası"
                  rules={[
                    { required: true, message: 'Üretim numarası gerekli!' },
                    { min: 3, message: 'En az 3 karakter olmalı!' }
                  ]}
                >
                  <Input 
                    placeholder="Örn: PG1006" 
                    size="large"
                  />
                </Form.Item>

                <Form.Item
                  name="musteri"
                  label="Müşteri"
                  rules={[{ required: true, message: 'Müşteri seçimi gerekli!' }]}
                >
                  <Select size="large" placeholder="Müşteri seçin">
                    <Option value={1}>🇩🇪 Almanya</Option>
                    <Option value={2}>🇹🇷 Türkiye</Option>
                  </Select>
                </Form.Item>

                <Form.Item
                  name="istenilenBaslangicTarihi"
                  label="İstenilen Başlangıç Tarihi"
                  rules={[{ required: true, message: 'Başlangıç tarihi gerekli!' }]}
                >
                  <DatePicker 
                    showTime 
                    size="large"
                    style={{ width: '100%' }}
                    format="DD.MM.YYYY HH:mm"
                  />
                </Form.Item>

                <Row gutter={16}>
                  <Col span={16}>
                    <Form.Item
                      name="kategoriId"
                      label="Kategori (Opsiyonel)"
                    >
                      <Select 
                        size="large"
                        placeholder="Kategori seçin"
                        loading={kategoriLoading}
                        onChange={handleKategoriChange}
                        allowClear
                      >
                        {kategoriler?.map(kategori => (
                          <Option key={kategori.id} value={kategori.id}>
                            {kategori.ad}
                          </Option>
                        ))}
                      </Select>
                    </Form.Item>
                  </Col>
                  <Col span={8}>
                    <Form.Item
                      name="oncelik"
                      label="Öncelik"
                    >
                      <Select size="large">
                        <Option value={1}>🔴 Çok Yüksek</Option>
                        <Option value={3}>🟠 Yüksek</Option>
                        <Option value={5}>🟡 Normal</Option>
                        <Option value={7}>🟢 Düşük</Option>
                        <Option value={9}>⚪ Çok Düşük</Option>
                      </Select>
                    </Form.Item>
                  </Col>
                </Row>

                {selectedKategori && (
                  <Form.Item label="Kategori Şablonu">
                    <Space align="center">
                      <Switch
                        checked={sablonKullan}
                        onChange={handleSablonKullanChange}
                        loading={sablonLoading}
                      />
                      <span>Kategori şablonunu kullan</span>
                      {sablonLoading && <Spin size="small" />}
                    </Space>
                    <div style={{ marginTop: '8px' }}>
                      <Alert
                        message={sablonKullan ? 
                          "Şablon aktif: Görevler backend'den otomatik oluşturulacak" : 
                          "Manuel mod: Tüm görev değişiklikleri backend'e gönderilecek"
                        }
                        type={sablonKullan ? "success" : "info"}
                        showIcon
                        size="small"
                      />
                    </div>
                  </Form.Item>
                )}

                <Form.Item
                  name="notlar"
                  label="Notlar"
                >
                  <TextArea 
                    rows={3} 
                    placeholder="Sipariş ile ilgili notlar..."
                  />
                </Form.Item>
              </Card>
            </Col>

            {/* Sağ Kolon - Personel Seçimi */}
            <Col xs={24} lg={12}>
              <PersonelSecici
                zorunluPersoneller={zorunluPersoneller}
                onChange={setZorunluPersoneller}
              />
            </Col>
          </Row>

          <Divider />

          {/* Görev Yönetimi */}
          <GorevYoneticisi
            gorevler={gorevler || []}
            bagimliliklar={bagimliliklar || []}
            onChange={handleGorevlerChange}
            onBagimlilikEkle={handleBagimlilikEkle}
            onBagimlilikSil={handleBagimlilikSil}
            kategoriId={selectedKategori}
            sablonKullan={sablonKullan || false}
          />

          <Divider />

          {/* Submit Butonları */}
          <Row justify="end" gutter={16}>
            <Col>
              <Button 
                size="large"
                icon={<ReloadOutlined />}
                onClick={handleFormTemizle}
                disabled={isSubmitting}
              >
                Temizle
              </Button>
            </Col>
            <Col>
              <Button
                type="primary"
                size="large"
                htmlType="submit"
                icon={<SaveOutlined />}
                loading={isSubmitting}
                disabled={
                  sablonKullan ? !selectedKategori : gorevler.length === 0
                }
              >
                {submitButtonText}
              </Button>
            </Col>
          </Row>
        </Form>
      </Card>
    </div>
  );
};

export default SiparisEkleForm;

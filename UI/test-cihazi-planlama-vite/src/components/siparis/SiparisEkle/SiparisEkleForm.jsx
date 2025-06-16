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
  const [bagimliliklar, setBagimliliklar] = useState([]); // Bağımlılık state'i eklendi
  const [zorunluPersoneller, setZorunluPersoneller] = useState({});

  // Hooks
  const { data: kategoriler, isLoading: kategoriLoading } = useKategoriler();
  const { data: kategoriSablon, isLoading: sablonLoading } = useKategoriSablon(selectedKategori);
  const siparisOlustur = useSiparisOlustur();
  const siparisPlanlama = useTekSiparisPlanlama();

  // Kategori seçildiğinde şablon görevlerini yükle
  useEffect(() => {
    if (selectedKategori && kategoriSablon && kategoriSablon.gorevler) {
      // Kategori seçildiğinde DAIMA şablon görevlerini yükle
      const sablonGorevleri = kategoriSablon.gorevler.map(sablon => ({
        id: sablon.id,
        gorevId: sablon.gorevId,
        gorevAdi: sablon.gorevAdi,
        aciklama: sablon.gorevAciklama,
        departmanAdi: sablon.departmanAdi,
        sure: sablon.ozelSure || sablon.varsayilanSure,
        sira: sablon.sira,
        durum: 'Beklemede',
        bagimliliklar: [],
        sablondan: true // Şablondan geldiğini işaretle
      }));

      setGorevler(sablonGorevleri);
      
      // Bağımlılıkları da yükle
      if (kategoriSablon.bagimliliklar) {
        const sablonBagimliliklar = kategoriSablon.bagimliliklar.map(bagimlilik => ({
          ...bagimlilik,
          id: `temp_${Date.now()}_${Math.random()}`
        }));
        setBagimliliklar(sablonBagimliliklar);
      }
      
      message.success(`${sablonGorevleri.length} görev şablondan yüklendi`);
    } else if (!selectedKategori) {
      // Kategori seçimi kaldırıldığında görevleri temizle
      setGorevler([]);
      setBagimliliklar([]);
    }
  }, [selectedKategori, kategoriSablon]);

  const handleKategoriChange = (kategoriId) => {
    setSelectedKategori(kategoriId);
    // Toggle'ı varsayılan olarak açık yap
    setSablonKullan(true);
  };

  const handleSablonKullanChange = (checked) => {
    setSablonKullan(checked);
    // Toggle değişikliğinde görevleri ASLA temizleme
    // Sadece UI'da düzenleme imkanını aç/kapat
  };

  const handleGorevlerChange = (yeniGorevler) => {
    setGorevler([...yeniGorevler]);
  };

  // Bağımlılık yönetimi fonksiyonları
  const handleBagimlilikEkle = (oncuGorevSira, ardilGorevSira, bagimlilikTipi) => {
    const yeniBagimlilik = {
      id: `temp_${Date.now()}_${Math.random()}`,
      oncuGorevSira,
      ardilGorevSira,
      bagimlilikTipi
    };
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
        siparisData.gorevler = gorevler;
        siparisData.bagimliliklar = bagimliliklar.map(b => {
          const { id, ...cleanBagimlilik } = b;
          return cleanBagimlilik;
        });
      }
      // Şablon kullanılıyorsa backend kategoriId'den görevleri otomatik oluşturacak

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
            gorevler={gorevler}
            bagimliliklar={bagimliliklar}
            onChange={handleGorevlerChange}
            onBagimlilikEkle={handleBagimlilikEkle}
            onBagimlilikSil={handleBagimlilikSil}
            kategoriId={selectedKategori}
            sablonKullan={sablonKullan}
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

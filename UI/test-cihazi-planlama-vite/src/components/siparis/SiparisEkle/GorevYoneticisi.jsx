// src/components/siparis/SiparisEkle/GorevYoneticisi.jsx
import React, { useState, useEffect } from 'react';
import { 
  Card, 
  Table, 
  Button, 
  Space, 
  Modal, 
  Select, 
  Row, 
  Col, 
  Alert,
  Tag,
  Divider,
  message,
  Form,
  Input,
  InputNumber,
  Switch
} from 'antd';
import { 
  PlusOutlined, 
  DeleteOutlined, 
  LinkOutlined,
  SortAscendingOutlined
} from '@ant-design/icons';

const { Option } = Select;

const GorevYoneticisi = ({ 
  gorevler = [],
  bagimliliklar = [],
  onChange, 
  onBagimlilikEkle, 
  onBagimlilikSil, 
  kategoriId, 
  sablonKullan = false
}) => {
  const [bagimlilikModalVisible, setBagimlilikModalVisible] = useState(false);
  const [manuelIsModalVisible, setManuelIsModalVisible] = useState(false);
  const [selectedGorev, setSelectedGorev] = useState(null);
  const [oncuGorevId, setOncuGorevId] = useState(null); // ID tabanlı
  const [bagimlilikTipi, setBagimlilikTipi] = useState('FinishToStart');
  const [gecikmeGunu, setGecikmeGunu] = useState(0);
  const [otomatikSiralama, setOtomatikSiralama] = useState(true);
  const [manuelIsForm] = Form.useForm();

  const safeGorevler = Array.isArray(gorevler) ? gorevler : [];
  const safeBagimliliklar = Array.isArray(bagimliliklar) ? bagimliliklar : [];

  // Debug için optimize edilmiş log
  useEffect(() => {
    if (process.env.NODE_ENV === 'development') {
      console.log('=== GÖREV YÖNETİCİSİ DEBUG ===');
      console.log('Görev sayısı:', safeGorevler.length);
      console.log('Bağımlılık sayısı:', safeBagimliliklar.length);
      console.log('Şablon kullanımı:', sablonKullan);
    }
  }, [safeGorevler.length, safeBagimliliklar.length, sablonKullan]);

  // Bağımlılık tipi normalizasyonu
  const normalizeBagimlilikTipi = (tip) => {
    const tipMap = {
      1: 'FinishToStart',
      2: 'StartToStart', 
      3: 'FinishToFinish',
      4: 'StartToFinish',
      'FinishToStart': 'FinishToStart',
      'StartToStart': 'StartToStart',
      'FinishToFinish': 'FinishToFinish',
      'StartToFinish': 'StartToFinish'
    };
    return tipMap[tip] || 'FinishToStart';
  };

  // Topological Sort - Backend algoritmasına uygun
  const topologicalSort = (gorevler, bagimliliklar) => {
    try {
      const gorevDict = {};
      const ardillar = {};
      const oncuSayilari = {};
      
      // Initialize
      gorevler.forEach(gorev => {
        const gorevId = gorev.id;
        if (!gorevId) return;
        
        gorevDict[gorevId] = gorev;
        ardillar[gorevId] = [];
        oncuSayilari[gorevId] = 0;
      });

      // Build adjacency list
      bagimliliklar.forEach(bagimlilik => {
        const oncuId = bagimlilik.oncuUretimGoreviId || bagimlilik.oncuGorevId;
        const ardilId = bagimlilik.ardilUretimGoreviId || bagimlilik.ardilGorevId;
        
        if (gorevDict[oncuId] && gorevDict[ardilId]) {
          ardillar[oncuId].push(ardilId);
          oncuSayilari[ardilId]++;
        }
      });

      // Kahn's algorithm
      const queue = [];
      const result = [];
      
      Object.keys(oncuSayilari).forEach(gorevId => {
        if (oncuSayilari[gorevId] === 0) {
          queue.push(gorevId);
        }
      });

      while (queue.length > 0) {
        const currentId = queue.shift();
        result.push(gorevDict[currentId]);
        
        ardillar[currentId].forEach(ardilId => {
          oncuSayilari[ardilId]--;
          if (oncuSayilari[ardilId] === 0) {
            queue.push(ardilId);
          }
        });
      }

      if (result.length !== gorevler.length) {
        console.warn('Döngüsel bağımlılık tespit edildi!');
        return gorevler.sort((a, b) => (a.sira || 0) - (b.sira || 0));
      }

      return result;
    } catch (error) {
      console.error('Topological sort hatası:', error);
      return gorevler.sort((a, b) => (a.sira || 0) - (b.sira || 0));
    }
  };

  // Otomatik sıralama uygula
  const getSiraliGorevler = () => {
    if (!otomatikSiralama) {
      return safeGorevler.sort((a, b) => (a.sira || 0) - (b.sira || 0));
    }
    
    return topologicalSort(safeGorevler, safeBagimliliklar);
  };

  // ID tabanlı bağımlılık kontrolü
  const bagimlilikVarMi = (oncuGorevId, ardilGorevId, bagimlilikTipi) => {
    const normalizedYeniTip = normalizeBagimlilikTipi(bagimlilikTipi);

    return safeBagimliliklar.some(b => {
      if (!b) return false;
      
      const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
      const ardilId = b.ardilUretimGoreviId || b.ardilGorevId;
      const normalizedMevcutTip = normalizeBagimlilikTipi(b.bagimlilikTipi || b.bagimlilikTipiText);
      
      return (
        oncuId === oncuGorevId && 
        ardilId === ardilGorevId && 
        normalizedMevcutTip === normalizedYeniTip
      );
    });
  };

  // ID tabanlı ters bağımlılık kontrolü
  const tersBagimlilikVarMi = (oncuGorevId, ardilGorevId) => {
    return safeBagimliliklar.some(b => {
      if (!b) return false;
      const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
      const ardilId = b.ardilUretimGoreviId || b.ardilGorevId;
      return oncuId === ardilGorevId && ardilId === oncuGorevId;
    });
  };

  // ID tabanlı döngüsel bağımlılık kontrolü
  const dolayli_dongusel_bagimlilik_var_mi = (oncuGorevId, ardilGorevId) => {
    const visited = new Set();
    const tempVisited = new Set();
    
    const dfs = (currentId, targetId) => {
      if (tempVisited.has(currentId)) return true;
      if (visited.has(currentId)) return false;
      
      tempVisited.add(currentId);
      
      const ardilBagimliliklar = safeBagimliliklar.filter(b => {
        const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
        return oncuId === currentId;
      });
      
      for (const bagimlilik of ardilBagimliliklar) {
        const ardilId = bagimlilik.ardilUretimGoreviId || bagimlilik.ardilGorevId;
        if (dfs(ardilId, targetId)) {
          return true;
        }
      }
      
      tempVisited.delete(currentId);
      visited.add(currentId);
      return false;
    };
    
    return dfs(ardilGorevId, oncuGorevId);
  };

  // Manuel iş ekleme
  const handleManuelIsEkle = async (values) => {
    try {
      const maxSira = Math.max(...safeGorevler.map(g => g.sira || 0), 0);
      const yeniSira = maxSira + 1;
      const yeniId = `manuel_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
      
      const yeniGorev = {
        id: yeniId,
        tempId: yeniId,
        sira: yeniSira,
        gorevAdi: values.gorevAdi,
        departmanAdi: values.departmanAdi,
        sure: values.sure,
        aciklama: values.aciklama || '',
        manuelEklenen: true,
        originalSablonId: null
      };
      
      const yeniGorevler = [...safeGorevler, yeniGorev];
      onChange(yeniGorevler);
      
      manuelIsForm.resetFields();
      setManuelIsModalVisible(false);
      
      message.success(`Manuel iş başarıyla eklendi: "${values.gorevAdi}"`);
    } catch (error) {
      console.error('Manuel iş ekleme hatası:', error);
      message.error('Manuel iş eklenirken hata oluştu');
    }
  };

  const handleBagimlilikDuzenle = (gorev) => {
    setSelectedGorev(gorev);
    setBagimlilikModalVisible(true);
    setOncuGorevId(null);
    setBagimlilikTipi('FinishToStart');
    setGecikmeGunu(0);
  };

  const handleBagimlilikEkle = () => {
    if (!oncuGorevId || !onBagimlilikEkle) {
      message.error('Lütfen öncül görev seçin');
      return;
    }

    try {
      const oncuGorev = safeGorevler.find(g => g.id === oncuGorevId);
      const ardilGorevId = selectedGorev.id;
      
      if (!oncuGorev) {
        message.error('Öncül görev bulunamadı');
        return;
      }

      // 1. Aynı görev kontrolü
      if (oncuGorevId === ardilGorevId) {
        message.error('Bir görev kendisine bağımlı olamaz!');
        return;
      }

      // 2. Mevcut bağımlılık kontrolü
      if (bagimlilikVarMi(oncuGorevId, ardilGorevId, bagimlilikTipi)) {
        message.warning(`Bu bağımlılık zaten mevcut: "${oncuGorev.gorevAdi}" → "${selectedGorev.gorevAdi}"`);
        return;
      }

      // 3. Ters bağımlılık kontrolü
      if (tersBagimlilikVarMi(oncuGorevId, ardilGorevId)) {
        message.error(`Ters bağımlılık mevcut! "${selectedGorev.gorevAdi}" → "${oncuGorev.gorevAdi}" bağımlılığı zaten var.`);
        return;
      }

      // 4. Dolaylı döngüsel bağımlılık kontrolü
      if (dolayli_dongusel_bagimlilik_var_mi(oncuGorevId, ardilGorevId)) {
        message.error(`Bu bağımlılık döngüsel bir yapı oluşturacak! "${oncuGorev.gorevAdi}" → "${selectedGorev.gorevAdi}" bağımlılığı eklenemez.`);
        return;
      }

      // Backend'e uygun format
      const yeniBagimlilik = {
        id: `bagimlilik_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`,
        oncuUretimGoreviId: oncuGorevId,
        ardilUretimGoreviId: ardilGorevId,
        bagimlilikTipi: bagimlilikTipi,
        bagimlilikTipiText: bagimlilikTipi,
        gecikmeGunu: gecikmeGunu || 0,
        oncuGorevAdi: oncuGorev.gorevAdi,
        ardilGorevAdi: selectedGorev.gorevAdi,
        oncuGorevSira: oncuGorev.sira,
        ardilGorevSira: selectedGorev.sira,
        manuelEklenen: true
      };

      onBagimlilikEkle(yeniBagimlilik);
      setOncuGorevId(null);
      setGecikmeGunu(0);
      
      message.success(`Bağımlılık başarıyla eklendi: "${oncuGorev.gorevAdi}" → "${selectedGorev.gorevAdi}"`);
    } catch (error) {
      console.error('Bağımlılık ekleme hatası:', error);
      message.error('Bağımlılık eklenirken hata oluştu');
    }
  };

  const getGorevBagimliliklar = (gorevId) => {
    return safeBagimliliklar.filter(b => {
      if (!b) return false;
      
      const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
      const ardilId = b.ardilUretimGoreviId || b.ardilGorevId;
      
      return oncuId === gorevId || ardilId === gorevId;
    });
  };

  const gorevColumns = [
    {
      title: 'Sıra',
      dataIndex: 'sira',
      key: 'sira',
      width: 60,
      render: (sira, record, index) => (
        <div>
          {otomatikSiralama ? (
            <Tag color="blue">{index + 1}</Tag>
          ) : (
            <Tag color="default">{sira}</Tag>
          )}
        </div>
      ),
    },
    {
      title: 'Görev Adı',
      dataIndex: 'gorevAdi',
      key: 'gorevAdi',
      width: 200,
      render: (text, record) => (
        <div>
          {text || 'Görev Adı Yok'}
          {record.manuelEklenen && (
            <Tag color="purple" size="small" style={{ marginLeft: '8px' }}>
              Manuel
            </Tag>
          )}
        </div>
      ),
    },
    {
      title: 'Departman',
      dataIndex: 'departmanAdi',
      key: 'departmanAdi',
      width: 120,
      render: (text) => text || 'Departman Yok',
    },
    {
      title: 'Süre (Saat)',
      dataIndex: 'sure',
      key: 'sure',
      width: 100,
      align: 'center',
      render: (sure) => sure || 0,
    },
    {
      title: 'Açıklama',
      dataIndex: 'aciklama',
      key: 'aciklama',
      ellipsis: true,
      render: (text) => text || '-',
    },
    {
      title: 'Bağımlılıklar',
      key: 'bagimliliklar',
      width: 120,
      render: (_, record) => {
        const gorevId = record.id;
        const gorevBagimliliklar = getGorevBagimliliklar(gorevId);
        return (
          <div>
            {gorevBagimliliklar.length > 0 ? (
              <Tag color="blue">{gorevBagimliliklar.length}</Tag>
            ) : (
              <Tag color="default">0</Tag>
            )}
          </div>
        );
      },
    },
    {
      title: 'İşlemler',
      key: 'actions',
      width: 150,
      render: (_, record) => (
        <Space size="small">
          <Button
            size="small"
            icon={<LinkOutlined />}
            onClick={() => handleBagimlilikDuzenle(record)}
            title={sablonKullan ? "Bağımlılıkları Görüntüle" : "Bağımlılık Düzenle"}
          >
            Bağımlılık
          </Button>
          {!sablonKullan && (
            <Button
              size="small"
              danger
              onClick={() => {
                if (onChange && record) {
                  const gorevId = record.id;
                  const yeniGorevler = safeGorevler.filter(g => g.id !== gorevId);
                  onChange(yeniGorevler);
                  
                  const silinecekBagimliliklar = safeBagimliliklar.filter(b => {
                    const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
                    const ardilId = b.ardilUretimGoreviId || b.ardilGorevId;
                    return oncuId === gorevId || ardilId === gorevId;
                  });
                  
                  silinecekBagimliliklar.forEach(b => {
                    if (onBagimlilikSil && b.id) {
                      onBagimlilikSil(b.id);
                    }
                  });
                  
                  message.success(`Görev silindi: ${record.gorevAdi}`);
                }
              }}
              icon={<DeleteOutlined />}
            >
              Sil
            </Button>
          )}
        </Space>
      ),
    }
  ];

  return (
    <>
      <Card 
        title={
          <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            <span>Görev Yönetimi ({getSiraliGorevler().length} görev)</span>
            <Space>
              <div style={{ display: 'flex', alignItems: 'center' }}>
                <SortAscendingOutlined style={{ marginRight: '8px' }} />
                <span style={{ marginRight: '8px' }}>Otomatik Sıralama:</span>
                <Switch
                  checked={otomatikSiralama}
                  onChange={setOtomatikSiralama}
                  size="small"
                />
              </div>
            </Space>
          </div>
        }
        extra={
          !sablonKullan && (
            <Button
              type="dashed"
              icon={<PlusOutlined />}
              onClick={() => setManuelIsModalVisible(true)}
            >
              Manuel İş Ekle
            </Button>
          )
        }
        style={{ marginBottom: '24px' }}
      >
        {otomatikSiralama && (
          <Alert
            message="Otomatik Sıralama Aktif"
            description="Görevler bağımlılık ilişkilerine göre otomatik olarak sıralanıyor. Backend'deki topological sort algoritması kullanılıyor."
            type="info"
            showIcon
            style={{ marginBottom: '16px' }}
            closable
          />
        )}

        {getSiraliGorevler().length > 0 ? (
          <Table
            columns={gorevColumns}
            dataSource={getSiraliGorevler()}
            rowKey={(record) => record?.id || record?.tempId || Math.random()}
            pagination={false}
            size="small"
            scroll={{ x: 900 }}
          />
        ) : (
          <Alert
            message="Henüz görev bulunmuyor"
            description={
              kategoriId ? 
                "Kategori şablonu yükleniyor veya şablon kullanımı kapalı." : 
                "Kategori seçin veya manuel görev ekleyin."
            }
            type="info"
            showIcon
          />
        )}
      </Card>

      {safeBagimliliklar.length > 0 && (
        <Card 
          title={`Görev Bağımlılıkları (${safeBagimliliklar.length} bağımlılık)`}
          style={{ marginBottom: '24px' }}
        >
          <div style={{ padding: '16px' }}>
            <Alert
              message="Bağımlılık Özeti"
              description={`Toplam ${safeBagimliliklar.length} bağımlılık tanımlanmış. Detayları görmek için görevlerin 'Bağımlılık' butonuna tıklayın.`}
              type="info"
              showIcon
            />
          </div>
        </Card>
      )}

      {/* Manuel İş Ekleme Modal'ı */}
      <Modal
        title="Manuel İş Ekle"
        open={manuelIsModalVisible}
        onCancel={() => {
          setManuelIsModalVisible(false);
          manuelIsForm.resetFields();
        }}
        footer={null}
        width={600}
      >
        <Form
          form={manuelIsForm}
          layout="vertical"
          onFinish={handleManuelIsEkle}
        >
          <Alert
            message="Manuel İş Ekleme"
            description="Bu iş kategori şablonunda bulunmayan özel bir iştir. Benzersiz ID ile oluşturulacak ve bağımlılık sisteminde kullanılabilecektir."
            type="info"
            showIcon
            style={{ marginBottom: '16px' }}
          />

          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                name="gorevAdi"
                label="Görev Adı"
                rules={[
                  { required: true, message: 'Görev adı gerekli!' },
                  { min: 3, message: 'En az 3 karakter olmalı!' }
                ]}
              >
                <Input placeholder="Örn: Özel Test İşlemi" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item
                name="departmanAdi"
                label="Departman"
                rules={[{ required: true, message: 'Departman seçimi gerekli!' }]}
              >
                <Select placeholder="Departman seçin">
                  <Option value="PMD">PMD</Option>
                  <Option value="CNC">CNC</Option>
                  <Option value="Teknik">Teknik</Option>
                  <Option value="Kalite">Kalite</Option>
                  <Option value="Montaj">Montaj</Option>
                </Select>
              </Form.Item>
            </Col>
          </Row>

          <Row gutter={16}>
            <Col span={12}>
              <Form.Item
                name="sure"
                label="Süre (Saat)"
                rules={[
                  { required: true, message: 'Süre gerekli!' },
                  { type: 'number', min: 0.5, message: 'En az 0.5 saat olmalı!' }
                ]}
              >
                <InputNumber
                  min={0.5}
                  max={100}
                  step={0.5}
                  style={{ width: '100%' }}
                  placeholder="Örn: 2.5"
                />
              </Form.Item>
            </Col>
            <Col span={12}>
              <div style={{ paddingTop: '30px' }}>
                <Tag color="green">Benzersiz ID ile oluşturulacak</Tag>
              </div>
            </Col>
          </Row>

          <Form.Item
            name="aciklama"
            label="Açıklama (Opsiyonel)"
          >
            <Input.TextArea
              rows={3}
              placeholder="İş ile ilgili detaylar..."
            />
          </Form.Item>

          <div style={{ textAlign: 'right' }}>
            <Space>
              <Button onClick={() => {
                setManuelIsModalVisible(false);
                manuelIsForm.resetFields();
              }}>
                İptal
              </Button>
              <Button type="primary" htmlType="submit">
                İş Ekle
              </Button>
            </Space>
          </div>
        </Form>
      </Modal>

      {/* Bağımlılık Düzenleme Modal'ı */}
      <Modal
        title={`${sablonKullan ? 'Bağımlılıkları Görüntüle' : 'Bağımlılık Düzenle'}: ${selectedGorev?.gorevAdi || 'Görev'}`}
        open={bagimlilikModalVisible}
        onCancel={() => setBagimlilikModalVisible(false)}
        footer={null}
        width={700}
      >
        {selectedGorev && (
          <div>
            {!sablonKullan && (
              <>
                <Card title="Yeni Bağımlılık Ekle" size="small" style={{ marginBottom: '16px' }}>
                  <Alert
                    message="ID Tabanlı Bağımlılık Sistemi"
                    description="• Backend'deki planlama algoritmasına uygun ID tabanlı sistem • Gecikme günü parametresi desteklenir • Topological sort ile otomatik sıralama"
                    type="info"
                    showIcon
                    style={{ marginBottom: '16px' }}
                    closable
                  />
                  
                  <Row gutter={16}>
                    <Col span={8}>
                      <label>Öncül Görev:</label>
                      <Select
                        value={oncuGorevId}
                        onChange={setOncuGorevId}
                        style={{ width: '100%' }}
                        placeholder="Öncül görev seçin"
                        showSearch
                        optionFilterProp="children"
                      >
                        {safeGorevler
                          .filter(g => g.id !== selectedGorev.id)
                          .map(g => (
                            <Option key={g.id} value={g.id}>
                              <Space>
                                <span>{g.sira}. {g.gorevAdi}</span>
                                {g.manuelEklenen && <Tag color="purple" size="small">Manuel</Tag>}
                              </Space>
                            </Option>
                          ))}
                      </Select>
                    </Col>
                    <Col span={8}>
                      <label>Bağımlılık Tipi:</label>
                      <Select
                        value={bagimlilikTipi}
                        onChange={setBagimlilikTipi}
                        style={{ width: '100%' }}
                      >
                        <Option value="FinishToStart">Bitiş → Başlangıç</Option>
                        <Option value="StartToStart">Başlangıç → Başlangıç</Option>
                        <Option value="FinishToFinish">Bitiş → Bitiş</Option>
                        <Option value="StartToFinish">Başlangıç → Bitiş</Option>
                      </Select>
                    </Col>
                    <Col span={8}>
                      <label>Gecikme (Gün):</label>
                      <InputNumber
                        min={0}
                        max={30}
                        value={gecikmeGunu}
                        onChange={setGecikmeGunu}
                        style={{ width: '100%' }}
                        placeholder="0"
                      />
                    </Col>
                  </Row>
                  <div style={{ marginTop: '16px', textAlign: 'right' }}>
                    <Button 
                      type="primary" 
                      onClick={handleBagimlilikEkle}
                      disabled={!oncuGorevId}
                    >
                      Bağımlılık Ekle
                    </Button>
                  </div>
                </Card>
                <Divider />
              </>
            )}

            <Card title="Bu Görevle İlgili Bağımlılıklar" size="small">
              {(() => {
                const selectedGorevId = selectedGorev.id;
                const oncuBagimliliklar = safeBagimliliklar.filter(b => {
                  const ardilId = b.ardilUretimGoreviId || b.ardilGorevId;
                  return ardilId === selectedGorevId;
                });
                const ardilBagimliliklar = safeBagimliliklar.filter(b => {
                  const oncuId = b.oncuUretimGoreviId || b.oncuGorevId;
                  return oncuId === selectedGorevId;
                });

                return (
                  <div>
                    <div style={{ marginBottom: '24px' }}>
                      <h4 style={{ 
                        marginBottom: '12px', 
                        color: '#1890ff',
                        borderBottom: '1px solid #f0f0f0',
                        paddingBottom: '8px'
                      }}>
                        Öncül Görevler:
                      </h4>
                      {oncuBagimliliklar.length > 0 ? (
                        <div>
                          {oncuBagimliliklar.map(bagimlilik => {
                            const oncuId = bagimlilik.oncuUretimGoreviId || bagimlilik.oncuGorevId;
                            const oncuGorev = safeGorevler.find(g => g.id === oncuId);
                            return (
                              <div key={bagimlilik.id} style={{ 
                                display: 'flex', 
                                justifyContent: 'space-between', 
                                alignItems: 'center',
                                padding: '8px 12px',
                                background: '#f6f6f6',
                                borderRadius: '6px',
                                marginBottom: '8px'
                              }}>
                                <div>
                                  <Tag color="orange" style={{ marginRight: '8px' }}>
                                    {oncuGorev?.sira || 'N/A'}
                                  </Tag>
                                  <span style={{ fontWeight: 500 }}>
                                    {oncuGorev ? oncuGorev.gorevAdi : `Görev ${oncuId}`}
                                  </span>
                                  {oncuGorev?.manuelEklenen && (
                                    <Tag color="purple" size="small" style={{ marginLeft: '8px' }}>
                                      Manuel
                                    </Tag>
                                  )}
                                  <div style={{ fontSize: '12px', color: '#666', marginTop: '4px' }}>
                                    Tip: {normalizeBagimlilikTipi(bagimlilik.bagimlilikTipi || bagimlilik.bagimlilikTipiText)}
                                    {bagimlilik.gecikmeGunu > 0 && ` • Gecikme: ${bagimlilik.gecikmeGunu} gün`}
                                  </div>
                                </div>
                                {!sablonKullan && onBagimlilikSil && (
                                  <Button
                                    size="small"
                                    danger
                                    onClick={() => onBagimlilikSil(bagimlilik.id)}
                                    icon={<DeleteOutlined />}
                                  >
                                    Sil
                                  </Button>
                                )}
                              </div>
                            );
                          })}
                        </div>
                      ) : (
                        <Alert 
                          message="Bu görev için öncül görev bulunmuyor" 
                          type="info" 
                          size="small"
                          style={{ marginBottom: '16px' }}
                        />
                      )}
                    </div>

                    <div>
                      <h4 style={{ 
                        marginBottom: '12px', 
                        color: '#52c41a',
                        borderBottom: '1px solid #f0f0f0',
                        paddingBottom: '8px'
                      }}>
                        Ardıl Görevler:
                      </h4>
                      {ardilBagimliliklar.length > 0 ? (
                        <div>
                          {ardilBagimliliklar.map(bagimlilik => {
                            const ardilId = bagimlilik.ardilUretimGoreviId || bagimlilik.ardilGorevId;
                            const ardilGorev = safeGorevler.find(g => g.id === ardilId);
                            return (
                              <div key={bagimlilik.id} style={{ 
                                display: 'flex', 
                                justifyContent: 'space-between', 
                                alignItems: 'center',
                                padding: '8px 12px',
                                background: '#f6f6f6',
                                borderRadius: '6px',
                                marginBottom: '8px'
                              }}>
                                <div>
                                  <Tag color="green" style={{ marginRight: '8px' }}>
                                    {ardilGorev?.sira || 'N/A'}
                                  </Tag>
                                  <span style={{ fontWeight: 500 }}>
                                    {ardilGorev ? ardilGorev.gorevAdi : `Görev ${ardilId}`}
                                  </span>
                                  {ardilGorev?.manuelEklenen && (
                                    <Tag color="purple" size="small" style={{ marginLeft: '8px' }}>
                                      Manuel
                                    </Tag>
                                  )}
                                  <div style={{ fontSize: '12px', color: '#666', marginTop: '4px' }}>
                                    Tip: {normalizeBagimlilikTipi(bagimlilik.bagimlilikTipi || bagimlilik.bagimlilikTipiText)}
                                    {bagimlilik.gecikmeGunu > 0 && ` • Gecikme: ${bagimlilik.gecikmeGunu} gün`}
                                  </div>
                                </div>
                                {!sablonKullan && onBagimlilikSil && (
                                  <Button
                                    size="small"
                                    danger
                                    onClick={() => onBagimlilikSil(bagimlilik.id)}
                                    icon={<DeleteOutlined />}
                                  >
                                    Sil
                                  </Button>
                                )}
                              </div>
                            );
                          })}
                        </div>
                      ) : (
                        <Alert 
                          message="Bu görev için ardıl görev bulunmuyor" 
                          type="info" 
                          size="small"
                        />
                      )}
                    </div>

                    {oncuBagimliliklar.length === 0 && ardilBagimliliklar.length === 0 && (
                      <Alert 
                        message="Bu görev için hiç bağımlılık bulunmuyor" 
                        description="Bu görev bağımsız olarak çalışabilir."
                        type="info" 
                        showIcon 
                      />
                    )}
                  </div>
                );
              })()}
            </Card>

            <div style={{ marginTop: '16px', textAlign: 'right' }}>
              <Button onClick={() => setBagimlilikModalVisible(false)}>
                Kapat
              </Button>
            </div>
          </div>
        )}
      </Modal>
    </>
  );
};

export default GorevYoneticisi;

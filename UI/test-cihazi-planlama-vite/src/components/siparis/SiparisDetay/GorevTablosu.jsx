// src/components/siparis/SiparisDetay/GorevTablosu.jsx
import React, { useState } from 'react';
import { 
  Card, 
  Table, 
  Tag, 
  Button, 
  Space, 
  Tooltip,
  Collapse,
  Select,
  Modal,
  Form,
  Input,
  Alert
} from 'antd';
import { 
  PlayCircleOutlined, 
  CheckCircleOutlined, 
  PauseCircleOutlined,
  ClockCircleOutlined,
  UserOutlined,
  ToolOutlined,
  LinkOutlined,
  ExclamationCircleOutlined
} from '@ant-design/icons';
import { useGorevDurumGuncelle } from '../../../hooks/useGorev';
import { usePersoneller } from '../../../hooks/usePersonel';
import { GOREV_DURUMLARI, GOREV_DURUM_METINLERI } from '../../../utils/constants';
import dayjs from 'dayjs';

const { Panel } = Collapse;
const { Option } = Select;
const { TextArea } = Input;

const GorevTablosu = ({ siparisId, siparis, gorevler }) => {
  const [selectedRowKeys, setSelectedRowKeys] = useState([]);
  const [modalVisible, setModalVisible] = useState(false);
  const [selectedGorev, setSelectedGorev] = useState(null);
  const [islemTipi, setIslemTipi] = useState('');
  const [form] = Form.useForm();

  // Hooks
  const gorevDurumGuncelle = useGorevDurumGuncelle();
  const { data: personeller } = usePersoneller();

  const handleGorevIslemi = (gorev, tip) => {
    setSelectedGorev(gorev);
    setIslemTipi(tip);
    setModalVisible(true);
    form.resetFields();
  };

  const handleModalConfirm = async () => {
    try {
      const values = await form.validateFields();
      
      let yeniDurum;
      switch (islemTipi) {
        case 'baslat':
          yeniDurum = GOREV_DURUMLARI.BASLADI;
          break;
        case 'tamamla':
          yeniDurum = GOREV_DURUMLARI.TAMAMLANDI;
          break;
        case 'beklet':
          yeniDurum = GOREV_DURUMLARI.BEKLETILDI;
          break;
        case 'devam-ettir':
          yeniDurum = GOREV_DURUMLARI.DEVAM_EDIYOR;
          break;
        default:
          return;
      }

      await gorevDurumGuncelle.mutateAsync({
        gorevId: selectedGorev.id,
        yeniDurum: yeniDurum,
        aciklama: values.aciklama || '',
        islemYapanPersonelId: values.personelId
      });

      setModalVisible(false);
      form.resetFields();
    } catch (error) {
      console.error('Form validation failed:', error);
    }
  };

  const getDurumTag = (durum, durumText) => {
    const durumConfig = {
      [GOREV_DURUMLARI.BEKLEMEDE]: { color: 'orange', icon: <ClockCircleOutlined />, text: 'Beklemede' },
      [GOREV_DURUMLARI.PLANLI]: { color: 'blue', icon: <ClockCircleOutlined />, text: 'Planlı' },
      [GOREV_DURUMLARI.BASLADI]: { color: 'processing', icon: <PlayCircleOutlined />, text: 'Başladı' },
      [GOREV_DURUMLARI.DEVAM_EDIYOR]: { color: 'processing', icon: <PlayCircleOutlined />, text: 'Devam Ediyor' },
      [GOREV_DURUMLARI.TAMAMLANDI]: { color: 'success', icon: <CheckCircleOutlined />, text: 'Tamamlandı' },
      [GOREV_DURUMLARI.BEKLETILDI]: { color: 'error', icon: <PauseCircleOutlined />, text: 'Bekletildi' },
      [GOREV_DURUMLARI.IPTAL]: { color: 'default', icon: <ExclamationCircleOutlined />, text: 'İptal' }
    };
    
    const config = durumConfig[durum] || { 
      color: 'default', 
      icon: <ClockCircleOutlined />, 
      text: durumText || GOREV_DURUM_METINLERI[durum] || 'Bilinmeyen'
    };
    
    return (
      <Tag color={config.color} icon={config.icon}>
        {config.text}
      </Tag>
    );
  };

  const getDepartmanTag = (departman) => {
    const departmanConfig = {
      'PMD': { color: 'blue', icon: '🔧' },
      'CNC': { color: 'green', icon: '⚙️' },
      'Teknik': { color: 'orange', icon: '🛠️' }
    };
    
    const config = departmanConfig[departman] || { color: 'default', icon: '📋' };
    return (
      <Tag color={config.color}>
        {config.icon} {departman}
      </Tag>
    );
  };

  const getBagimliliklar = (gorev) => {
    const oncuBagimliliklar = gorev.oncuBagimliliklar || [];
    const ardilBagimliliklar = gorev.ardilBagimliliklar || [];
    
    if (oncuBagimliliklar.length === 0 && ardilBagimliliklar.length === 0) {
      return <span style={{ color: '#999', fontSize: '12px' }}>Bağımlılık yok</span>;
    }
    
    return (
      <Collapse size="small" ghost>
        <Panel 
          header={
            <Space>
              <LinkOutlined />
              <span>Bağımlılıklar ({oncuBagimliliklar.length + ardilBagimliliklar.length})</span>
            </Space>
          } 
          key="1"
        >
          {oncuBagimliliklar.length > 0 && (
            <div style={{ marginBottom: '8px' }}>
              <strong>Öncül Görevler:</strong>
              <div style={{ marginTop: '4px' }}>
                {oncuBagimliliklar.map(bag => (
                  <Tag key={bag.id} color="orange" size="small" style={{ margin: '2px' }}>
                    {bag.oncuGorevAdi}
                  </Tag>
                ))}
              </div>
            </div>
          )}
          {ardilBagimliliklar.length > 0 && (
            <div>
              <strong>Ardıl Görevler:</strong>
              <div style={{ marginTop: '4px' }}>
                {ardilBagimliliklar.map(bag => (
                  <Tag key={bag.id} color="blue" size="small" style={{ margin: '2px' }}>
                    {bag.ardilGorevAdi}
                  </Tag>
                ))}
              </div>
            </div>
          )}
        </Panel>
      </Collapse>
    );
  };

  const getActionButtons = (record) => {
    const isLoading = gorevDurumGuncelle.isPending;

    switch (record.durum) {
      case GOREV_DURUMLARI.BEKLEMEDE:
      case GOREV_DURUMLARI.PLANLI:
        return (
          <Tooltip title="Görevi Başlat">
            <Button
              type="primary"
              size="small"
              icon={<PlayCircleOutlined />}
              onClick={() => handleGorevIslemi(record, 'baslat')}
              loading={isLoading}
            >
              Başlat
            </Button>
          </Tooltip>
        );

      case GOREV_DURUMLARI.BASLADI:
      case GOREV_DURUMLARI.DEVAM_EDIYOR:
        return (
          <Space size="small">
            <Tooltip title="Görevi Tamamla">
              <Button
                type="primary"
                size="small"
                icon={<CheckCircleOutlined />}
                onClick={() => handleGorevIslemi(record, 'tamamla')}
                loading={isLoading}
              >
                Tamamla
              </Button>
            </Tooltip>
            <Tooltip title="Görevi Beklet">
              <Button
                danger
                size="small"
                icon={<PauseCircleOutlined />}
                onClick={() => handleGorevIslemi(record, 'beklet')}
                loading={isLoading}
              >
                Beklet
              </Button>
            </Tooltip>
          </Space>
        );

      case GOREV_DURUMLARI.BEKLETILDI:
        return (
          <Tooltip title="Görevi Devam Ettir">
            <Button
              type="primary"
              size="small"
              icon={<PlayCircleOutlined />}
              onClick={() => handleGorevIslemi(record, 'devam-ettir')}
              loading={isLoading}
            >
              Devam Ettir
            </Button>
          </Tooltip>
        );

      case GOREV_DURUMLARI.TAMAMLANDI:
        return (
          <Tag color="success" icon={<CheckCircleOutlined />}>
            Tamamlandı
          </Tag>
        );

      case GOREV_DURUMLARI.IPTAL:
        return (
          <Tag color="default" icon={<ExclamationCircleOutlined />}>
            İptal Edildi
          </Tag>
        );

      default:
        return (
          <span style={{ color: '#999', fontSize: '12px' }}>
            İşlem yok
          </span>
        );
    }
  };

  const getModalTitle = () => {
    const titles = {
      'baslat': '🟢 Görevi Başlat',
      'tamamla': '✅ Görevi Tamamla',
      'beklet': '⏸️ Görevi Beklet',
      'devam-ettir': '▶️ Görevi Devam Ettir'
    };
    return titles[islemTipi] || 'Görev İşlemi';
  };

  const getAlertMessage = () => {
    const messages = {
      'baslat': 'Bu görev başlatılacak ve durum "Başladı" olarak güncellenecek.',
      'tamamla': 'Bu görev tamamlanacak ve durum "Tamamlandı" olarak güncellenecek.',
      'beklet': 'Bu görev bekletilecek ve durum "Bekletildi" olarak güncellenecek.',
      'devam-ettir': 'Bu görev devam ettirilecek ve durum "Devam Ediyor" olarak güncellenecek.'
    };
    return messages[islemTipi] || '';
  };

  const columns = [
    {
      title: 'Sıra',
      key: 'index',
      width: 60,
      render: (_, __, index) => (
        <span style={{ fontWeight: 'bold', color: '#666' }}>
          {index + 1}
        </span>
      ),
    },
    {
      title: 'Görev',
      dataIndex: 'gorevAdi',
      key: 'gorevAdi',
      width: 200,
      ellipsis: true,
      render: (text, record) => (
        <div>
          <div style={{ fontWeight: 'bold', marginBottom: '4px' }}>{text}</div>
          {record.gorevAciklama && (
            <div style={{ fontSize: '12px', color: '#666' }}>
              {record.gorevAciklama}
            </div>
          )}
        </div>
      ),
    },
    {
      title: 'Departman',
      dataIndex: 'departmanAdi',
      key: 'departmanAdi',
      width: 100,
      render: getDepartmanTag,
    },
    {
      title: 'Atanan Personel',
      dataIndex: 'atananPersonelAdi',
      key: 'atananPersonelAdi',
      width: 150,
      render: (personel) => (
        <Space>
          <UserOutlined />
          {personel || <span style={{ color: '#999' }}>Atanmamış</span>}
        </Space>
      ),
    },
    {
      title: 'Planlanan',
      key: 'planlanan',
      width: 180,
      render: (_, record) => (
        <div style={{ fontSize: '12px' }}>
          <div style={{ marginBottom: '2px' }}>
            <strong>Başlangıç:</strong> {record.planlananBaslangic ? 
              dayjs(record.planlananBaslangic).format('DD.MM HH:mm') : 
              <span style={{ color: '#999' }}>-</span>
            }
          </div>
          <div>
            <strong>Bitiş:</strong> {record.planlananBitis ? 
              dayjs(record.planlananBitis).format('DD.MM HH:mm') : 
              <span style={{ color: '#999' }}>-</span>
            }
          </div>
        </div>
      ),
    },
    {
      title: 'Gerçekleşen',
      key: 'gerceklesen',
      width: 180,
      render: (_, record) => (
        <div style={{ fontSize: '12px' }}>
          <div style={{ marginBottom: '2px' }}>
            <strong>Başlangıç:</strong> {record.gercekBaslangic ? 
              dayjs(record.gercekBaslangic).format('DD.MM HH:mm') : 
              <span style={{ color: '#999' }}>-</span>
            }
          </div>
          <div>
            <strong>Bitiş:</strong> {record.gercekBitis ? 
              dayjs(record.gercekBitis).format('DD.MM HH:mm') : 
              <span style={{ color: '#999' }}>-</span>
            }
          </div>
        </div>
      ),
    },
    {
      title: 'Süre',
      dataIndex: 'sure',
      key: 'sure',
      width: 80,
      align: 'center',
      render: (sure) => (
        <Tag color="blue" style={{ margin: 0 }}>
          {sure}h
        </Tag>
      ),
    },
    {
      title: 'Durum',
      key: 'durum',
      width: 120,
      render: (_, record) => getDurumTag(record.durum, record.durumText),
    },
    {
      title: 'Bağımlılıklar',
      key: 'bagimliliklar',
      width: 150,
      render: (_, record) => getBagimliliklar(record),
    },
    {
      title: 'İşlemler',
      key: 'actions',
      width: 200,
      render: (_, record) => getActionButtons(record),
    },
  ];

  const rowSelection = {
    selectedRowKeys,
    onChange: setSelectedRowKeys,
    getCheckboxProps: (record) => ({
      disabled: record.durum === GOREV_DURUMLARI.TAMAMLANDI || record.durum === GOREV_DURUMLARI.IPTAL,
    }),
  };

  const tamamlananGorevSayisi = gorevler?.filter(g => g.durum === GOREV_DURUMLARI.TAMAMLANDI).length || 0;
  const devamEdenGorevSayisi = gorevler?.filter(g => 
    g.durum === GOREV_DURUMLARI.BASLADI || g.durum === GOREV_DURUMLARI.DEVAM_EDIYOR
  ).length || 0;

  return (
    <>
      <Card 
        className="modern-card"
        title={
          <Space>
            <ToolOutlined />
            <span>Görev Listesi</span>
            <Tag color="blue">{gorevler?.length || 0} görev</Tag>
            <Tag color="green">{tamamlananGorevSayisi} tamamlandı</Tag>
            <Tag color="processing">{devamEdenGorevSayisi} devam ediyor</Tag>
          </Space>
        }
        extra={
          selectedRowKeys.length > 0 && (
            <Space>
              <span style={{ fontSize: '12px', color: '#666' }}>
                {selectedRowKeys.length} görev seçildi
              </span>
              <Select
                placeholder="Toplu işlem"
                style={{ width: 120 }}
                size="small"
                disabled={gorevDurumGuncelle.isPending}
              >
                <Option value="baslat">Başlat</Option>
                <Option value="beklet">Beklet</Option>
                <Option value="tamamla">Tamamla</Option>
              </Select>
            </Space>
          )
        }
      >
        <Table
          columns={columns}
          dataSource={gorevler || []}
          rowKey="id"
          rowSelection={rowSelection}
          pagination={false}
          size="small"
          scroll={{ x: 1400 }}
          className="modern-table"
          expandable={{
            expandedRowRender: (record) => (
              <div style={{ 
                padding: '16px', 
                background: '#fafafa',
                borderRadius: '6px',
                margin: '8px 0'
              }}>
                {record.gorevAciklama && (
                  <div style={{ marginBottom: '8px' }}>
                    <strong>Görev Açıklaması:</strong> 
                    <div style={{ marginTop: '4px' }}>{record.gorevAciklama}</div>
                  </div>
                )}
                {record.notlar && (
                  <div>
                    <strong>Notlar:</strong> 
                    <div style={{ marginTop: '4px' }}>{record.notlar}</div>
                  </div>
                )}
                {!record.gorevAciklama && !record.notlar && (
                  <span style={{ color: '#999' }}>Ek bilgi bulunmuyor</span>
                )}
              </div>
            ),
            rowExpandable: (record) => record.gorevAciklama || record.notlar,
          }}
          locale={{
            emptyText: 'Bu siparişe ait görev bulunamadı'
          }}
        />
      </Card>

      {/* Görev Durum Değiştirme Modal'ı */}
      <Modal
        title={getModalTitle()}
        open={modalVisible}
        onCancel={() => {
          setModalVisible(false);
          form.resetFields();
        }}
        onOk={handleModalConfirm}
        confirmLoading={gorevDurumGuncelle.isPending}
        width={500}
        okText="Onayla"
        cancelText="İptal"
      >
        <Space direction="vertical" style={{ width: '100%' }}>
          <Alert
            message={getAlertMessage()}
            type="info"
            showIcon
            icon={<ClockCircleOutlined />}
          />

          {selectedGorev && (
            <div style={{ 
              padding: '12px', 
              background: '#f6f6f6', 
              borderRadius: '6px',
              marginBottom: '16px'
            }}>
              <strong>Görev:</strong> {selectedGorev.gorevAdi}<br/>
              <strong>Departman:</strong> {selectedGorev.departmanAdi}<br/>
              <strong>Mevcut Durum:</strong> {selectedGorev.durumText || GOREV_DURUM_METINLERI[selectedGorev.durum]}
            </div>
          )}

          <Form form={form} layout="vertical">
            <Form.Item
              name="personelId"
              label="İşlemi Yapan Personel"
              rules={[{ required: true, message: 'Personel seçimi zorunludur!' }]}
            >
              <Select
                placeholder="Personel seçin"
                showSearch
                optionFilterProp="children"
                filterOption={(input, option) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                }
              >
                {personeller?.map(personel => (
                  <Option key={personel.id} value={personel.id}>
                    <Space>
                      <UserOutlined />
                      {personel.ad} {personel.soyad} - {personel.departmanAdi}
                    </Space>
                  </Option>
                ))}
              </Select>
            </Form.Item>

            <Form.Item
              name="aciklama"
              label="Açıklama/Notlar (Opsiyonel)"
            >
              <TextArea
                rows={3}
                placeholder="İşlemle ilgili açıklama veya notlarınızı buraya yazabilirsiniz..."
                maxLength={500}
                showCount
              />
            </Form.Item>
          </Form>
        </Space>
      </Modal>
    </>
  );
};

export default GorevTablosu;

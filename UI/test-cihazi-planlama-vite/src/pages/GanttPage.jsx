// src/pages/GanttPage.jsx
import React, { useState } from 'react';
import { 
  Spin, 
  Alert, 
  Button, 
  Space, 
  DatePicker, 
  Select, 
  Input,
  Row,
  Col,
  Card,
  Tag,
  Breadcrumb
} from 'antd';
import { 
  ReloadOutlined, 
  FullscreenOutlined, 
  ThunderboltOutlined,
  FilterOutlined,
  ClearOutlined,
  HomeOutlined,
  BarChartOutlined,
  UserOutlined
} from '@ant-design/icons';
import GanttChart from '../components/gantt/GanttChart/GanttChart';
import { useGantt } from '../hooks/useGantt';
import { useTumSiparislerPlanlama } from '../hooks/usePlanlama';
import { usePersoneller } from '../hooks/usePersonel'; // Personel hook'u ekleyin
import dayjs from 'dayjs';

const { RangePicker } = DatePicker;
const { Option } = Select;

const GanttPage = () => {

  
  const { 
    ganttData, 
    loading, 
    error, 
    currentFilters,
    refetch, 
    applyFilters,
    clearFilters,
    handleTaskUpdate, 
    handleLinkUpdate 
  } = useGantt();
  
  const tumSiparislerPlanlama = useTumSiparislerPlanlama();
  
  // Personel verilerini çek
  const { data: personeller, isLoading: personelLoading } = usePersoneller();
  
  const [filterForm, setFilterForm] = useState({
    dateRange: [, ],
    siparisNo: '',
    departman: '',
    personel: ''
  });

  const handleTumSiparislerPlanlama = async () => {
    await tumSiparislerPlanlama.mutateAsync();
    refetch();
  };

  const handleFilterApply = async () => {
    const filters = {};
    
    if (filterForm.dateRange && filterForm.dateRange[0] && filterForm.dateRange[1]) {
      filters.baslangic = filterForm.dateRange[0].toISOString();
      filters.bitis = filterForm.dateRange[1].toISOString();
    }
    
    if (filterForm.siparisNo) {
      filters.siparisNo = filterForm.siparisNo;
    }
    
    if (filterForm.departman) {
      filters.departman = filterForm.departman;
    }
    
    if (filterForm.personel) {
      filters.personel = filterForm.personel;
    }

    await applyFilters(filters);
  };

  const handleFilterClear = async () => {
    setFilterForm({
      dateRange: [defaultFilterStartDate, defaultFilterEndDate],
      siparisNo: '',
      departman: '',
      personel: ''
    });
    await clearFilters();
  };

  if (loading) {
    return (
      <div style={{ 
        display: 'flex', 
        justifyContent: 'center', 
        alignItems: 'center',
        height: '100%',
        flexDirection: 'column'
      }}>
        <Spin size="large" />
        <p style={{ marginTop: '16px' }}>Gantt Chart yükleniyor...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div style={{ padding: '24px' }}>
        <Alert
          message="Hata"
          description={`Gantt verileri yüklenemedi: ${error}`}
          type="error"
          action={
            <Button onClick={refetch} icon={<ReloadOutlined />}>
              Yeniden Dene
            </Button>
          }
        />
      </div>
    );
  }

  const { tasks, links } = ganttData;

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
                    <BarChartOutlined />
                    <span>Planlama & Gantt Chart</span>
                  </Space>
                ),
              },
            ]}
          />
        </div>

        <div style={{ 
          display: 'flex', 
          justifyContent: 'space-between', 
          alignItems: 'center',
          marginBottom: '16px'
        }}>
          <div>
            <h1 style={{ margin: 0, fontSize: '24px', fontWeight: 600, color: '#262626' }}>
              Üretim Planı & Gantt Chart
            </h1>
            <p style={{ margin: '4px 0 0 0', color: '#8c8c8c', fontSize: '14px' }}>
              {tasks?.filter(t => t.type === 'project').length || 0} sipariş, {' '}
              {tasks?.filter(t => t.type === 'task').length || 0} görev planlandı
            </p>
          </div>
          <Space>
            <Button
              icon={<ThunderboltOutlined />}
              onClick={handleTumSiparislerPlanlama}
              loading={tumSiparislerPlanlama.isPending}
            >
              Tümünü Yeniden Planla
            </Button>
            <Button 
              onClick={refetch} 
              icon={<ReloadOutlined />}
            >
              Yenile
            </Button>
            <Button 
              icon={<FullscreenOutlined />}
              onClick={() => {
                const elem = document.querySelector('.gantt-container-fullpage');
                if (elem.requestFullscreen) {
                  elem.requestFullscreen();
                }
              }}
            >
              Tam Ekran
            </Button>
          </Space>
        </div>

        <Card size="small" style={{ backgroundColor: '#fafafa' }}>
          <Row gutter={16} align="middle">
            <Col span={6}>
              <div style={{ marginBottom: '8px' }}>
                <FilterOutlined style={{ marginRight: '8px' }} />
                <span style={{ fontWeight: 600 }}>Filtre Tarih Aralığı:</span>
              </div>
              <RangePicker
                value={filterForm.dateRange}
                onChange={(dates) => setFilterForm(prev => ({ ...prev, dateRange: dates }))}
                style={{ width: '100%' }}
                placeholder={['Başlangıç', 'Bitiş']}
                format="DD.MM.YYYY"
              />
            </Col>
            <Col span={4}>
              <div style={{ marginBottom: '8px' }}>
                <span style={{ fontWeight: 600 }}>Sipariş No:</span>
              </div>
              <Input
                value={filterForm.siparisNo}
                onChange={(e) => setFilterForm(prev => ({ ...prev, siparisNo: e.target.value }))}
                placeholder="Sipariş numarası"
              />
            </Col>
            <Col span={4}>
              <div style={{ marginBottom: '8px' }}>
                <span style={{ fontWeight: 600 }}>Departman:</span>
              </div>
              <Select
                value={filterForm.departman}
                onChange={(value) => setFilterForm(prev => ({ ...prev, departman: value }))}
                style={{ width: '100%' }}
                placeholder="Departman seçin"
                allowClear
              >
                <Option value="PMD">PMD</Option>
                <Option value="CNC">CNC</Option>
                <Option value="Teknik">Teknik</Option>
              </Select>
            </Col>
            <Col span={4}>
              <div style={{ marginBottom: '8px' }}>
                <span style={{ fontWeight: 600 }}>Personel:</span>
              </div>
              <Select
                value={filterForm.personel}
                onChange={(value) => setFilterForm(prev => ({ ...prev, personel: value }))}
                style={{ width: '100%' }}
                placeholder="Personel seçin"
                allowClear
                loading={personelLoading}
                showSearch
                optionFilterProp="children"
                filterOption={(input, option) =>
                  option.children.toLowerCase().indexOf(input.toLowerCase()) >= 0
                }
              >
                {personeller?.map(personel => (
                  <Option key={personel.id} value={personel.ad + ' ' + personel.soyad}>
                    <Space>
                      <UserOutlined />
                      {personel.ad} {personel.soyad} - {personel.departmanAdi}
                    </Space>
                  </Option>
                ))}
              </Select>
            </Col>
            <Col span={6}>
              <div style={{ marginBottom: '8px' }}>&nbsp;</div>
              <Space>
                <Button 
                  type="primary" 
                  onClick={handleFilterApply}
                  icon={<FilterOutlined />}
                >
                  Filtrele
                </Button>
                <Button 
                  onClick={handleFilterClear}
                  icon={<ClearOutlined />}
                >
                  Temizle
                </Button>
              </Space>
            </Col>
          </Row>
          
          {Object.keys(currentFilters).length > 0 && (
            <div style={{ marginTop: '12px', paddingTop: '12px', borderTop: '1px solid #e8e8e8' }}>
              <span style={{ marginRight: '8px', fontWeight: 600 }}>Aktif Filtreler:</span>
              {Object.entries(currentFilters).map(([key, value]) => (
                <Tag key={key} color="blue" style={{ marginRight: '4px' }}>
                  {key}: {typeof value === 'string' && value.includes('T') ? 
                    dayjs(value).format('DD.MM.YYYY') : value}
                </Tag>
              ))}
            </div>
          )}
        </Card>
      </div>

      <div style={{ 
        flex: 1,
        padding: '24px',
        overflow: 'hidden'
      }}>
        <GanttChart
          tasks={tasks}
          links={links}
          onTaskUpdate={handleTaskUpdate}
          onLinkUpdate={handleLinkUpdate}
          height="100%"
        />
      </div>
    </div>
  );
};

export default GanttPage;

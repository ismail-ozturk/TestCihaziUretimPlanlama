// src/App.jsx
import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link, useLocation } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ConfigProvider, Layout, Menu, Avatar, Dropdown, Space, Badge } from 'antd';
import { 
  PlusOutlined, 
  UnorderedListOutlined, 
  BarChartOutlined,
  UserOutlined,
  SettingOutlined,
  LogoutOutlined,
  BellOutlined
} from '@ant-design/icons';
import trTR from 'antd/locale/tr_TR';
import SiparisListesiPage from './pages/SiparisListesiPage';
import SiparisEklePage from './pages/SiparisEklePage';
import SiparisDetayPage from './pages/SiparisDetayPage';
import GanttPage from './pages/GanttPage';
import './styles/layout.css';

const { Header, Content } = Layout;

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      retry: 1,
      refetchOnWindowFocus: false,
      staleTime: 5 * 60 * 1000,
    },
  },
});

const AppLayout = ({ children }) => {
  const location = useLocation();

  const menuItems = [
    {
      key: '/siparisler',
      icon: <UnorderedListOutlined />,
      label: <Link to="/siparisler">Sipariş Yönetimi</Link>,
    },
    {
      key: '/siparis-ekle',
      icon: <PlusOutlined />,
      label: <Link to="/siparis-ekle">Yeni Sipariş</Link>,
    },
    {
      key: '/gantt',
      icon: <BarChartOutlined />,
      label: <Link to="/gantt">Planlama & Gantt</Link>,
    },
  ];

  const userMenuItems = [
    {
      key: 'profile',
      icon: <UserOutlined />,
      label: 'Profil',
    },
    {
      key: 'settings',
      icon: <SettingOutlined />,
      label: 'Ayarlar',
    },
    {
      type: 'divider',
    },
    {
      key: 'logout',
      icon: <LogoutOutlined />,
      label: 'Çıkış Yap',
      danger: true,
    },
  ];

  return (
    <Layout style={{
      width: '100vw',
      height: '100vh',
      overflow: 'hidden',
      margin: 0,
      padding: 0,
      display: 'flex',
      flexDirection: 'column'
    }}>
      <Header style={{
        background: 'linear-gradient(135deg, #001529 0%, #002140 100%)',
        boxShadow: '0 2px 8px rgba(0, 0, 0, 0.15)',
        borderBottom: '1px solid #1890ff',
        padding: 0,
        height: '64px',
        width: '100%',
        flexShrink: 0,
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        paddingLeft: '24px',
        paddingRight: '24px'
      }}>
        <div style={{
          display: 'flex',
          alignItems: 'center',
          color: 'white',
          fontWeight: 600,
          fontSize: '18px'
        }}>
          <span style={{ fontSize: '24px', marginRight: '12px' }}>⚙️</span>
          <span>Test Cihazı Üretim Planlama</span>
        </div>
        
        <Menu
          theme="dark"
          mode="horizontal"
          selectedKeys={[location.pathname]}
          items={menuItems}
          style={{
            background: 'transparent',
            border: 'none',
            fontWeight: 500,
            lineHeight: '64px'
          }}
        />

        <Space size="large">
          <Badge count={3} size="small">
            <BellOutlined style={{
              color: 'rgba(255, 255, 255, 0.8)',
              fontSize: '18px',
              cursor: 'pointer'
            }} />
          </Badge>
          
          <Dropdown
            menu={{ items: userMenuItems }}
            placement="bottomRight"
            arrow
          >
            <Space style={{
              color: 'white',
              cursor: 'pointer',
              padding: '8px 12px',
              borderRadius: '6px'
            }}>
              <Avatar size="small" icon={<UserOutlined />} />
              <span>Admin User</span>
            </Space>
          </Dropdown>
        </Space>
      </Header>

      <Content style={{
        flex: 1,
        overflow: 'hidden',
        background: '#f0f2f5',
        width: '100%'
      }}>
        {children}
      </Content>
    </Layout>
  );
};

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <ConfigProvider 
        locale={trTR}
        theme={{
          token: {
            colorPrimary: '#1890ff',
            borderRadius: 8,
            fontSize: 14,
          }
        }}
      >
        <Router>
          <AppLayout>
            <Routes>
              <Route path="/" element={<SiparisListesiPage />} />
              <Route path="/siparisler" element={<SiparisListesiPage />} />
              <Route path="/siparis-ekle" element={<SiparisEklePage />} />
              <Route path="/siparis/:id" element={<SiparisDetayPage />} />
              <Route path="/gantt" element={<GanttPage />} />
            </Routes>
          </AppLayout>
        </Router>
      </ConfigProvider>
    </QueryClientProvider>
  );
}

export default App;

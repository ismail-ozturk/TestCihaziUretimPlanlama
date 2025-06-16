import React, { useState, useMemo, useCallback } from 'react';
import {
    Card,
    Table,
    Button,
    Space,
    Modal,
    Form,
    Select,
    Input,
    InputNumber,
    message,
    Popconfirm,
    Tag,
    Alert
} from 'antd';
import {
    PlusOutlined,
    EditOutlined,
    DeleteOutlined
} from '@ant-design/icons';
import { useGorevler } from '../../../hooks/useGorev';

const { Option } = Select;
const { TextArea } = Input;

const GorevYoneticisi = ({ gorevler, onChange, kategoriId, sablonKullan }) => {
    const [modalVisible, setModalVisible] = useState(false);
    const [editingGorev, setEditingGorev] = useState(null);
    const [form] = Form.useForm();

    const { data: tumGorevler, isLoading: gorevlerLoading } = useGorevler();

    // Güvenli dataSource
    const safeGorevler = useMemo(() => {
        if (!gorevler) return [];
        if (Array.isArray(gorevler)) return gorevler;
        return [];
    }, [gorevler]);

    // Şablon görevlerinin düzenlenebilir olup olmadığını kontrol et
    const isDuzenlenebilir = !sablonKullan;

    // onChange callback'ini güvenli hale getirin
    const handleChange = useCallback((yeniGorevler) => {
        if (onChange) {
            onChange(yeniGorevler);
        }
    }, [onChange]);

    const handleGorevEkle = () => {
        setEditingGorev(null);
        form.resetFields();
        setModalVisible(true);
    };

    const handleGorevDuzenle = (gorev) => {
        // Şablon kullanılıyorsa düzenlemeyi engelle
        if (sablonKullan && gorev.sablondan) {
            message.warning('Şablon kullanılırken şablon görevleri düzenlenemez. "Kategori şablonunu kullan" seçeneğini kapatın.');
            return;
        }

        setEditingGorev(gorev);
        form.setFieldsValue({
            gorevAdi: gorev.gorevAdi,
            aciklama: gorev.aciklama,
            departmanAdi: gorev.departmanAdi,
            sure: gorev.sure
        });
        setModalVisible(true);
    };

    const handleGorevSil = (gorevId) => {
        const silinecekGorev = safeGorevler.find(g => g.id === gorevId);

        // Şablon kullanılıyorsa şablon görevlerinin silinmesini engelle
        if (sablonKullan && silinecekGorev?.sablondan) {
            message.warning('Şablon kullanılırken şablon görevleri silinemez. "Kategori şablonunu kullan" seçeneğini kapatın.');
            return;
        }

        const yeniGorevler = safeGorevler.filter(g => g.id !== gorevId);
        handleChange(yeniGorevler);
        message.success('Görev silindi');
    };

    const handleModalOk = async () => {
        try {
            const values = await form.validateFields();

            if (editingGorev) {
                const yeniGorevler = safeGorevler.map(g =>
                    g.id === editingGorev.id ? { ...g, ...values } : g
                );
                handleChange(yeniGorevler);
                message.success('Görev güncellendi');
            } else {
                const yeniGorev = {
                    id: Date.now(),
                    gorevId: null,
                    ...values,
                    durum: 'Beklemede',
                    sira: safeGorevler.length + 1,
                    bagimliliklar: [],
                    sablondan: false // Manuel eklenen görev
                };
                handleChange([...safeGorevler, yeniGorev]);
                message.success('Görev eklendi');
            }

            setModalVisible(false);
            form.resetFields();
        } catch (error) {
            console.error('Form validation failed:', error);
        }
    };

    const columns = [
        {
            title: 'Sıra',
            dataIndex: 'sira',
            key: 'sira',
            width: 60,
            sorter: (a, b) => a.sira - b.sira,
        },
        {
            title: 'Görev Adı',
            dataIndex: 'gorevAdi',
            key: 'gorevAdi',
            ellipsis: true,
        },
        {
            title: 'Departman',
            dataIndex: 'departmanAdi',
            key: 'departmanAdi',
            width: 100,
            render: (departman) => (
                <Tag color={
                    departman === 'PMD' ? 'blue' :
                        departman === 'CNC' ? 'green' :
                            departman === 'Teknik' ? 'orange' : 'default'
                }>
                    {departman}
                </Tag>
            ),
        },
        {
            title: 'Süre (Saat)',
            dataIndex: 'sure',
            key: 'sure',
            width: 100,
            align: 'center',
        },
        {
            title: 'Açıklama',
            dataIndex: 'aciklama',
            key: 'aciklama',
            ellipsis: true,
        },
        {
            title: 'Kaynak',
            key: 'kaynak',
            width: 80,
            render: (_, record) => (
                <Tag color={record.sablondan ? 'green' : 'blue'}>
                    {record.sablondan ? 'Şablon' : 'Manuel'}
                </Tag>
            ),
        },
        {
            title: 'İşlemler',
            key: 'actions',
            width: 150,
            render: (_, record) => (
                <Space>
                    <Button
                        type="link"
                        size="small"
                        icon={<EditOutlined />}
                        onClick={() => handleGorevDuzenle(record)}
                        disabled={sablonKullan && record.sablondan}
                    >
                        Düzenle
                    </Button>
                    <Popconfirm
                        title="Bu görevi silmek istediğinize emin misiniz?"
                        onConfirm={() => handleGorevSil(record.id)}
                        okText="Evet"
                        cancelText="Hayır"
                        disabled={sablonKullan && record.sablondan}
                    >
                        <Button
                            type="link"
                            danger
                            size="small"
                            icon={<DeleteOutlined />}
                            disabled={sablonKullan && record.sablondan}
                        >
                            Sil
                        </Button>
                    </Popconfirm>
                </Space>
            ),
        },
    ];

    return (
        <Card
            title={
                <Space>
                    <span>Görev Yönetimi</span>
                    <Tag color="blue">{safeGorevler.length} görev</Tag>
                    {sablonKullan && (
                        <Tag color="orange">Şablon Modu (Düzenleme Kısıtlı)</Tag>
                    )}
                </Space>
            }
            extra={
                <Button
                    type="primary"
                    icon={<PlusOutlined />}
                    onClick={handleGorevEkle}
                >
                    Manuel Görev Ekle
                </Button>
            }
        >
            {/* Durum Açıklama Kartları */}
            {kategoriId && sablonKullan && (
                <Alert
                    message="✅ Kategori Şablonu Aktif"
                    description="Şablon görevleri otomatik yüklendi ve backend'e gönderilecek. Manuel değişiklikler backend'e iletilmeyecek."
                    type="success"
                    showIcon
                    style={{ marginBottom: '16px' }}
                />
            )}

            {kategoriId && !sablonKullan && (
                <Alert
                    message="🔧 Manuel Düzenleme Modu"
                    description="Şablon görevlerini düzenleyebilir, silebilir ve yeni görevler ekleyebilirsiniz."
                    type="info"
                    showIcon
                    style={{ marginBottom: '16px' }}
                />
            )}

            <Table
                columns={columns}
                dataSource={safeGorevler}
                rowKey="id"
                pagination={false}
                size="small"
                scroll={{ x: 800 }}
                locale={{
                    emptyText: 'Henüz görev eklenmemiş.'
                }}
            />

            <Modal
                title={editingGorev ? 'Görev Düzenle' : 'Manuel Görev Ekle'}
                open={modalVisible}
                onOk={handleModalOk}
                onCancel={() => {
                    setModalVisible(false);
                    form.resetFields();
                }}
                width={600}
                okText={editingGorev ? 'Güncelle' : 'Ekle'}
                cancelText="İptal"
            >
                <Form
                    form={form}
                    layout="vertical"
                    initialValues={{
                        sure: 8,
                        departmanAdi: 'PMD'
                    }}
                >
                    <Form.Item
                        name="gorevAdi"
                        label="Görev Adı"
                        rules={[
                            { required: true, message: 'Görev adı gerekli!' },
                            { min: 3, message: 'En az 3 karakter olmalı!' }
                        ]}
                    >
                        <Input placeholder="Görev adını girin" />
                    </Form.Item>

                    <Form.Item
                        name="departmanAdi"
                        label="Departman"
                        rules={[{ required: true, message: 'Departman seçimi gerekli!' }]}
                    >
                        <Select placeholder="Departman seçin">
                            <Option value="PMD">PMD</Option>
                            <Option value="CNC">CNC</Option>
                            <Option value="Teknik">Teknik</Option>
                        </Select>
                    </Form.Item>

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
                            max={168}
                            step={0.5}
                            style={{ width: '100%' }}
                            placeholder="Görev süresi"
                        />
                    </Form.Item>

                    <Form.Item
                        name="aciklama"
                        label="Açıklama"
                        rules={[{ required: true, message: 'Açıklama gerekli!' }]}
                    >
                        <TextArea
                            rows={3}
                            placeholder="Görev açıklaması..."
                        />
                    </Form.Item>
                </Form>
            </Modal>
        </Card>
    );
};

export default GorevYoneticisi;

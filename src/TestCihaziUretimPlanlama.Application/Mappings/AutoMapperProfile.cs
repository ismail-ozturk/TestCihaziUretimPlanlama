using AutoMapper;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Entities;

namespace TestCihaziUretimPlanlama.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Departman Mappings
            CreateMap<Departman, DepartmanDto>()
                .ForMember(dest => dest.PersonelSayisi, opt => opt.MapFrom(src => src.Personeller.Count(p => !p.IsDeleted)))
                .ForMember(dest => dest.GorevSayisi, opt => opt.MapFrom(src => src.Gorevler.Count(g => !g.IsDeleted)));

            CreateMap<Departman, DepartmanDetayDto>()
                .ForMember(dest => dest.PersonelSayisi, opt => opt.MapFrom(src => src.Personeller.Count(p => !p.IsDeleted)))
                .ForMember(dest => dest.GorevSayisi, opt => opt.MapFrom(src => src.Gorevler.Count(g => !g.IsDeleted)))
                .ForMember(dest => dest.Personeller, opt => opt.MapFrom(src => src.Personeller.Where(p => !p.IsDeleted)))
                .ForMember(dest => dest.Gorevler, opt => opt.MapFrom(src => src.Gorevler.Where(g => !g.IsDeleted)));

            CreateMap<DepartmanCreateDto, Departman>();
            CreateMap<DepartmanUpdateDto, Departman>();

            // Personel Mappings
            CreateMap<Personel, PersonelDto>()
                .ForMember(dest => dest.DepartmanAdi, opt => opt.MapFrom(src => src.Departman != null ? src.Departman.Ad : ""))
                .ForMember(dest => dest.GorevYetkinlikleri, opt => opt.MapFrom(src => src.GorevYetkinlikleri.Where(y => !y.IsDeleted)));

            CreateMap<PersonelGorevYetkinlik, GorevYetkinlikDto>()
                .ForMember(dest => dest.GorevAdi, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Ad : ""));

            CreateMap<PersonelCreateDto, Personel>();
            CreateMap<PersonelUpdateDto, Personel>();

            // Görev Mappings
            CreateMap<Gorev, GorevDto>()
                .ForMember(dest => dest.DepartmanAdi, opt => opt.MapFrom(src => src.Departman != null ? src.Departman.Ad : ""))
                .ForMember(dest => dest.YetkinPersonelSayisi, opt => opt.MapFrom(src => src.PersonelYetkinlikleri.Count(y => !y.IsDeleted)));

            CreateMap<Gorev, GorevDetayDto>()
                .ForMember(dest => dest.DepartmanAdi, opt => opt.MapFrom(src => src.Departman != null ? src.Departman.Ad : ""))
                .ForMember(dest => dest.YetkinPersonelSayisi, opt => opt.MapFrom(src => src.PersonelYetkinlikleri.Count(y => !y.IsDeleted)))
                .ForMember(dest => dest.YetkinPersoneller, opt => opt.MapFrom(src => src.PersonelYetkinlikleri.Where(y => !y.IsDeleted).Select(y => y.Personel)));

            CreateMap<GorevCreateDto, Gorev>();
            CreateMap<GorevUpdateDto, Gorev>();

            // Sipariş Mappings
            CreateMap<Siparis, SiparisDto>()
                .ForMember(dest => dest.KategoriAdi, opt => opt.MapFrom(src => src.Kategori != null ? src.Kategori.Ad : ""))
                .ForMember(dest => dest.ToplamGorevSayisi, opt => opt.MapFrom(src => src.UretimGorevleri.Count(ug => !ug.IsDeleted)))
                .ForMember(dest => dest.TamamlananGorevSayisi, opt => opt.MapFrom(src => src.UretimGorevleri.Count(ug => ug.Durum == Core.Enums.GorevDurum.Tamamlandi && !ug.IsDeleted)));

            CreateMap<Siparis, SiparisDetayDto>()
                .ForMember(dest => dest.KategoriAdi, opt => opt.MapFrom(src => src.Kategori != null ? src.Kategori.Ad : ""))
                .ForMember(dest => dest.ToplamGorevSayisi, opt => opt.MapFrom(src => src.UretimGorevleri.Count(ug => !ug.IsDeleted)))
                .ForMember(dest => dest.TamamlananGorevSayisi, opt => opt.MapFrom(src => src.UretimGorevleri.Count(ug => ug.Durum == Core.Enums.GorevDurum.Tamamlandi && !ug.IsDeleted)));

            CreateMap<SiparisCreateDto, Siparis>();

            // Üretim Görevi Mappings
            CreateMap<UretimGorevi, UretimGoreviDto>()
                .ForMember(dest => dest.SiparisUretimNumarasi, opt => opt.MapFrom(src => src.Siparis != null ? src.Siparis.UretimNumarasi : ""))
                .ForMember(dest => dest.GorevAdi, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Ad : ""))
                .ForMember(dest => dest.GorevAciklama, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Aciklama : ""))
                .ForMember(dest => dest.DepartmanAdi, opt => opt.MapFrom(src => src.Gorev != null && src.Gorev.Departman != null ? src.Gorev.Departman.Ad : ""))
                .ForMember(dest => dest.AtananPersonelAdi, opt => opt.MapFrom(src => src.AtananPersonel != null ? $"{src.AtananPersonel.Ad} {src.AtananPersonel.Soyad}" : ""));

            CreateMap<UretimGorevBagimlilik, UretimGorevBagimlilikDto>()
                .ForMember(dest => dest.OncuGorevId, opt => opt.MapFrom(src => src.OncuUretimGoreviId))
                .ForMember(dest => dest.OncuGorevAdi, opt => opt.MapFrom(src => src.OncuGorev != null && src.OncuGorev.Gorev != null ? src.OncuGorev.Gorev.Ad : ""))
                .ForMember(dest => dest.ArdilGorevId, opt => opt.MapFrom(src => src.ArdilUretimGoreviId))
                .ForMember(dest => dest.ArdilGorevAdi, opt => opt.MapFrom(src => src.ArdilGorev != null && src.ArdilGorev.Gorev != null ? src.ArdilGorev.Gorev.Ad : ""));


            // Kategori Mappings
            CreateMap<Kategori, KategoriDto>()
                .ForMember(dest => dest.GorevSablonSayisi, opt => opt.MapFrom(src => src.GorevSablonlari.Count(s => !s.IsDeleted)))
                .ForMember(dest => dest.ToplamSure, opt => opt.MapFrom(src => src.GorevSablonlari.Where(s => !s.IsDeleted).Sum(s => s.OzelSure ?? s.Gorev.Sure)));

            CreateMap<Kategori, KategoriDetayDto>()
                .ForMember(dest => dest.GorevSablonSayisi, opt => opt.MapFrom(src => src.GorevSablonlari.Count(s => !s.IsDeleted)))
                .ForMember(dest => dest.ToplamSure, opt => opt.MapFrom(src => src.GorevSablonlari.Where(s => !s.IsDeleted).Sum(s => s.OzelSure ?? s.Gorev.Sure)))
                .ForMember(dest => dest.GorevSablonlari, opt => opt.MapFrom(src => src.GorevSablonlari.Where(s => !s.IsDeleted).OrderBy(s => s.Sira)));

            CreateMap<KategoriCreateDto, Kategori>();
            CreateMap<KategoriUpdateDto, Kategori>();

            CreateMap<KategoriGorevSablonu, KategoriGorevSablonuDto>()
                .ForMember(dest => dest.GorevAdi, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Ad : ""))
                .ForMember(dest => dest.GorevAciklama, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Aciklama : ""))
                .ForMember(dest => dest.DepartmanAdi, opt => opt.MapFrom(src => src.Gorev != null && src.Gorev.Departman != null ? src.Gorev.Departman.Ad : ""))
                .ForMember(dest => dest.VarsayilanSure, opt => opt.MapFrom(src => src.Gorev != null ? src.Gorev.Sure : 0));

            CreateMap<KategoriGorevBagimlilik, KategoriGorevBagimlilikDto>()
                .ForMember(dest => dest.OncuGorevAdi, opt => opt.MapFrom(src => src.OncuGorev != null && src.OncuGorev.Gorev != null ? src.OncuGorev.Gorev.Ad : ""))
                .ForMember(dest => dest.OncuGorevSira, opt => opt.MapFrom(src => src.OncuGorev != null ? src.OncuGorev.Sira : 0))
                .ForMember(dest => dest.ArdilGorevAdi, opt => opt.MapFrom(src => src.ArdilGorev != null && src.ArdilGorev.Gorev != null ? src.ArdilGorev.Gorev.Ad : ""))
                .ForMember(dest => dest.ArdilGorevSira, opt => opt.MapFrom(src => src.ArdilGorev != null ? src.ArdilGorev.Sira : 0));
        }
    }
}

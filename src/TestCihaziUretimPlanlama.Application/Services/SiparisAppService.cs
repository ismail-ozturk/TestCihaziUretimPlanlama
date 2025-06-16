using AutoMapper;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class SiparisAppService
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly ISiparisService _siparisService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SiparisAppService(
            ISiparisRepository siparisRepository,
            ISiparisService siparisService,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _siparisRepository = siparisRepository;
            _siparisService = siparisService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<SiparisDto>>> GetAllAsync()
        {
            try
            {
                var siparisler = await _siparisRepository.GetAllAsync();
                var siparisDtos = _mapper.Map<List<SiparisDto>>(siparisler);

                return ApiResponse<List<SiparisDto>>.SuccessResult(siparisDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<SiparisDto>>.ErrorResult($"Siparişler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<SiparisDetayDto>> GetByIdAsync(int id)
        {
            try
            {
                var siparis = await _siparisService.GetDetayliSiparisAsync(id);
                if (siparis == null)
                {
                    return ApiResponse<SiparisDetayDto>.ErrorResult("Sipariş bulunamadı");
                }

                var siparisDto = _mapper.Map<SiparisDetayDto>(siparis);
                return ApiResponse<SiparisDetayDto>.SuccessResult(siparisDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<SiparisDetayDto>.ErrorResult($"Sipariş getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<SiparisDto>> CreateAsync(SiparisCreateDto dto)
        {
            try
            {
                var siparisModel = new SiparisCreateModel
                {
                    UretimNumarasi = dto.UretimNumarasi,
                    Musteri = dto.Musteri,
                    IstenilenBaslangicTarihi = dto.IstenilenBaslangicTarihi,
                    KategoriId = dto.KategoriId,
                    KategoriSablonuKullan = dto.KategoriSablonuKullan,
                    Oncelik = dto.Oncelik,
                    SonTeslimTarihi = dto.SonTeslimTarihi,
                    Notlar = dto.Notlar,
                    Gorevler = dto.Gorevler.Select(g => new GorevCreateModel
                    {
                        GorevId = g.GorevId,
                        OzelSure = g.OzelSure,
                        OzelAciklama = g.OzelAciklama,
                        OncuGorevIds = g.OncuGorevIds
                    }).ToList(),
                    ZorunluPmdPersonelId = dto.ZorunluPmdPersonelId,
                    ZorunluCncPersonelId = dto.ZorunluCncPersonelId,
                    ZorunluTeknikPersonelId = dto.ZorunluTeknikPersonelId
                };

                var siparis = await _siparisService.SiparisOlusturAsync(siparisModel);
                var siparisDto = _mapper.Map<SiparisDto>(siparis);

                return ApiResponse<SiparisDto>.SuccessResult(siparisDto, "Sipariş başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                return ApiResponse<SiparisDto>.ErrorResult($"Sipariş oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var result = await _siparisService.SiparisIptalAsync(id);
                if (!result)
                {
                    return ApiResponse.ErrorResult("Sipariş iptal edilemedi");
                }

                return ApiResponse.SuccessResult("Sipariş başarıyla iptal edildi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Sipariş iptal edilirken hata oluştu: {ex.Message}");
            }
        }
    }
}

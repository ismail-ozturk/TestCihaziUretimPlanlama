using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Enums;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class GorevAppService
    {
        private readonly IGorevRepository _gorevRepository;
        private readonly IUretimGoreviRepository _uretimGoreviRepository;
        private readonly IDepartmanRepository _departmanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GorevAppService(
            IGorevRepository gorevRepository,
            IDepartmanRepository departmanRepository,
            IUretimGoreviRepository uretimGoreviRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _gorevRepository = gorevRepository;
            _departmanRepository = departmanRepository;
            _uretimGoreviRepository = uretimGoreviRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GorevDto>>> GetAllAsync()
        {
            try
            {
                var gorevler = await _gorevRepository.GetAllAsync();
                var gorevDtos = _mapper.Map<List<GorevDto>>(gorevler);

                return ApiResponse<List<GorevDto>>.SuccessResult(gorevDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<GorevDto>>.ErrorResult($"Görevler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<GorevDto>>> GetByDepartmanIdAsync(int departmanId)
        {
            try
            {
                var gorevler = await _gorevRepository.GetByDepartmanIdAsync(departmanId);
                var gorevDtos = _mapper.Map<List<GorevDto>>(gorevler);

                return ApiResponse<List<GorevDto>>.SuccessResult(gorevDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<GorevDto>>.ErrorResult($"Departman görevleri getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<GorevDetayDto>> GetByIdAsync(int id)
        {
            try
            {
                var gorev = await _gorevRepository.GetDetayliGorevAsync(id);
                if (gorev == null)
                {
                    return ApiResponse<GorevDetayDto>.ErrorResult("Görev bulunamadı");
                }

                var gorevDto = _mapper.Map<GorevDetayDto>(gorev);
                return ApiResponse<GorevDetayDto>.SuccessResult(gorevDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<GorevDetayDto>.ErrorResult($"Görev getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<GorevDto>> CreateAsync(GorevCreateDto dto)
        {
            try
            {
                // Departman kontrolü
                var departman = await _departmanRepository.GetByIdAsync(dto.DepartmanId);
                if (departman == null)
                {
                    return ApiResponse<GorevDto>.ErrorResult("Seçilen departman bulunamadı");
                }

                var gorev = _mapper.Map<Gorev>(dto);
                await _gorevRepository.AddAsync(gorev);
                await _unitOfWork.SaveChangesAsync();

                var gorevDto = _mapper.Map<GorevDto>(gorev);
                return ApiResponse<GorevDto>.SuccessResult(gorevDto, "Görev başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                return ApiResponse<GorevDto>.ErrorResult($"Görev oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<GorevDto>> UpdateAsync(GorevUpdateDto dto)
        {
            try
            {
                var gorev = await _gorevRepository.GetByIdAsync(dto.Id);
                if (gorev == null)
                {
                    return ApiResponse<GorevDto>.ErrorResult("Görev bulunamadı");
                }

                // Departman kontrolü
                var departman = await _departmanRepository.GetByIdAsync(dto.DepartmanId);
                if (departman == null)
                {
                    return ApiResponse<GorevDto>.ErrorResult("Seçilen departman bulunamadı");
                }

                _mapper.Map(dto, gorev);
                await _gorevRepository.UpdateAsync(gorev);
                await _unitOfWork.SaveChangesAsync();

                var gorevDto = _mapper.Map<GorevDto>(gorev);
                return ApiResponse<GorevDto>.SuccessResult(gorevDto, "Görev başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return ApiResponse<GorevDto>.ErrorResult($"Görev güncellenirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var gorev = await _gorevRepository.GetByIdAsync(id);
                if (gorev == null)
                {
                    return ApiResponse.ErrorResult("Görev bulunamadı");
                }

                await _gorevRepository.DeleteAsync(gorev);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.SuccessResult("Görev başarıyla silindi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Görev silinirken hata oluştu: {ex.Message}");
            }
        }
        public async Task<ApiResponse> UpdateDurumAsync(GorevDurumGuncellemeDto dto)
        {
            try
            {
                var gorev = await _uretimGoreviRepository.GetByIdAsync(dto.GorevId);
                if (gorev == null)
                    return ApiResponse.ErrorResult("Görev bulunamadı");

                var eskiDurum = gorev.Durum;
                gorev.Durum = dto.YeniDurum;
                gorev.Notlar = dto.Aciklama;

                switch (dto.YeniDurum)
                {
                    case GorevDurum.Basladi:
                    case GorevDurum.DevamEdiyor:
                        // İlk kez başlatılıyorsa başlangıç zamanını kaydet
                        if (gorev.GercekBaslangic == null)
                            gorev.GercekBaslangic = DateTime.UtcNow;
                        break;

                    case GorevDurum.Tamamlandi:
                        gorev.GercekBitis = DateTime.UtcNow;
                        // Eğer başlangıç zamanı yoksa, şimdi kaydet
                        if (gorev.GercekBaslangic == null)
                            gorev.GercekBaslangic = DateTime.UtcNow;
                        break;

                    case GorevDurum.Bekletildi:
                        // Bekletme zamanını kaydetmek isterseniz
                        // gorev.BekletmeTarihi = DateTime.UtcNow;
                        break;
                }

                await _unitOfWork.SaveChangesAsync();
                return ApiResponse.SuccessResult("Görev durumu güncellendi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Görev durumu güncellenirken hata: {ex.Message}");
            }
        }

    }
}

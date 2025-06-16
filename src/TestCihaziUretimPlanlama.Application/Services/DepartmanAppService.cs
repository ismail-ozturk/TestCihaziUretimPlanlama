using AutoMapper;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class DepartmanAppService
    {
        private readonly IDepartmanRepository _departmanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmanAppService(
            IDepartmanRepository departmanRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _departmanRepository = departmanRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<DepartmanDto>>> GetAllAsync()
        {
            try
            {
                var departmanlar = await _departmanRepository.GetAllAsync();
                var departmanDtos = _mapper.Map<List<DepartmanDto>>(departmanlar);

                return ApiResponse<List<DepartmanDto>>.SuccessResult(departmanDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<DepartmanDto>>.ErrorResult($"Departmanlar getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<DepartmanDto>>> GetAktifDepartmanlarAsync()
        {
            try
            {
                var departmanlar = await _departmanRepository.GetAktifDepartmanlarAsync();
                var departmanDtos = _mapper.Map<List<DepartmanDto>>(departmanlar);

                return ApiResponse<List<DepartmanDto>>.SuccessResult(departmanDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<DepartmanDto>>.ErrorResult($"Aktif departmanlar getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DepartmanDetayDto>> GetByIdAsync(int id)
        {
            try
            {
                var departman = await _departmanRepository.GetByIdAsync(id);
                if (departman == null)
                {
                    return ApiResponse<DepartmanDetayDto>.ErrorResult("Departman bulunamadı");
                }

                var departmanDto = _mapper.Map<DepartmanDetayDto>(departman);
                return ApiResponse<DepartmanDetayDto>.SuccessResult(departmanDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmanDetayDto>.ErrorResult($"Departman getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DepartmanDto>> CreateAsync(DepartmanCreateDto dto)
        {
            try
            {
                // Ad kontrolü
                var mevcutDepartman = await _departmanRepository.AdMevcutMuAsync(dto.Ad);
                if (mevcutDepartman)
                {
                    return ApiResponse<DepartmanDto>.ErrorResult("Bu isimde bir departman zaten mevcut");
                }

                var departman = _mapper.Map<Departman>(dto);
                await _departmanRepository.AddAsync(departman);
                await _unitOfWork.SaveChangesAsync();

                var departmanDto = _mapper.Map<DepartmanDto>(departman);
                return ApiResponse<DepartmanDto>.SuccessResult(departmanDto, "Departman başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmanDto>.ErrorResult($"Departman oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<DepartmanDto>> UpdateAsync(DepartmanUpdateDto dto)
        {
            try
            {
                var departman = await _departmanRepository.GetByIdAsync(dto.Id);
                if (departman == null)
                {
                    return ApiResponse<DepartmanDto>.ErrorResult("Departman bulunamadı");
                }

                // Ad kontrolü (kendisi hariç)
                var mevcutDepartman = await _departmanRepository.AdMevcutMuAsync(dto.Ad, dto.Id);
                if (mevcutDepartman)
                {
                    return ApiResponse<DepartmanDto>.ErrorResult("Bu isimde bir departman zaten mevcut");
                }

                _mapper.Map(dto, departman);
                await _departmanRepository.UpdateAsync(departman);
                await _unitOfWork.SaveChangesAsync();

                var departmanDto = _mapper.Map<DepartmanDto>(departman);
                return ApiResponse<DepartmanDto>.SuccessResult(departmanDto, "Departman başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmanDto>.ErrorResult($"Departman güncellenirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var departman = await _departmanRepository.GetByIdAsync(id);
                if (departman == null)
                {
                    return ApiResponse.ErrorResult("Departman bulunamadı");
                }

                await _departmanRepository.DeleteAsync(departman);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.SuccessResult("Departman başarıyla silindi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Departman silinirken hata oluştu: {ex.Message}");
            }
        }
    }
}

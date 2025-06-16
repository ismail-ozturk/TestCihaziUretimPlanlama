using AutoMapper;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class PersonelAppService
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly IDepartmanRepository _departmanRepository;
        private readonly IGorevRepository _gorevRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonelAppService(
            IPersonelRepository personelRepository,
            IDepartmanRepository departmanRepository,
            IGorevRepository gorevRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _personelRepository = personelRepository;
            _departmanRepository = departmanRepository;
            _gorevRepository = gorevRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<PersonelDto>>> GetAllAsync()
        {
            try
            {
                var personeller = await _personelRepository.GetAllAsync();
                var personelDtos = _mapper.Map<List<PersonelDto>>(personeller);

                return ApiResponse<List<PersonelDto>>.SuccessResult(personelDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<PersonelDto>>.ErrorResult($"Personeller getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<PersonelDto>>> GetByDepartmanIdAsync(int departmanId)
        {
            try
            {
                var personeller = await _personelRepository.GetByDepartmanIdAsync(departmanId);
                var personelDtos = _mapper.Map<List<PersonelDto>>(personeller);

                return ApiResponse<List<PersonelDto>>.SuccessResult(personelDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<PersonelDto>>.ErrorResult($"Departman personelleri getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PersonelDto>> GetByIdAsync(int id)
        {
            try
            {
                var personel = await _personelRepository.GetByIdAsync(id);
                if (personel == null)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Personel bulunamadı");
                }

                var personelDto = _mapper.Map<PersonelDto>(personel);
                return ApiResponse<PersonelDto>.SuccessResult(personelDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<PersonelDto>.ErrorResult($"Personel getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PersonelDto>> CreateAsync(PersonelCreateDto dto)
        {
            try
            {
                // Departman kontrolü
                var departman = await _departmanRepository.GetByIdAsync(dto.DepartmanId);
                if (departman == null)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Seçilen departman bulunamadı");
                }

                // Personel numarası kontrolü
                var mevcutPersonel = await _personelRepository.PersonelNoMevcutMuAsync(dto.PersonelNo);
                if (mevcutPersonel)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Bu personel numarası zaten mevcut");
                }

                await _unitOfWork.BeginTransactionAsync();

                var personel = _mapper.Map<Personel>(dto);
                await _personelRepository.AddAsync(personel);
                await _unitOfWork.SaveChangesAsync();

                // Görev yetkinliklerini ekle
                if (dto.GorevYetkinlikleri?.Any() == true)
                {
                    foreach (var gorevId in dto.GorevYetkinlikleri)
                    {
                        var gorev = await _gorevRepository.GetByIdAsync(gorevId);
                        if (gorev != null)
                        {
                            personel.GorevYetkinlikleri.Add(new PersonelGorevYetkinlik
                            {
                                PersonelId = personel.Id,
                                GorevId = gorevId
                            });
                        }
                    }
                    await _unitOfWork.SaveChangesAsync();
                }

                await _unitOfWork.CommitTransactionAsync();

                var personelDto = _mapper.Map<PersonelDto>(personel);
                return ApiResponse<PersonelDto>.SuccessResult(personelDto, "Personel başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<PersonelDto>.ErrorResult($"Personel oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<PersonelDto>> UpdateAsync(PersonelUpdateDto dto)
        {
            try
            {
                var personel = await _personelRepository.GetByIdAsync(dto.Id);
                if (personel == null)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Personel bulunamadı");
                }

                // Departman kontrolü
                var departman = await _departmanRepository.GetByIdAsync(dto.DepartmanId);
                if (departman == null)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Seçilen departman bulunamadı");
                }

                // Personel numarası kontrolü (kendisi hariç)
                var mevcutPersonel = await _personelRepository.PersonelNoMevcutMuAsync(dto.PersonelNo, dto.Id);
                if (mevcutPersonel)
                {
                    return ApiResponse<PersonelDto>.ErrorResult("Bu personel numarası zaten mevcut");
                }

                await _unitOfWork.BeginTransactionAsync();

                _mapper.Map(dto, personel);
                await _personelRepository.UpdateAsync(personel);

                // Mevcut yetkinlikleri temizle ve yenilerini ekle
                personel.GorevYetkinlikleri.Clear();
                if (dto.GorevYetkinlikleri?.Any() == true)
                {
                    foreach (var gorevId in dto.GorevYetkinlikleri)
                    {
                        var gorev = await _gorevRepository.GetByIdAsync(gorevId);
                        if (gorev != null)
                        {
                            personel.GorevYetkinlikleri.Add(new PersonelGorevYetkinlik
                            {
                                PersonelId = personel.Id,
                                GorevId = gorevId
                            });
                        }
                    }
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var personelDto = _mapper.Map<PersonelDto>(personel);
                return ApiResponse<PersonelDto>.SuccessResult(personelDto, "Personel başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<PersonelDto>.ErrorResult($"Personel güncellenirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var personel = await _personelRepository.GetByIdAsync(id);
                if (personel == null)
                {
                    return ApiResponse.ErrorResult("Personel bulunamadı");
                }

                await _personelRepository.DeleteAsync(personel);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.SuccessResult("Personel başarıyla silindi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Personel silinirken hata oluştu: {ex.Message}");
            }
        }
    }
}

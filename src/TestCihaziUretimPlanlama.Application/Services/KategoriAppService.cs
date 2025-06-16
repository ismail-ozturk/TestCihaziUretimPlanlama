using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Entities;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Repositories;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class KategoriAppService
    {
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IGorevRepository _gorevRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KategoriAppService(
            IKategoriRepository kategoriRepository,
            IGorevRepository gorevRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _kategoriRepository = kategoriRepository;
            _gorevRepository = gorevRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<KategoriDto>>> GetAllAsync()
        {
            try
            {
                var kategoriler = await _kategoriRepository.GetAllAsync();
                var kategoriDtos = _mapper.Map<List<KategoriDto>>(kategoriler);

                return ApiResponse<List<KategoriDto>>.SuccessResult(kategoriDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<KategoriDto>>.ErrorResult($"Kategoriler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<List<KategoriDto>>> GetAktifKategorilerAsync()
        {
            try
            {
                var kategoriler = await _kategoriRepository.GetAktifKategorilerAsync();
                var kategoriDtos = _mapper.Map<List<KategoriDto>>(kategoriler);

                return ApiResponse<List<KategoriDto>>.SuccessResult(kategoriDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<List<KategoriDto>>.ErrorResult($"Aktif kategoriler getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<KategoriDetayDto>> GetByIdAsync(int id)
        {
            try
            {
                var kategori = await _kategoriRepository.GetDetayliKategoriAsync(id);
                if (kategori == null)
                {
                    return ApiResponse<KategoriDetayDto>.ErrorResult("Kategori bulunamadı");
                }

                var kategoriDto = _mapper.Map<KategoriDetayDto>(kategori);

                // Bağımlılıkları ayrıca getir ve manuel doldur
                var bagimliliklar = await _kategoriRepository.GetBagimliliklarAsync(id);
                var sablonlar = await _kategoriRepository.GetGorevSablonlariAsync(id);

                // Bağımlılık DTO'larını manuel oluştur
                kategoriDto.Bagimliliklar = bagimliliklar.Select(b => new KategoriGorevBagimlilikDto
                {
                    Id = b.Id,
                    OncuKategoriGorevSablonuId = b.OncuKategoriGorevSablonuId,
                    ArdilKategoriGorevSablonuId = b.ArdilKategoriGorevSablonuId,
                    BagimlilikTipi = b.BagimlilikTipi,
                    GecikmeGunu = b.GecikmeGunu,
                    OncuGorevAdi = sablonlar.FirstOrDefault(s => s.Id == b.OncuKategoriGorevSablonuId)?.Gorev?.Ad ?? "",
                    OncuGorevSira = sablonlar.FirstOrDefault(s => s.Id == b.OncuKategoriGorevSablonuId)?.Sira ?? 0,
                    ArdilGorevAdi = sablonlar.FirstOrDefault(s => s.Id == b.ArdilKategoriGorevSablonuId)?.Gorev?.Ad ?? "",
                    ArdilGorevSira = sablonlar.FirstOrDefault(s => s.Id == b.ArdilKategoriGorevSablonuId)?.Sira ?? 0
                }).ToList();

                return ApiResponse<KategoriDetayDto>.SuccessResult(kategoriDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<KategoriDetayDto>.ErrorResult($"Kategori getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<KategoriDto>> CreateAsync(KategoriCreateDto dto)
        {
            try
            {
                // Ad kontrolü
                var mevcutKategori = await _kategoriRepository.AdMevcutMuAsync(dto.Ad);
                if (mevcutKategori)
                {
                    return ApiResponse<KategoriDto>.ErrorResult("Bu isimde bir kategori zaten mevcut");
                }

                await _unitOfWork.BeginTransactionAsync();

                var kategori = _mapper.Map<Kategori>(dto);
                await _kategoriRepository.AddAsync(kategori);
                await _unitOfWork.SaveChangesAsync();

                // Görev şablonlarını ekle
                if (dto.GorevSablonlari?.Any() == true)
                {
                    await GorevSablonlariniEkleAsync(kategori.Id, dto.GorevSablonlari);
                }

                await _unitOfWork.CommitTransactionAsync();

                var kategoriDto = _mapper.Map<KategoriDto>(kategori);
                return ApiResponse<KategoriDto>.SuccessResult(kategoriDto, "Kategori başarıyla oluşturuldu");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<KategoriDto>.ErrorResult($"Kategori oluşturulurken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse<KategoriDto>> UpdateAsync(KategoriUpdateDto dto)
        {
            try
            {
                var kategori = await _kategoriRepository.GetByIdAsync(dto.Id);
                if (kategori == null)
                {
                    return ApiResponse<KategoriDto>.ErrorResult("Kategori bulunamadı");
                }

                // Ad kontrolü (kendisi hariç)
                var mevcutKategori = await _kategoriRepository.AdMevcutMuAsync(dto.Ad, dto.Id);
                if (mevcutKategori)
                {
                    return ApiResponse<KategoriDto>.ErrorResult("Bu isimde bir kategori zaten mevcut");
                }

                await _unitOfWork.BeginTransactionAsync();

                _mapper.Map(dto, kategori);
                await _kategoriRepository.UpdateAsync(kategori);

                // Mevcut şablonları temizle ve yenilerini ekle
                await MevcutSablonlariTemizleAsync(kategori.Id);
                if (dto.GorevSablonlari?.Any() == true)
                {
                    await GorevSablonlariniEkleAsync(kategori.Id, dto.GorevSablonlari);
                }

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var kategoriDto = _mapper.Map<KategoriDto>(kategori);
                return ApiResponse<KategoriDto>.SuccessResult(kategoriDto, "Kategori başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return ApiResponse<KategoriDto>.ErrorResult($"Kategori güncellenirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            try
            {
                var kategori = await _kategoriRepository.GetByIdAsync(id);
                if (kategori == null)
                {
                    return ApiResponse.ErrorResult("Kategori bulunamadı");
                }

                await _kategoriRepository.DeleteAsync(kategori);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse.SuccessResult("Kategori başarıyla silindi");
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Kategori silinirken hata oluştu: {ex.Message}");
            }
        }

        private async Task GorevSablonlariniEkleAsync(int kategoriId, List<KategoriGorevSablonuCreateDto> sablonlar)
        {
            var kategoriRepo = (KategoriRepository)_kategoriRepository;
            var sablonEntities = new List<KategoriGorevSablonu>();

            foreach (var sablon in sablonlar.OrderBy(s => s.Sira))
            {
                var gorev = await _gorevRepository.GetByIdAsync(sablon.GorevId);
                if (gorev == null) continue;

                var sablonEntity = new KategoriGorevSablonu
                {
                    KategoriId = kategoriId,
                    GorevId = sablon.GorevId,
                    Sira = sablon.Sira,
                    OzelSure = sablon.OzelSure
                };

                sablonEntities.Add(sablonEntity);
            }

            // Şablonları kaydet
            foreach (var entity in sablonEntities)
            {
                await kategoriRepo.Context.KategoriGorevSablonlari.AddAsync(entity);
            }
            await _unitOfWork.SaveChangesAsync();

            // Bağımlılıkları ekle
            await BagimliliklariEkleAsync(sablonlar, sablonEntities);
        }

        private async Task BagimliliklariEkleAsync(List<KategoriGorevSablonuCreateDto> sablonlar, List<KategoriGorevSablonu> sablonEntities)
        {
            var kategoriRepo = (KategoriRepository)_kategoriRepository;

            foreach (var sablon in sablonlar)
            {
                var ardilSablon = sablonEntities.FirstOrDefault(s => s.GorevId == sablon.GorevId);
                if (ardilSablon == null) continue;

                foreach (var oncuGorevId in sablon.OncuGorevSablonIds)
                {
                    var oncuSablon = sablonEntities.FirstOrDefault(s => s.GorevId == oncuGorevId);
                    if (oncuSablon == null) continue;

                    var bagimlilik = new KategoriGorevBagimlilik
                    {
                        OncuKategoriGorevSablonuId = oncuSablon.Id,
                        ArdilKategoriGorevSablonuId = ardilSablon.Id,
                        BagimlilikTipi = Core.Enums.BagimlilikTipi.FinishToStart
                    };

                    await kategoriRepo.Context.KategoriGorevBagimliliklari.AddAsync(bagimlilik);
                }
            }

            await _unitOfWork.SaveChangesAsync();
        }

        private async Task MevcutSablonlariTemizleAsync(int kategoriId)
        {
            var kategoriRepo = (KategoriRepository)_kategoriRepository;

            var mevcutSablonlar = await kategoriRepo.Context.KategoriGorevSablonlari
                .Where(s => s.KategoriId == kategoriId)
                .ToListAsync();

            foreach (var sablon in mevcutSablonlar)
            {
                sablon.IsDeleted = true;
            }

            var mevcutBagimliliklar = await kategoriRepo.Context.KategoriGorevBagimliliklari
                .Where(b => mevcutSablonlar.Any(s => s.Id == b.OncuKategoriGorevSablonuId || s.Id == b.ArdilKategoriGorevSablonuId))
                .ToListAsync();

            foreach (var bagimlilik in mevcutBagimliliklar)
            {
                bagimlilik.IsDeleted = true;
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestCihaziUretimPlanlama.Core.DTOs.Common;
using TestCihaziUretimPlanlama.Core.DTOs.Request;
using TestCihaziUretimPlanlama.Core.DTOs.Response;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;

namespace TestCihaziUretimPlanlama.Application.Services
{
    public class PlanlamaAppService
    {
        private readonly IPlanlamaService _planlamaService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public PlanlamaAppService(IPlanlamaService planlamaService, IMapper mapper, ApplicationDbContext context)
        {
            _planlamaService = planlamaService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse<PlanlamaResultDto>> PlanlamaYapAsync(PlanlamaRequestDto dto)
        {
            try
            {
                bool result;
                int planlananSiparis = 0;

                if (dto.TumSiparisleriPlanla)
                {
                    result = await _planlamaService.TumSiparisleriYenidenPlanlaAsync();
                    // Tüm siparişler planlandı
                }
                else if (dto.SiparisId.HasValue)
                {
                    result = await _planlamaService.SiparisiPlanlaAsync(dto.SiparisId.Value);
                    planlananSiparis = result ? 1 : 0;
                }
                else
                {
                    return ApiResponse<PlanlamaResultDto>.ErrorResult("Sipariş ID veya tüm siparişleri planlama seçeneği belirtilmelidir");
                }

                var planlamaResult = new PlanlamaResultDto
                {
                    Success = result,
                    Message = result ? "Planlama başarıyla tamamlandı" : "Planlama sırasında hata oluştu",
                    PlanlananSiparisSayisi = planlananSiparis,
                    PlanlamaTarihi = DateTime.UtcNow
                };

                return ApiResponse<PlanlamaResultDto>.SuccessResult(planlamaResult);
            }
            catch (Exception ex)
            {
                var planlamaResult = new PlanlamaResultDto
                {
                    Success = false,
                    Message = "Planlama sırasında hata oluştu",
                    Hatalar = new List<string> { ex.Message },
                    PlanlamaTarihi = DateTime.UtcNow
                };

                return ApiResponse<PlanlamaResultDto>.ErrorResult("Planlama sırasında hata oluştu", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<PersonelPlanDto>> GetPersonelPlanAsync(PersonelPlanSorguDto dto)
        {
            try
            {
                var gorevler = await _planlamaService.GetPersonelPlaniniAsync(dto.PersonelId, dto.BaslangicTarihi, dto.BitisTarihi);
                var isYuku = await _planlamaService.PersonelIsYukuHesaplaAsync(dto.PersonelId, dto.BaslangicTarihi, dto.BitisTarihi);

                var gorevDtos = _mapper.Map<List<UretimGoreviDto>>(gorevler);

                var personelPlan = new PersonelPlanDto
                {
                    PersonelId = dto.PersonelId,
                    BaslangicTarihi = dto.BaslangicTarihi,
                    BitisTarihi = dto.BitisTarihi,
                    IsYukuYuzdesi = isYuku,
                    Gorevler = gorevDtos
                };

                return ApiResponse<PersonelPlanDto>.SuccessResult(personelPlan);
            }
            catch (Exception ex)
            {
                return ApiResponse<PersonelPlanDto>.ErrorResult($"Personel planı getirilirken hata oluştu: {ex.Message}");
            }
        }

        public async Task<ApiResponse> GorevZamaniGuncelleAsync(GorevZamaniGuncellemeDto dto)
        {
            try
            {
                var result = await _planlamaService.GorevZamaniGuncelleAsync(dto.UretimGoreviId, dto.YeniBaslangicZamani);

                if (result)
                {
                    return ApiResponse.SuccessResult("Görev zamanı başarıyla güncellendi");
                }
                else
                {
                    return ApiResponse.ErrorResult("Görev zamanı güncellenemedi");
                }
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResult($"Görev zamanı güncellenirken hata oluştu: {ex.Message}");
            }
        }

        // Gantt Chart için yeni metodlar
        public async Task<ApiResponse<GanttDataDto>> GetGanttDataAsync(DateTime baslangic, DateTime bitis,
            string siparisNo = null, string departman = null, string personel = null)
        {
            try
            {
                var query = _context.UretimGorevleri
                    .Include(ug => ug.Siparis)
                    .Include(ug => ug.Gorev)
                        .ThenInclude(g => g.Departman)
                    .Include(ug => ug.AtananPersonel)
                    .Include(ug => ug.OncuBagimliliklar)
                    .Include(ug => ug.ArdilBagimliliklar)
                    .Where(ug => !ug.IsDeleted &&
                                ug.PlanlananBaslangic.HasValue &&
                                ug.PlanlananBaslangic >= baslangic &&
                                ug.PlanlananBaslangic <= bitis);

                // Filtreler
                if (!string.IsNullOrEmpty(siparisNo))
                {
                    query = query.Where(ug => ug.Siparis.UretimNumarasi.Contains(siparisNo));
                }

                if (!string.IsNullOrEmpty(departman))
                {
                    query = query.Where(ug => ug.Gorev.Departman.Ad == departman);
                }

                if (!string.IsNullOrEmpty(personel))
                {
                    query = query.Where(ug => ug.AtananPersonel != null &&
                                             (ug.AtananPersonel.Ad + " " + ug.AtananPersonel.Soyad).Contains(personel));
                }

                // Verileri memory'e al - EF sorgusu burada biter
                var uretimGorevleri = await query.ToListAsync();

                var ganttData = new GanttDataDto();

                // Siparişleri grupla
                var siparisGruplari = uretimGorevleri.GroupBy(ug => ug.SiparisId);

                foreach (var siparisGrubu in siparisGruplari)
                {
                    var siparis = siparisGrubu.First().Siparis;

                    // Sipariş ana görevi
                    ganttData.Tasks.Add(new GanttTaskDto
                    {
                        Id = $"siparis_{siparis.Id}",
                        Text = $"{siparis.UretimNumarasi} ({siparis.Musteri})",
                        StartDate = siparisGrubu.Min(g => g.PlanlananBaslangic ?? DateTime.UtcNow),
                        EndDate = siparisGrubu.Max(g => g.PlanlananBitis ?? DateTime.UtcNow),
                        Type = "project",
                        Color = GetMusteriColor(siparis.Musteri.ToString()),
                        SiparisNo = siparis.UretimNumarasi,
                        Musteri = siparis.Musteri.ToString(),
                        Oncelik = siparis.Oncelik,
                        Progress = CalculateOrderProgress(siparisGrubu.ToList())
                    });

                    // Görevleri ekle
                    foreach (var gorev in siparisGrubu.OrderBy(g => g.PlanlananBaslangic))
                    {
                        ganttData.Tasks.Add(new GanttTaskDto
                        {
                            Id = $"task_{gorev.Id}",
                            Text = $"{gorev.Gorev.Ad} ({gorev.Sure}h)",
                            StartDate = gorev.PlanlananBaslangic ?? DateTime.UtcNow,
                            EndDate = gorev.PlanlananBitis ?? DateTime.UtcNow,
                            Duration = gorev.Sure,
                            Progress = GetTaskProgress(gorev.Durum),
                            Parent = $"siparis_{siparis.Id}",
                            Type = "task",
                            ResourceId = $"personel_{gorev.AtananPersonelId}",
                            Color = GetDepartmentColor(gorev.Gorev.Departman.Ad),
                            SiparisNo = siparis.UretimNumarasi,
                            DepartmanAdi = gorev.Gorev.Departman.Ad,
                            PersonelAdi = gorev.AtananPersonel != null ? $"{gorev.AtananPersonel.Ad} {gorev.AtananPersonel.Soyad}" : "Atanmamış",
                            GorevAdi = gorev.Gorev.Ad,
                            Durum = gorev.Durum.ToString(),
                            Sure = gorev.Sure,
                            Musteri = siparis.Musteri.ToString(),
                            Oncelik = siparis.Oncelik
                        });
                    }

                    // Bağımlılıkları ekle
                    foreach (var gorev in siparisGrubu)
                    {
                        foreach (var bagimlilik in gorev.ArdilBagimliliklar.Where(b => !b.IsDeleted))
                        {
                            ganttData.Links.Add(new GanttLinkDto
                            {
                                Id = $"link_{bagimlilik.Id}",
                                Source = $"task_{bagimlilik.OncuUretimGoreviId}",
                                Target = $"task_{bagimlilik.ArdilUretimGoreviId}",
                                Type = "finish_to_start" // String olarak sabit değer
                            });
                        }
                    }
                }

                // Filtre seçeneklerini hazırla
                ganttData.Filters = await PrepareFiltersAsync();

                return ApiResponse<GanttDataDto>.SuccessResult(ganttData);
            }
            catch (Exception ex)
            {
                return ApiResponse<GanttDataDto>.ErrorResult($"Gantt verileri getirilirken hata: {ex.Message}");
            }
        }

        private async Task<GanttFiltersDto> PrepareFiltersAsync()
        {
            var filters = new GanttFiltersDto();

            // Siparişler - Basit projection
            var siparisler = await _context.Siparisler
                .Where(s => !s.IsDeleted)
                .Select(s => new
                {
                    s.UretimNumarasi,
                    Musteri = s.Musteri.ToString()
                })
                .ToListAsync();

            filters.Siparisler = siparisler.Select(s => new FilterOptionDto
            {
                Value = s.UretimNumarasi,
                Text = $"{s.UretimNumarasi} ({s.Musteri})",
                Color = GetMusteriColor(s.Musteri)
            }).ToList();

            // Departmanlar - Basit projection
            var departmanlar = await _context.Departmanlar
                .Where(d => !d.IsDeleted && d.Aktif)
                .Select(d => d.Ad)
                .ToListAsync();

            filters.Departmanlar = departmanlar.Select(d => new FilterOptionDto
            {
                Value = d,
                Text = d,
                Color = GetDepartmentColor(d)
            }).ToList();

            // Personeller - Basit projection
            var personeller = await _context.Personeller
                .Include(p => p.Departman)
                .Where(p => !p.IsDeleted && p.Aktif)
                .Select(p => new
                {
                    AdSoyad = p.Ad + " " + p.Soyad,
                    DepartmanAdi = p.Departman.Ad
                })
                .ToListAsync();

            filters.Personeller = personeller.Select(p => new FilterOptionDto
            {
                Value = p.AdSoyad,
                Text = $"{p.AdSoyad} ({p.DepartmanAdi})",
                Color = GetDepartmentColor(p.DepartmanAdi)
            }).ToList();

            // Durumlar
            filters.Durumlar = Enum.GetValues<Core.Enums.GorevDurum>()
                .Select(d => new FilterOptionDto
                {
                    Value = d.ToString(),
                    Text = d.ToString(),
                    Color = GetStatusColor(d)
                })
                .ToList();

            return filters;
        }

        // Static metodlar - Memory leak'i önlemek için
        private static string GetDepartmentColor(string departman)
        {
            return departman switch
            {
                "PMD" => "#e74c3c",
                "CNC" => "#f39c12",
                "Teknik" => "#9b59b6",
                _ => "#95a5a6"
            };
        }

        private static string GetMusteriColor(string musteri)
        {
            return musteri switch
            {
                "Turkiye" => "#27ae60",
                "Almanya" => "#3498db",
                _ => "#95a5a6"
            };
        }

        private static string GetStatusColor(Core.Enums.GorevDurum durum)
        {
            return durum switch
            {
                Core.Enums.GorevDurum.Beklemede => "#95a5a6",
                Core.Enums.GorevDurum.Planli => "#3498db",
                Core.Enums.GorevDurum.DevamEdiyor => "#f39c12",
                Core.Enums.GorevDurum.Tamamlandi => "#27ae60",
                Core.Enums.GorevDurum.Iptal => "#e74c3c",
                Core.Enums.GorevDurum.Bekletildi => "#9b59b6",
                _ => "#95a5a6"
            };
        }

        private static double GetTaskProgress(Core.Enums.GorevDurum durum)
        {
            return durum switch
            {
                Core.Enums.GorevDurum.Beklemede => 0,
                Core.Enums.GorevDurum.Planli => 0,
                Core.Enums.GorevDurum.DevamEdiyor => 0.5,
                Core.Enums.GorevDurum.Tamamlandi => 1.0,
                Core.Enums.GorevDurum.Iptal => 0,
                Core.Enums.GorevDurum.Bekletildi => 0.3,
                _ => 0
            };
        }

        private static double CalculateOrderProgress(List<Core.Entities.UretimGorevi> gorevler)
        {
            if (!gorevler.Any()) return 0;

            var toplamSure = gorevler.Sum(g => g.Sure);
            if (toplamSure == 0) return 0;

            var tamamlananSure = gorevler
                .Where(g => g.Durum == Core.Enums.GorevDurum.Tamamlandi)
                .Sum(g => g.Sure);
            var devamEdenSure = gorevler
                .Where(g => g.Durum == Core.Enums.GorevDurum.DevamEdiyor)
                .Sum(g => g.Sure) * 0.5;

            return (tamamlananSure + devamEdenSure) / toplamSure;
        }
    }
}

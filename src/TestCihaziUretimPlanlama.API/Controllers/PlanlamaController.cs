using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class PlanlamaController : BaseController
    {
        private readonly PlanlamaAppService _planlamaAppService;

        public PlanlamaController(PlanlamaAppService planlamaAppService)
        {
            _planlamaAppService = planlamaAppService;
        }

        /// <summary>
        /// Planlama yapar (tek sipariş veya tüm siparişler)
        /// </summary>
        [HttpPost("planla")]
        public async Task<IActionResult> Planla([FromBody] PlanlamaRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _planlamaAppService.PlanlamaYapAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Personel planını getirir
        /// </summary>
        [HttpPost("personel-plan")]
        public async Task<IActionResult> GetPersonelPlan([FromBody] PersonelPlanSorguDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _planlamaAppService.GetPersonelPlanAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Görev zamanını günceller
        /// </summary>
        [HttpPut("gorev-zamani")]
        public async Task<IActionResult> GorevZamaniGuncelle([FromBody] GorevZamaniGuncellemeDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _planlamaAppService.GorevZamaniGuncelleAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Gantt Chart için planlama verilerini getirir
        /// </summary>
        [HttpGet("gantt-data")]
        public async Task<IActionResult> GetGanttData(
            [FromQuery] DateTime? baslangic,
            [FromQuery] DateTime? bitis,
            [FromQuery] string siparisNo = null,
            [FromQuery] string departman = null,
            [FromQuery] string personel = null)
        {
            try
            {
                var baslangicTarihi = baslangic ?? DateTime.UtcNow.AddDays(-7);
                var bitisTarihi = bitis ?? DateTime.UtcNow.AddYears(1);

                var response = await _planlamaAppService.GetGanttDataAsync(baslangicTarihi, bitisTarihi, siparisNo, departman, personel);
                return HandleResponse(response);
            }
            catch (Exception ex)
            {
                var response = TestCihaziUretimPlanlama.Core.DTOs.Common.ApiResponse<object>.ErrorResult($"Gantt verileri getirilirken hata: {ex.Message}");
                return HandleResponse(response);
            }
        }
    }
}

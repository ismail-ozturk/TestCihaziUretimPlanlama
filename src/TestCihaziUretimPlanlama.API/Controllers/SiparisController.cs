using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class SiparisController : BaseController
    {
        private readonly SiparisAppService _siparisAppService;

        public SiparisController(SiparisAppService siparisAppService)
        {
            _siparisAppService = siparisAppService;
        }

        /// <summary>
        /// Tüm siparişleri getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _siparisAppService.GetAllAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// ID'ye göre sipariş getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _siparisAppService.GetByIdAsync(id);
            return HandleResponse(response);
        }

        /// <summary>
        /// Yeni sipariş oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SiparisCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _siparisAppService.CreateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Sipariş iptal eder
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var response = await _siparisAppService.DeleteAsync(id);
            return HandleResponse(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class DepartmanController : BaseController
    {
        private readonly DepartmanAppService _departmanAppService;

        public DepartmanController(DepartmanAppService departmanAppService)
        {
            _departmanAppService = departmanAppService;
        }

        /// <summary>
        /// Tüm departmanları getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _departmanAppService.GetAllAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// Aktif departmanları getirir
        /// </summary>
        [HttpGet("aktif")]
        public async Task<IActionResult> GetAktifDepartmanlar()
        {
            var response = await _departmanAppService.GetAktifDepartmanlarAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// ID'ye göre departman getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _departmanAppService.GetByIdAsync(id);
            return HandleResponse(response);
        }

        /// <summary>
        /// Yeni departman oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmanCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _departmanAppService.CreateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Departman günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmanUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID uyumsuzluğu");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _departmanAppService.UpdateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Departman siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _departmanAppService.DeleteAsync(id);
            return HandleResponse(response);
        }
    }
}

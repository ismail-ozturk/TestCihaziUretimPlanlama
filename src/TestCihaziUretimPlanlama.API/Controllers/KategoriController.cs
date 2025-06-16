using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class KategoriController : BaseController
    {
        private readonly KategoriAppService _kategoriAppService;

        public KategoriController(KategoriAppService kategoriAppService)
        {
            _kategoriAppService = kategoriAppService;
        }

        /// <summary>
        /// Tüm kategorileri getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _kategoriAppService.GetAllAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// Aktif kategorileri getirir
        /// </summary>
        [HttpGet("aktif")]
        public async Task<IActionResult> GetAktifKategoriler()
        {
            var response = await _kategoriAppService.GetAktifKategorilerAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// ID'ye göre kategori getirir (görev şablonları ve bağımlılıklarla birlikte)
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _kategoriAppService.GetByIdAsync(id);
            return HandleResponse(response);
        }

        /// <summary>
        /// Yeni kategori oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KategoriCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _kategoriAppService.CreateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Kategori günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] KategoriUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID uyumsuzluğu");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _kategoriAppService.UpdateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Kategori siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _kategoriAppService.DeleteAsync(id);
            return HandleResponse(response);
        }
    }
}

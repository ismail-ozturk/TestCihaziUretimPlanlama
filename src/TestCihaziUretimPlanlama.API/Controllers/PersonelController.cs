using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class PersonelController : BaseController
    {
        private readonly PersonelAppService _personelAppService;

        public PersonelController(PersonelAppService personelAppService)
        {
            _personelAppService = personelAppService;
        }

        /// <summary>
        /// Tüm personelleri getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _personelAppService.GetAllAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// Departmana göre personelleri getirir
        /// </summary>
        [HttpGet("departman/{departmanId}")]
        public async Task<IActionResult> GetByDepartmanId(int departmanId)
        {
            var response = await _personelAppService.GetByDepartmanIdAsync(departmanId);
            return HandleResponse(response);
        }

        /// <summary>
        /// ID'ye göre personel getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _personelAppService.GetByIdAsync(id);
            return HandleResponse(response);
        }

        /// <summary>
        /// Yeni personel oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonelCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _personelAppService.CreateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Personel günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonelUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID uyumsuzluğu");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _personelAppService.UpdateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Personel siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _personelAppService.DeleteAsync(id);
            return HandleResponse(response);
        }
    }
}

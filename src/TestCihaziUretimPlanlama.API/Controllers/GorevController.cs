using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Core.DTOs.Request;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    public class GorevController : BaseController
    {
        private readonly GorevAppService _gorevAppService;

        public GorevController(GorevAppService gorevAppService)
        {
            _gorevAppService = gorevAppService;
        }

        /// <summary>
        /// Tüm görevleri getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _gorevAppService.GetAllAsync();
            return HandleResponse(response);
        }

        /// <summary>
        /// Departmana göre görevleri getirir
        /// </summary>
        [HttpGet("departman/{departmanId}")]
        public async Task<IActionResult> GetByDepartmanId(int departmanId)
        {
            var response = await _gorevAppService.GetByDepartmanIdAsync(departmanId);
            return HandleResponse(response);
        }

        /// <summary>
        /// ID'ye göre görev getirir
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _gorevAppService.GetByIdAsync(id);
            return HandleResponse(response);
        }

        /// <summary>
        /// Yeni görev oluşturur
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GorevCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _gorevAppService.CreateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Görev günceller
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GorevUpdateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("ID uyumsuzluğu");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _gorevAppService.UpdateAsync(dto);
            return HandleResponse(response);
        }

        /// <summary>
        /// Görev siler
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _gorevAppService.DeleteAsync(id);
            return HandleResponse(response);
        }
        /// <summary>
        /// Görev durumunu günceller
        /// </summary>
        [HttpPut("{id}/durum")]
        public async Task<IActionResult> UpdateDurum(int id, [FromBody] GorevDurumGuncellemeDto dto)
        {
            if (id != dto.GorevId)
            {
                return BadRequest("ID uyumsuzluğu");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _gorevAppService.UpdateDurumAsync(dto);
            return HandleResponse(response);
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using TestCihaziUretimPlanlama.Core.DTOs.Common;

namespace TestCihaziUretimPlanlama.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResponse<T>(ApiResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        protected IActionResult HandleResponse(ApiResponse response)
        {
            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}

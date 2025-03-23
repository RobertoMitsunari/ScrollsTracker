using Microsoft.AspNetCore.Mvc;

namespace ScrollsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaController : ControllerBase
    {
        private readonly MangaService _service;

        public MangaController(MangaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.ObterMangasAsync();
            return Ok(result);
        }
    }
}
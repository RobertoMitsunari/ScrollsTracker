using Microsoft.AspNetCore.Mvc;

namespace ScrollsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoverController : ControllerBase
    {
        private readonly MangaService _service;

        public CoverController(MangaService service)
        {
            _service = service;
        }

        [HttpGet("{mangaId}")]
        public async Task<IActionResult> GetByMangaId(string mangaId)
        {
            var result = await _service.ObterCoversAsync(mangaId);
            return Ok(result);
        }
    }
}

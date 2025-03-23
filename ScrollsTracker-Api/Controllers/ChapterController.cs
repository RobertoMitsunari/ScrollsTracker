using Microsoft.AspNetCore.Mvc;

namespace ScrollsTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly MangaService _service;

        public ChapterController(MangaService service)
        {
            _service = service;
        }

        [HttpGet("{mangaId}")]
        public async Task<IActionResult> GetByMangaId(string mangaId)
        {
            var result = await _service.ObterCapitulosAsync(mangaId);
            return Ok(result);
        }

    }
}

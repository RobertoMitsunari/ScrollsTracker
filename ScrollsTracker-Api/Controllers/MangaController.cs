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

        [HttpGet("{mangaId}")]
        public async Task<IActionResult> GetAllInfo(string mangaId)
        {
            var manga = await _service.ObterMangasAsync();
            var chapters = await _service.ObterCapitulosAsync(mangaId);
            var covers = await _service.ObterCoversAsync(mangaId);

            return Ok(new
            {
                Manga = manga,
                Chapters = chapters,
                Covers = covers
            });
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorTitulo([FromQuery] string titulo)
        {
            var resultado = await _service.BuscarMangasPorTituloAsync(titulo);
            return Ok(resultado.RootElement);
        }
    }
}
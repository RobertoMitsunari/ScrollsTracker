using Microsoft.AspNetCore.Mvc;
using ScrollsTracker.Api.Model;
using ScrollsTracker.Api.Model.Request;
using ScrollsTracker.Api.Repository.Interface;
using ScrollsTracker.Api.Services.Interface;

namespace ScrollsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrollsTrackerController : ControllerBase
    {
        private readonly IScrollsTrackerRepository _repo;
        private readonly IImagemService _imagemService;
        private readonly MangaService _mangaService;

        public ScrollsTrackerController(IScrollsTrackerRepository repo, IImagemService imagemService, MangaService service)
        {
            _repo = repo;
            _imagemService = imagemService;
            _mangaService = service;
        }

        [HttpGet("Obras")]
        public IActionResult GetObras()
        {
            return Ok(_repo.ObterObras());
        }

        [HttpPost("Obras")]
        public async Task<IActionResult> PostCadastrarObrasAsync([FromBody] ObraRequest obra)
        {
            try
            {
                string? caminhoImagem = null;
                if (obra.Imagem != null)
                {
                    string nomeArquivo = $"{Guid.NewGuid()}.png";
                    caminhoImagem = _imagemService.SalvarImagemBase64(obra.Imagem, nomeArquivo);
                }

                var obraDomain = obra.ToDomain();
                obraDomain.Imagem = caminhoImagem;

                await _repo.CadastrarObrasAsync(obraDomain);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Mangas/{nome}")]
        public async Task<IActionResult> GetMangas(string nome)
        {
            var obra = new Obra() { Titulo = nome };
            await _mangaService.PreencherDadosDaObra(obra);
            return Ok(obra);
        }

        [HttpGet("imagens/{nomeArquivo}")]
        public IActionResult GetImagem(string nomeArquivo)
        {
            try
            {
                string pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                string caminhoArquivo = Path.Combine(pastaDestino, nomeArquivo);

                if (!System.IO.File.Exists(caminhoArquivo))
                {
                    return NotFound(new { message = "Imagem não encontrada" });
                }

                string contentType = "image/png";

                return PhysicalFile(caminhoArquivo, contentType);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

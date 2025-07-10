using Microsoft.AspNetCore.Mvc;
using ScrollsTracker.Application.Services;
using ScrollsTracker.Domain.Interfaces;
using ScrollsTracker.Domain.Models;
using ScrollsTracker.Infra.Repository.Interface;

namespace ScrollsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrollsTrackerController : ControllerBase
    {
        //TODO: Passar a repo para uma service
        private readonly IScrollsTrackerRepository _repo;
        private readonly IObraAggregatorService _obraAggregator;

		public ScrollsTrackerController(IScrollsTrackerRepository repo, IObraAggregatorService obraAggregator)
		{
			_repo = repo;
			_obraAggregator = obraAggregator;
		}

		[HttpGet("Obras")]
        public IActionResult Get()
        {
            return Ok(_repo.ObterObras());
        }

		[HttpGet("ProcurarObra")]
		public async Task<IActionResult> ProcurarObraAsync(string titulo)
		{
			return Ok(await _obraAggregator.BuscarObraAgregadaAsync(titulo));
		}

		//[HttpPost("CadastrarObra")]
  //      public async Task<IActionResult> CadastrarObraAsync([FromBody] Obra obra)
  //      {
  //          try
  //          {
  //              string? caminhoImagem = null;
  //              if (obra.Imagem != null)
  //              {
  //                  string nomeArquivo = $"{Guid.NewGuid()}.png";
  //                  caminhoImagem = _imagemService.SalvarImagemBase64(obra.Imagem, nomeArquivo);
  //              }

  //              var obraDomain = obra.ToDomain();
  //              obraDomain.Imagem = caminhoImagem;

  //              await _repo.CadastrarObrasAsync(obraDomain);

  //              return Created();
  //          }
  //          catch (Exception ex)
  //          {
  //              return BadRequest(ex.Message);
  //          }
  //      }

        //[HttpGet("Mangas/{nome}")]
        //public async Task<IActionResult> GetMangas(string nome)
        //{
        //    var obra = new Obra() { Titulo = nome };
        //    await _mangaService.PreencherDadosDaObra(obra);
        //    return Ok(obra);
        //}

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

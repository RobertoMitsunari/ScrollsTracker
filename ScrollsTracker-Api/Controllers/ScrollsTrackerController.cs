using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScrollsTracker.Api.Requests;
using ScrollsTracker.Application.Commands;
using ScrollsTracker.Domain.Interfaces.Facade;
using ScrollsTracker.Domain.Models;

namespace ScrollsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrollsTrackerController : ControllerBase
    {
		private readonly IObraFacade _obraFacade;
        private readonly IMediator _mediator;
		private readonly IMapper _mapper;

		public ScrollsTrackerController(IObraFacade obraFacade, IMediator mediator, IMapper mapper)
		{
			_obraFacade = obraFacade;
			_mediator = mediator;
			_mapper = mapper;
		}

		[HttpGet("Obras")]
        public IActionResult GetAllObras()
        {
            return Ok(_obraFacade.ObterTodasObrasAsync());
        }

		// Ta aqui só por conveniencia
		[HttpGet("ProcurarObraNasApisExternas")]
		public async Task<IActionResult> ProcurarObraApisExternasAsync(string titulo)
		{
			return Ok(await _obraFacade.BuscarObraAgregadaAsync(titulo));
		}

		[HttpGet("ObterObra")]
		public async Task<IActionResult> GetObraByIdAsync(int id)
		{
			return Ok(await _obraFacade.GetObraByIdAsync(id));
		}

		[HttpPost("CadastrarObra")]
        public async Task<IActionResult> ProcurarECadastrarObraAsync([FromBody] ProcurarECadastrarObraCommand command)
        {
            try
            {
                var obraId = await _mediator.Send(command);

                return Created(nameof(ProcurarECadastrarObraAsync), obraId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

		[HttpPost("AtualizarObra")]
		public async Task<IActionResult> AtualizarObraAsync([FromBody] ObraRequest obraRequest)
		{
			try
			{
				var obra = _mapper.Map<Obra>(obraRequest);
				var result = await _obraFacade.UpdateObra(obra);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("DeletarObra")]
		public async Task<IActionResult> DeletarObraAsync(int id)
		{
			try
			{
				var result = await _obraFacade.DeleteObraById(id);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// TODO: Refatorar?
		[Obsolete]
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

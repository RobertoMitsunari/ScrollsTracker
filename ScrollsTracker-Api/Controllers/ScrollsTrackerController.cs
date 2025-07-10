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

		[HttpPost("CadastrarObra")]
        public async Task<IActionResult> CadastrarObraAsync([FromBody] Obra obra)
        {
            try
            {
                await _repo.CadastrarObrasAsync(obra);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

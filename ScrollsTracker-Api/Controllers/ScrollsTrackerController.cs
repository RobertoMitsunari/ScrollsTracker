using Microsoft.AspNetCore.Mvc;
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
        private readonly IObraSource _obraSource;

		public ScrollsTrackerController(IScrollsTrackerRepository repo, IObraSource obraSource)
		{
			_repo = repo;
			_obraSource = obraSource;
		}

		[HttpGet("Obras")]
        public IActionResult Get()
        {
            return Ok(_repo.ObterObras());
        }

		[HttpGet("TesteObras")]
		public async Task<IActionResult> TesteGetAsync(string titulo)
		{
			return Ok(await _obraSource.ObterObraAsync(titulo));
		}

		[HttpPost("Obras")]
        public async Task<IActionResult> PostAsync([FromBody] Obra obra)
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

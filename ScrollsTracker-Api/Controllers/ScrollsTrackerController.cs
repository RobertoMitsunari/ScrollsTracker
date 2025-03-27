using Microsoft.AspNetCore.Mvc;
using ScrollsTracker.Api.Model;
using ScrollsTracker.Api.Repository;
using ScrollsTracker.Api.Repository.Context;
using ScrollsTracker.Api.Repository.Interface;

namespace ScrollsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrollsTrackerController : ControllerBase
    {
        private readonly IScrollsTrackerRepository _repo;

        public ScrollsTrackerController(IScrollsTrackerRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("Obras")]
        public IActionResult Get()
        {
            return Ok(_repo.ObterObras());
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

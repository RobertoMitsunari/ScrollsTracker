﻿using Microsoft.AspNetCore.Mvc;
using ScrollsTracker.Api.Model;
using ScrollsTracker.Api.Repository.Context;

namespace ScrollsTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrollsTrackerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScrollsTrackerController(AppDbContext options)
        {
            _context = options;
        }

        [HttpGet("Obras")]
        public IActionResult Get()
        {
            return Ok(_context.Obras.ToList());
        }

        [HttpPost("Obras")]
        public async Task<IActionResult> PostAsync([FromBody] Obra obra)
        {
            try
            {
                await _context.Obras.AddAsync(obra);
                await _context.SaveChangesAsync();

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

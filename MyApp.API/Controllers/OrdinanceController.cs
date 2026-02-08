using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/ordinance")]
    public class OrdinanceController : ControllerBase
    {
        private readonly IOrdinanceServices _services;

        public OrdinanceController(IOrdinanceServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdinance()
        {
            try
            {
                var ordinance = await _services.GetOrdinanceAsync();
                return Ok(ordinance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdinanceById(int id)
        {
            try
            {
                var ordinance = await _services.GetOrdinanceByIDAsync(id);
                return Ok(ordinance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrdinance(AddOrdinanceDTO dto)
        {
            try
            {
                var ordinance = await _services.AddOrdinanceAsync(dto);
                return Ok(ordinance);
            }

            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrdinance(int id, UpdateOrdinanceDTO dto)
        {
            try
            {
                var ordinance = await _services.UpdateOrdinanceAsync(id, dto);
                return Ok(ordinance);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdinance(int id)
        {
            try
            {
                var ordinance = await _services.DeleteOrdinanceAsync(id);
                return Ok(ordinance);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/complainant")]
    public class ComplainantController : ControllerBase
    {
        private readonly IComplainantServices _complainantServices;
        public ComplainantController(IComplainantServices complainantServices)
        {
            _complainantServices = complainantServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComplainant()
        {
            try
            {
                var complainants = await _complainantServices.GetComplainantsAsync();
                return Ok(complainants);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplainantByID(int id)
        {
            try
            {
                var complainant = await _complainantServices.GetComplainantByIdAsync(id);
                if (!complainant.Success)
                    return NotFound(complainant);

                return Ok(complainant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComplainant(AddComplainantDTO dto)
        {
            try
            {
                var complainant = await _complainantServices.AddComplainantAsync(dto);
                return Ok(complainant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplainant(int id)
        {
            try
            {
                var complainant = await _complainantServices.DeleteComplainantAsync(id);
                if (!complainant.Success)
                    return NotFound(complainant);

                return Ok(complainant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComplainant(UpdateComplainantDTO dto)
        {
            try
            {
                var complainant = await _complainantServices.UpdateComplainantAsync(dto);
                if (!complainant.Success)
                    return NotFound(complainant);

                return Ok(complainant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

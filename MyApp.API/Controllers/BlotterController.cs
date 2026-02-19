using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/blotter")]
    public class BlotterController : ControllerBase
    {
        private readonly IBlotterRegistration _blotterRegistration;
        private readonly IBlotterServices _blotterServices;
        public BlotterController(IBlotterServices blotterServices, IBlotterRegistration blotterRegistration)
        {
            _blotterRegistration = blotterRegistration;
            _blotterServices = blotterServices;
        }

        [HttpPost]
        public async Task<IActionResult> BlotterRegistration(FullBlotterDTO blotterDTO)
        {
            try
            {
                var registerBlotter = await _blotterRegistration.RegisterBlotter(blotterDTO);
                if(registerBlotter.Success)
                {
                    return BadRequest(registerBlotter.Message);
                }

                return Ok(registerBlotter);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

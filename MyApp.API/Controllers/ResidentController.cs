using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/resident")]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentServices _residentServices;
        private readonly IUserServices _userServices;
        private readonly IResidentRegistrationServices _residentRegistrationServices;

        public ResidentController(IResidentServices residentServices, IUserServices userServices, IResidentRegistrationServices residentRegistrationServices)
        {
            _residentServices = residentServices;
            _userServices = userServices;
            _residentRegistrationServices = residentRegistrationServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResident()
        {
            try
            {
                var residents = await _residentServices.GetAllResidentAsync();
                return Ok(residents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidentById(int id)
        {
            try
            {
                var resident = await _residentServices.GetResidentByIdAsync(id);
                if(!resident.Success)
                    return NotFound(resident);

                return Ok(resident);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddResident(ResidentUserDTO dto)
        {
            var response = await _residentRegistrationServices.RegisterResident(dto);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResidents(int id, UpdateResidentDTO dto)
        {
            try
            {
                var response = await _residentServices.UpdateResidentAsync(id, dto);
                if (!response.Success)
                    return NotFound(response);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            try
            {
                var response = await _residentServices.DeleteResidentAsync(id);
                if(!response.Success)
                    return NotFound(response);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

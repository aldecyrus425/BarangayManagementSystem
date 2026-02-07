using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var user = await _userServices.GetUsersAsync();
                if (!user.Success)
                    return NotFound(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userServices.GetUserByIDAsync(id);
                if (!user.Success)
                    return NotFound(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO dto)
        {
            try
            {
                var response = await _userServices.AddUserAsync(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDTO dto)
        {
            try
            {
                var user = await _userServices.UpdateUserAsync(id, dto);
                if (!user.Success)
                    return NotFound(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _userServices.DeleteUserAsync(id);
                if(!user.Success)
                    return NotFound(user);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

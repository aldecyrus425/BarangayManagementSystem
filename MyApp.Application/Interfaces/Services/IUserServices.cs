using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IUserServices
    {
        Task<ResponseDTO<IEnumerable<UserDTO>>> GetUsersAsync();
        Task<ResponseDTO<UserDTO>> GetUserByIDAsync(int id);
        Task<ResponseDTO<UserDTO>> AddUserAsync(AddUserDTO dto);
        Task<ResponseDTO<UserDTO>> DeleteUserAsync(int id);
        Task<ResponseDTO<UserDTO>> UpdateUserAsync(int id, UpdateUserDTO dto);
    }
}

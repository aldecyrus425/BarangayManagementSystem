using MyApp.Application.DTO;
using MyApp.Application.Interfaces;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class UserServices: IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _hasher;

        public UserServices(IUserRepository userRepository, IPasswordHasher Hasher)
        {
            _userRepository = userRepository;
            _hasher = Hasher;
        }

        public async Task<ResponseDTO<UserDTO>> AddUserAsync(AddUserDTO dto)
        {
            string hashPassword = _hasher.Hash(dto.Password);

            var user = new User(
                username: dto.Username,
                password: hashPassword,
                role: dto.Role,
                rq: dto.RQ,
                ra: dto.RA);

            var response = await _userRepository.AddUser(user);

            return new ResponseDTO<UserDTO>
            {
                Success = true,
                Message = "User added successfully.",
                Data = new UserDTO 
                {
                    UserId = response.UserId,
                    Username = response.Username,
                    Role = response.Role,
                    RQ = response.RQ,
                    RA = response.RA
                }
            };
        }

        public async Task<ResponseDTO<UserDTO>> DeleteUserAsync(int id)
        {
            var response = await _userRepository.DeleteUser(id);
            if (!response)
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = "User Not Found."
                };

            await _userRepository.SaveChanges();

            return new ResponseDTO<UserDTO>
            {
                Success = true,
                Message = "User Deleted Successfully."
            };
        }

        public async Task<ResponseDTO<UserDTO>> GetUserByIDAsync(int id)
        {
            var response = await _userRepository.GetUserById(id);
            if(response == null)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            return new ResponseDTO<UserDTO>
            {
                Success = true,
                Message = "User information.",
                Data = new UserDTO
                {
                    UserId = response.UserId,
                    Username = response.Username,
                    Role = response.Role,
                    RQ = response.RQ,
                    RA = response.RA
                }
            };
        }

        public async Task<ResponseDTO<IEnumerable<UserDTO>>> GetUsersAsync()
        {
            var response = await _userRepository.GetAllUsers();

            var user = response.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Username = u.Username,
                Role = u.Role,
                RQ = u.RQ,
                RA = u.RA
            });

            return new ResponseDTO<IEnumerable<UserDTO>>
            {
                Success = true,
                Message = "User's Lists.",
                Data = user
            };
        }

        public async Task<ResponseDTO<UserDTO>> UpdateUserAsync(int id, UpdateUserDTO dto)
        {
            var user = await _userRepository.GetUserById(id);

            if(user == null)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            user.UpdateUser(dto.Username, dto.Role, dto.RQ, dto.RA);

            await _userRepository.SaveChanges();

            return new ResponseDTO<UserDTO>
            {
                Success = true,
                Message = "User updated successfully.",
                Data = new UserDTO
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.Role,
                    RQ = user.RQ,
                    RA = user.RA
                }
            };
        }
    }
}

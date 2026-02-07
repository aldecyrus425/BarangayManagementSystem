using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IResidentServices
    {
        Task<ResponseDTO<IEnumerable<ResidentDTO>>> GetAllResidentAsync();
        Task<ResponseDTO<ResidentDTO>> GetResidentByIdAsync(int id);
        Task<ResponseDTO<ResidentDTO>> AddResidentAsync(AddResidentDTO dto);
        Task<ResponseDTO<ResidentDTO>> UpdateResidentAsync(int id, UpdateResidentDTO dto);
        Task<ResponseDTO<ResidentDTO>> DeleteResidentAsync(int id);
    }
}

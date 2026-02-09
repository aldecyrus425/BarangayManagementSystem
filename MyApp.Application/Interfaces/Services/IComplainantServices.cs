using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IComplainantServices
    {
        Task<ResponseDTO<IEnumerable<ComplainantDTO>>> GetComplainantsAsync();
        Task<ResponseDTO<ComplainantDTO>> GetComplainantByIdAsync(int id);
        Task<ResponseDTO<ComplainantDTO>> AddComplainantAsync(AddComplainantDTO dto);
        Task<ResponseDTO<bool>> DeleteComplainantAsync(int id);
        Task<ResponseDTO<ComplainantDTO>> UpdateComplainantAsync(UpdateComplainantDTO dto);
    }
}

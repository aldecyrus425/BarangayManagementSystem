using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IOrdinanceServices
    {
        Task<ResponseDTO<IEnumerable<OrdinanceDTO>>> GetOrdinanceAsync();
        Task<ResponseDTO<OrdinanceDTO>> GetOrdinanceByIDAsync(int id);
        Task<ResponseDTO<OrdinanceDTO>> AddOrdinanceAsync(AddOrdinanceDTO dto);
        Task<ResponseDTO<OrdinanceDTO>> DeleteOrdinanceAsync(int id);
        Task<ResponseDTO<OrdinanceDTO>> UpdateOrdinanceAsync(int id, UpdateOrdinanceDTO dto);
    }
}

using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IBlotterServices
    {
        Task<ResponseDTO<IEnumerable<BlotterDTO>>> GetBlotterAsync();
        Task<ResponseDTO<BlotterDTO>> GetBlotterByIDAsync(int id);
        Task<ResponseDTO<BlotterDTO>> AddBlotterAsync(AddBlotterDTO dto);
        Task<ResponseDTO<BlotterDTO>> DeleteBlotterAsync(int id);
        Task<ResponseDTO<BlotterDTO>> UpdateBlotterAsync(UpdateBlotterDTO dto);
    }
}

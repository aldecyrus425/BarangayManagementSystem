using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IDefendantServices
    {
        Task<ResponseDTO<IEnumerable<DefendantDTO>>> GetAllDefendantAsync();
        Task<ResponseDTO<DefendantDTO>> GetDefendantByIdAsync(int id);
        Task<ResponseDTO<DefendantDTO>> AddDefendantAsync(AddDefendantDTO dto);
        Task<ResponseDTO<DefendantDTO>> DeleteDefendantAsync(int id);
        Task<ResponseDTO<DefendantDTO>> UpdateDefendantAsync(updateDefendantDTO dto);
    }
}

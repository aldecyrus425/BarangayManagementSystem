using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IBlotterDefendantServices
    {
        Task<ResponseDTO<BlotterDefendantDTO>> AddBlotterDefendantAsync(AddBlotterDefendantDTO dto);
        Task<ResponseDTO<bool>> DeleteDefendantAsync(int id);
    }
}

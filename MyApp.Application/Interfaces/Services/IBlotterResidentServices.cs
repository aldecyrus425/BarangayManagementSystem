using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IBlotterResidentServices
    {
        Task<ResponseDTO<BlotterResidentDTO>> AddBlotterResidentAsync(AddBlotterResidentDTO dto);
        Task<ResponseDTO<bool>> DeleteBlotterResidentAsync(int id);
    }
}

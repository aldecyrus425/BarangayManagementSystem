using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IBlotterRegistration
    {
        Task<ResponseDTO<FullBlotterDTO>> RegisterBlotter(FullBlotterDTO blotter);
    }
}

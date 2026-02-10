using MyApp.Application.DTO;
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
    public class BlotterServices : IBlotterServices
    {
        private readonly IBlotterRepository _blotterRepository;

        public BlotterServices(IBlotterRepository blotterRepository)
        {
            _blotterRepository = blotterRepository;
        }


        public Task<ResponseDTO<BlotterDTO>> DeleteBlotterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<IEnumerable<BlotterDTO>>> GetBlotterAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<BlotterDTO>> GetBlotterByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO<BlotterDTO>> UpdateBlotterAsync(UpdateBlotterDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}

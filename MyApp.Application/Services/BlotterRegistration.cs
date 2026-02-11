using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Persistence;
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
    public class BlotterRegistration : IBlotterRegistration
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlotterRegistration(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<FullBlotterDTO>> RegisterBlotter(FullBlotterDTO blotter)
        {

            await _unitOfWork.BeginTransactionAsync();

            try
            {

               



            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<FullBlotterDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

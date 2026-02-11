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
        private readonly IBlotterServices _blotterServices;
        private readonly IDefendantServices _defendantServices;
        private readonly IComplainantServices _complainantServices;
        private readonly IBlotterDefendantServices _blotterDefendantServices;
        private readonly IBlotterResidentServices _blotterResidentServices;

        public BlotterRegistration(IUnitOfWork unitOfWork, IBlotterServices blotterServices, IDefendantServices defendantServices, IComplainantServices complainantServices, IBlotterDefendantServices blotterDefendantServices, IBlotterResidentServices blotterResidentServices)
        {
            _unitOfWork = unitOfWork;
            _blotterServices = blotterServices;
            _defendantServices = defendantServices;
            _complainantServices = complainantServices;
            _blotterDefendantServices = blotterDefendantServices;
            _blotterResidentServices = blotterResidentServices;
        }

        public async Task<ResponseDTO<FullBlotterDTO>> RegisterBlotter(FullBlotterDTO dto)
        {

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var complainant = new AddComplainantDTO
                {

                };

                var addComplainant = await _complainantServices.AddComplainantAsync(complainant);

                var blotter = new AddBlotterDTO
                {

                };
                var addBlotter = await _blotterServices.AddBlotterAsync(blotter);

                var defendant = new AddDefendantDTO
                {

                };

                var addDefendant = await _defendantServices.AddDefendantAsync(defendant);

                var blotterDefendant = new AddBlotterDefendantDTO
                {

                };

                var addBlotterDefendant = await _blotterDefendantServices.AddBlotterDefendantAsync(blotterDefendant);

                var blotterResident = new AddBlotterResidentDTO
                {

                };

                var addBlotterResident = await _blotterResidentServices.AddBlotterResidentAsync(blotterResident);


                await _unitOfWork.CommitAsync();

                return new ResponseDTO<FullBlotterDTO>
                {
                    Success = true,
                    Message = "Blotter added successfully.",
                    Data = new FullBlotterDTO
                    {

                    }
                };

            }
            catch (ArgumentException ex)
            {
                await _unitOfWork.RollbackAsync();

                return new ResponseDTO<FullBlotterDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

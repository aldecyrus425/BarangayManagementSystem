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

        public BlotterRegistration(IUnitOfWork unitOfWork, IBlotterServices blotterServices, IDefendantServices defendantServices, IComplainantServices complainantServices, IBlotterDefendantServices blotterDefendantServices)
        {
            _unitOfWork = unitOfWork;
            _blotterServices = blotterServices;
            _defendantServices = defendantServices;
            _complainantServices = complainantServices;
            _blotterDefendantServices = blotterDefendantServices;
        }

        public async Task<ResponseDTO<FullBlotterDTO>> RegisterBlotter(FullBlotterDTO dto)
        {

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var complainant = new AddComplainantDTO
                {
                    ComplainantFirstName = dto.Complainant.ComplainantFirstName,
                    ComplainantLastName = dto.Complainant.ComplainantLastName,
                    ComplainantAge = dto.Complainant.ComplainantAge,
                    ComplainantAddress = dto.Complainant.ComplainantAddress,
                    ComplainantContact = dto.Complainant.ComplainantContact
                };

                var addComplainant = await _complainantServices.AddComplainantAsync(complainant);

                var blotter = new AddBlotterDTO
                {
                    BlotterDate = dto.BlotterDate,
                    BlotterComplaint = dto.BlotterComplaint,
                    BlotterActionTaken = dto.BlotterActionTaken,
                    BlotterStatus = dto.BlotterStatus,
                    LocationOfIncidence = dto.LocationOfIncidence,
                    SettlementDate = dto.SettlementDate,
                    ComplainantId = addComplainant.Data.ComplainantId,
                    UserId = dto.UserId
                };
                var addBlotter = await _blotterServices.AddBlotterAsync(blotter);

                var defendant = new AddDefendantDTO
                {
                    DefendantFirstName = dto.Defendant.DefendantFirstName,
                    DefendantLastName = dto.Defendant.DefendantLastName,
                    DefendantAge = dto.Defendant.DefendantAge,
                    DefendantAddress = dto.Defendant.DefendantAddress,
                    DefendantContact = dto.Defendant.DefendantContact,
                    UserID = dto.UserId
                };

                var addDefendant = await _defendantServices.AddDefendantAsync(defendant);

                var blotterDefendant = new AddBlotterDefendantDTO
                {
                    BlotterId = addBlotter.Data.BlotterId,
                    DefendantId = addDefendant.Data.DefendantId,
                    UserId = addDefendant.Data.UserId,
                };

                var addBlotterDefendant = await _blotterDefendantServices.AddBlotterDefendantAsync(blotterDefendant);

                if(!addComplainant.Success || !addBlotter.Success || !addDefendant.Success)
                {
                    await _unitOfWork.RollbackAsync();
                    return new ResponseDTO<FullBlotterDTO>
                    {
                        Success = false,
                        Message = "Something went wrong with adding blotter."
                    };
                }

                await _unitOfWork.CommitAsync();

                return new ResponseDTO<FullBlotterDTO>
                {
                    Success = true,
                    Message = "Blotter added successfully.",
                    Data = dto
                };

            }
            catch (Exception ex)
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

using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Persistence;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class ResidentRegistrationService : IResidentRegistrationServices
    {
        private readonly IUserServices _userServices;
        private readonly IResidentServices _residentServices;
        private readonly IUnitOfWork _unitOfWork;

        public ResidentRegistrationService(IUserServices userServices, IResidentServices residentServices, IUnitOfWork unitOfWork)
        {
            _userServices = userServices;
            _residentServices = residentServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDTO<ResidentUserDTO>> RegisterResident(ResidentUserDTO dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var userResponse = await _userServices.AddUserAsync(new AddUserDTO
                {
                    Username = dto.Username,
                    Password = dto.Password,
                    Role = dto.Role,
                    RQ = dto.RQ,
                    RA = dto.RA
                });

                if (!userResponse.Success || userResponse.Data == null)
                {
                    return new ResponseDTO<ResidentUserDTO>
                    {
                        Success = false,
                        Message = userResponse.Message
                    };
                }


                var residentResponse = await _residentServices.AddResidentAsync(new AddResidentDTO
                {
                    FirstName = dto.FirstName,
                    MiddleName = dto.MiddleName,
                    LastName = dto.LastName,
                    BirthDate = dto.BirthDate,
                    BirthPlace = dto.BirthPlace,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Address = dto.Address,
                    Contact = dto.Contact,
                    CivilStatus = dto.CivilStatus,
                    BloodType = dto.BloodType,
                    Occupation = dto.Occupation,
                    Religion = dto.Religion,
                    Nationality = dto.Nationality,
                    UserId = userResponse.Data.UserId,
                });

                if (!residentResponse.Success || residentResponse.Data == null)
                {
                    return new ResponseDTO<ResidentUserDTO>
                    {
                        Success = false,
                        Message = residentResponse.Message
                    };
                }

                await _unitOfWork.CommitAsync();

                return new ResponseDTO<ResidentUserDTO>
                {
                    Success = true,
                    Message = "Resident Added successfully.",
                    Data = new ResidentUserDTO
                    {
                        Username = userResponse.Data.Username,
                        Role = userResponse.Data.Role,
                        RQ = userResponse.Data.RQ,
                        RA = userResponse.Data.RA,

                        FirstName = residentResponse.Data.FirstName,
                        MiddleName = residentResponse.Data.MiddleName,
                        LastName = residentResponse.Data.LastName,
                        BirthDate = residentResponse.Data.BirthDate,
                        BirthPlace = residentResponse.Data.BirthPlace,
                        Age = residentResponse.Data.Age,
                        Gender = residentResponse.Data.Gender,
                        Address = residentResponse.Data.Address,
                        Contact = residentResponse.Data.Contact,
                        CivilStatus = residentResponse.Data.CivilStatus,
                        BloodType = residentResponse.Data.BloodType,
                        Occupation = residentResponse.Data.Occupation,
                        Religion = residentResponse.Data.Religion,
                        Nationality = residentResponse.Data.Nationality,
                    }
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return new ResponseDTO<ResidentUserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}

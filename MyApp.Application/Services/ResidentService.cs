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
    public class ResidentService : IResidentServices
    {
        private readonly IResidentRepository _residentRepository;
        public ResidentService(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

        public async Task<ResponseDTO<ResidentDTO>> AddResidentAsync(AddResidentDTO dto)
        {
            try
            {
                var resident = new Resident(dto.FirstName, dto.LastName, dto.MiddleName, dto.BirthDate, dto.BirthPlace, dto.Age, dto.Gender, dto.Address, dto.Contact, dto.CivilStatus, dto.BloodType, dto.Occupation, dto.Religion, dto.Nationality, dto.UserId);

                var response = await _residentRepository.AddResidentAsync(resident);

                await _residentRepository.SaveChangesAsync();

                return new ResponseDTO<ResidentDTO>
                {
                    Success = true,
                    Message = "Resident added successfully.",
                    Data = new ResidentDTO
                    {
                        ResidentId = response.ResidentId,
                        FirstName = response.FirstName,
                        MiddleName = response.MiddleName,
                        LastName = response.LastName,
                        BirthDate = response.BirthDate,
                        BirthPlace = response.BirthPlace,
                        Age = response.Age,
                        Gender = response.Gender,
                        Address = response.Address,
                        Contact = response.Contact,
                        CivilStatus = response.CivilStatus,
                        BloodType = response.BloodType,
                        Occupation = response.Occupation,
                        Religion = response.Religion,
                        Nationality = response.Nationality,
                        User = new UserDTO
                        {
                            UserId = response.UserId,
                            Username = response.User.Username,
                            Role = response.User.Role,
                            RQ = response.User.RQ,
                            RA = response.User.RA
                        }
                    }
                };
            }
            catch (ArgumentException ex) {
                return new ResponseDTO<ResidentDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ResidentDTO>> DeleteResidentAsync(int id)
        {
            var resident = await _residentRepository.DeleteResidentAsync(id);
            if (!resident)
            {
                return new ResponseDTO<ResidentDTO>
                {
                    Success = false,
                    Message = "Resident not found."
                };
            }

            await _residentRepository.SaveChangesAsync();

            return new ResponseDTO<ResidentDTO>
            {
                Success = true,
                Message = "Resident deleted successfully.",
            };
        }

        public async Task<ResponseDTO<IEnumerable<ResidentDTO>>> GetAllResidentAsync()
        {
            var response = await _residentRepository.GetAllResidentAsync();

            var resident = response.Select(s => new ResidentDTO
            {
                ResidentId = s.ResidentId,
                FirstName = s.FirstName,
                MiddleName = s.MiddleName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                BirthPlace = s.BirthPlace,
                Age = s.Age,
                Gender = s.Gender,
                Address = s .Address,
                Contact = s.Contact,
                CivilStatus = s.CivilStatus,
                BloodType = s.BloodType,
                Occupation = s.Occupation,
                Religion = s.Religion,
                Nationality = s.Nationality,
                User = new UserDTO
                {
                    UserId = s.UserId,
                    Username = s.User.Username,
                    Role = s.User.Role,
                    RQ = s.User.RQ,
                    RA = s.User.RA
                }
            });

            return new ResponseDTO<IEnumerable<ResidentDTO>>
            {
                Success = true,
                Message = "Resident Lists.",
                Data = resident
            };
        }

        public async Task<ResponseDTO<ResidentDTO>> GetResidentByIdAsync(int id)
        {
            var resident = await _residentRepository.GetResidentByIdAsync(id);
            if(resident == null)
            {
                return new ResponseDTO<ResidentDTO>
                {
                    Success = false,
                    Message = "Resident not found."
                };
            }

            return new ResponseDTO<ResidentDTO>
            {
                Success = true,
                Message = "Resident informations.",
                Data = new ResidentDTO
                {
                    ResidentId = resident.ResidentId,
                    FirstName = resident.FirstName,
                    MiddleName = resident.MiddleName,
                    LastName = resident.LastName,
                    BirthDate = resident.BirthDate,
                    BirthPlace = resident.BirthPlace,
                    Age = resident.Age,
                    Gender = resident.Gender,
                    Address = resident.Address,
                    Contact = resident.Contact,
                    CivilStatus = resident.CivilStatus,
                    BloodType = resident.BloodType,
                    Occupation = resident.Occupation,
                    Religion = resident.Religion,
                    Nationality = resident.Nationality,
                    User = new UserDTO
                    {
                        UserId = resident.UserId,
                        Username = resident.User.Username,
                        Role = resident.User.Role,
                        RQ = resident.User.RQ,
                        RA = resident.User.RA
                    }
                }
            };
        }

        public async Task<ResponseDTO<ResidentDTO>> UpdateResidentAsync(int id, UpdateResidentDTO dto)
        {
            var resident = await _residentRepository.GetResidentByIdAsync(id);
            if (resident == null)
            {
                return new ResponseDTO<ResidentDTO>
                {
                    Success = false,
                    Message = "Resident not found."
                };
            }

            resident.UpdateResident(dto.FirstName, dto.LastName, dto.MiddleName, dto.BirthDate, dto.BirthPlace, dto.Age, dto.Gender, dto.Address, dto.Contact, dto.CivilStatus, dto.BloodType, dto.Occupation, dto.Religion, dto.Nationality);
            await _residentRepository.SaveChangesAsync();

            return new ResponseDTO<ResidentDTO>
            {
                Success = false,
                Message = "Resident updated successfully.",
                Data = new ResidentDTO
                {
                    ResidentId = resident.ResidentId,
                    FirstName = resident.FirstName,
                    MiddleName = resident.MiddleName,
                    LastName = resident.LastName,
                    BirthDate = resident.BirthDate,
                    BirthPlace = resident.BirthPlace,
                    Age = resident.Age,
                    Gender = resident.Gender,
                    Address = resident.Address,
                    Contact = resident.Contact,
                    CivilStatus = resident.CivilStatus,
                    BloodType = resident.BloodType,
                    Occupation = resident.Occupation,
                    Religion = resident.Religion,
                    Nationality = resident.Nationality,
                    User = new UserDTO
                    {
                        UserId = resident.UserId,
                        Username = resident.User.Username,
                        Role = resident.User.Role,
                        RQ = resident.User.RQ,
                        RA = resident.User.RA
                    }
                }
            };
        }
    }
}

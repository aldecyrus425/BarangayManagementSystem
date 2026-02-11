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
    public class DefendantServices : IDefendantServices
    {
        private readonly IDefendantRepository _defendantRepository;
        public DefendantServices(IDefendantRepository defendantRepository)
        {
            _defendantRepository = defendantRepository;
        }

        public async Task<ResponseDTO<DefendantDTO>> AddDefendantAsync(AddDefendantDTO dto)
        {
            try
            {
                var defendant = new Defendant(dto.DefendantFirstName, dto.DefendantLastName, dto.DefendantAge, dto.DefendantAddress, dto.DefendantContact, dto.UserID);
                var response = await _defendantRepository.AddDefendantAsync(defendant);

                return new ResponseDTO<DefendantDTO>
                {
                    Success = true,
                    Message = "Defendant added successfully.",
                    Data = new DefendantDTO
                    {
                        DefendantId = response.DefendantId,
                        DefendantFirstName = response.DefendantFirstName,
                        DefendantLastName = response.DefendantLastName,
                        DefendantAge = response.DefendantAge,
                        DefendantAddress = response.DefendantAddress,
                        DefendantContact = response.DefendantContact,
                        Resident = new GetResidentDTO
                        {
                            FirstName = response.Resident.FirstName,
                            MiddleName = response.Resident.MiddleName,
                            LastName = response.Resident.LastName,
                        }
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<DefendantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };

            }
        }

        public async Task<ResponseDTO<DefendantDTO>> DeleteDefendantAsync(int id)
        {
            try
            {
                var response = await _defendantRepository.DeleteDefendantAsync(id);
                if(!response)
                {
                    return new ResponseDTO<DefendantDTO>
                    {
                        Success = false,
                        Message = "Defendant not found."
                    };
                }    

                await _defendantRepository.SaveChangesAsync();

                return new ResponseDTO<DefendantDTO>
                {
                    Success = true,
                    Message = "Defendant deleted successfully.",
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<DefendantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<DefendantDTO>>> GetAllDefendantAsync()
        {
            try
            {
                var response = await _defendantRepository.GetAllDefendantAsync();

                return new ResponseDTO<IEnumerable<DefendantDTO>>
                {
                    Success = true,
                    Message = "Defendant List's."
                };

                var defendant = response.Select(d => new DefendantDTO
                {
                    DefendantId = d.DefendantId,
                    DefendantFirstName = d.DefendantFirstName,
                    DefendantLastName = d.DefendantLastName,
                    DefendantAge = d.DefendantAge,
                    DefendantAddress = d.DefendantAddress,
                    DefendantContact = d.DefendantContact,
                    Resident = new GetResidentDTO
                    {
                        FirstName = d.Resident.FirstName,
                        MiddleName = d.Resident.MiddleName,
                        LastName = d.Resident.LastName,
                    }
                });

                return new ResponseDTO<IEnumerable<DefendantDTO>>
                {
                    Success = true,
                    Message = "Defendant List's",
                    Data = defendant
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<DefendantDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<DefendantDTO>> GetDefendantByIdAsync(int id)
        {
            try
            {
                var response = await _defendantRepository.GetDefendantByIDAsync(id);
                if(response == null)
                {
                    return new ResponseDTO<DefendantDTO>
                    {
                        Success = false,
                        Message = "Defendant not found"
                    };
                }

                return new ResponseDTO<DefendantDTO>
                {
                    Success = true,
                    Message = "Defendant Information.",
                    Data = new DefendantDTO
                    {
                        DefendantId = response.DefendantId,
                        DefendantFirstName = response.DefendantFirstName,
                        DefendantLastName = response.DefendantLastName,
                        DefendantAge = response.DefendantAge,
                        DefendantAddress = response.DefendantAddress,
                        DefendantContact = response.DefendantContact,
                        Resident = new GetResidentDTO
                        {
                            FirstName = response.Resident.FirstName,
                            MiddleName = response.Resident.MiddleName,
                            LastName = response.Resident.LastName,
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<DefendantDTO>
                {
                    Success = false,
                    Message = ex.Message,

                };
            }
        }

        public async Task<ResponseDTO<DefendantDTO>> UpdateDefendantAsync(updateDefendantDTO dto)
        {
            try
            {
                var defendant = await _defendantRepository.GetDefendantByIDAsync(dto.DefendantId);
                if (defendant == null)
                {
                    return new ResponseDTO<DefendantDTO>
                    {
                        Success = false,
                        Message = "Defendant not found"
                    };
                }

                defendant.UpdateDefendant(dto.DefendantFirstName, dto.DefendantLastName, dto.DefendantAge, dto.DefendantAddress, dto.DefendantContact);
                await _defendantRepository.SaveChangesAsync();

                return new ResponseDTO<DefendantDTO>
                {
                    Success = true,
                    Message = "Defendant Updated Successfully.",
                    Data = new DefendantDTO
                    {
                        DefendantId = defendant.DefendantId,
                        DefendantFirstName = defendant.DefendantFirstName,
                        DefendantLastName = defendant.DefendantLastName,
                        DefendantAge = defendant.DefendantAge,
                        DefendantAddress = defendant.DefendantAddress,
                        DefendantContact = defendant.DefendantContact,
                        Resident = new GetResidentDTO
                        {
                            FirstName = defendant.Resident.FirstName,
                            MiddleName = defendant.Resident.MiddleName,
                            LastName = defendant.Resident.LastName,
                        }
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<DefendantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

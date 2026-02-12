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
    public class ComplainantServices : IComplainantServices
    {
        private readonly IComplainantRepository _complainantRepository;

        public ComplainantServices(IComplainantRepository complainantRepository)
        {
            _complainantRepository = complainantRepository;
        }

        public async Task<ResponseDTO<ComplainantDTO>> AddComplainantAsync(AddComplainantDTO dto)
        {
            try
            {
                var complainant = new Complainant(dto.ComplainantFirstName, dto.ComplainantLastName, dto.ComplainantAge, dto.ComplainantAddress, dto.ComplainantContact, dto.UserId);
                var response = await _complainantRepository.AddComplainantAsync(complainant);

                return new ResponseDTO<ComplainantDTO>
                {
                    Success = true,
                    Message = "Complainant added successfully.",
                    Data = new ComplainantDTO
                    {
                        ComplainantId = response.ComplainantId,
                        ComplainantFirstName = response.ComplainantFirstName,
                        ComplainantLastName = response.ComplainantLastName,
                        ComplainantAge = response.ComplainantAge,
                        ComplainantAddress = response.ComplainantAddress,
                        ComplainantContact = response.ComplainantContact,
                        UserId = dto.UserId,
                    }
                };
                
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ComplainantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<bool>> DeleteComplainantAsync(int id)
        {
            try
            {
                var response = await _complainantRepository.DeleteComplainantAsync(id);
                if (!response)
                {
                    return new ResponseDTO<bool>
                    {
                        Success = false,
                        Message = "Complainant not found."
                    };
                }

                await _complainantRepository.SaveChangesAsync();

                return new ResponseDTO<bool>
                {
                    Success = true,
                    Message = "Complainant deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<bool>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ComplainantDTO>> GetComplainantByIdAsync(int id)
        {
            try
            {
                var response = await _complainantRepository.GetComplainantByIDAsync(id);
                if(response == null)
                {
                    return new ResponseDTO<ComplainantDTO>
                    {
                        Success = false,
                        Message = "Complainant not found"
                    };
                }

                return new ResponseDTO<ComplainantDTO>
                {
                    Success = true,
                    Message = "Complainant Information's.",
                    Data = new ComplainantDTO
                    {
                        ComplainantId = response.ComplainantId,
                        ComplainantFirstName = response.ComplainantFirstName,
                        ComplainantLastName = response.ComplainantLastName,
                        ComplainantAge = response.ComplainantAge,
                        ComplainantAddress = response.ComplainantAddress,
                        ComplainantContact = response.ComplainantContact
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<ComplainantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<ComplainantDTO>>> GetComplainantsAsync()
        {
            try
            {
                var response = await _complainantRepository.GetAllComplainantsAsync();
                var complainant = response.Select(c => new ComplainantDTO
                {
                    ComplainantId = c.ComplainantId,
                    ComplainantFirstName = c.ComplainantFirstName,
                    ComplainantLastName = c.ComplainantLastName,
                    ComplainantAge = c.ComplainantAge,
                    ComplainantAddress = c.ComplainantAddress,
                    ComplainantContact = c.ComplainantContact
                });

                return new ResponseDTO<IEnumerable<ComplainantDTO>>
                {
                    Success = true,
                    Message = "Complainant's List.",
                    Data = complainant
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<ComplainantDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<ComplainantDTO>> UpdateComplainantAsync(UpdateComplainantDTO dto)
        {
            try
            {
                var complainant = await _complainantRepository.GetComplainantByIDAsync(dto.ComplainantID);
                if(complainant == null)
                {
                    return new ResponseDTO<ComplainantDTO>
                    {
                        Success = false,
                        Message = "Complainant not found."
                    };
                }

                complainant.UpdateComplainant(dto.ComplainantFirstName, dto.ComplainantLastName, dto.ComplainantAge, dto.ComplainantAddress, dto.ComplainantContact);
                await _complainantRepository.SaveChangesAsync();

                return new ResponseDTO<ComplainantDTO>
                {
                    Success = true,
                    Message = "Complainant updated successfully.",
                    Data = new ComplainantDTO
                    {
                        ComplainantId = complainant.ComplainantId,
                        ComplainantFirstName = complainant.ComplainantFirstName,
                        ComplainantLastName = complainant.ComplainantLastName,
                        ComplainantAge = complainant.ComplainantAge,
                        ComplainantAddress = complainant.ComplainantAddress,
                        ComplainantContact = complainant.ComplainantContact
                    }
                };

            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<ComplainantDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

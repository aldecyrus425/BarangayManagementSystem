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
    public class OrdinanceServices : IOrdinanceServices
    {
        private readonly IOrdinanceRepository _ordinanceRepository;

        public OrdinanceServices(IOrdinanceRepository ordinanceRepository)
        {
            _ordinanceRepository = ordinanceRepository;
        }

        public async Task<ResponseDTO<OrdinanceDTO>> AddOrdinanceAsync(AddOrdinanceDTO dto)
        {
            try
            {
                var ordinance = new Ordinance(dto.OrdinanceNumber, dto.IntroducedBy, dto.Description, dto.DateEnacted, dto.Approved_By, dto.UserId);
                var response = await _ordinanceRepository.AddOrdinanceAsync(ordinance);
                await _ordinanceRepository.SaveChangesAsync();

                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = true,
                    Message = "Ordinance added successfully.",
                    Data = new OrdinanceDTO
                    {
                        OrdinanceId = response.OrdinanceId,
                        OrdinanceNumber = response.OrdinanceNumber,
                        IntroducedBy = response.IntroducedBy,
                        Description = response.Description,
                        DateEnacted = response.DateEnacted,
                        Approved_By = response.Approved_By,
                        User = response.User,
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<OrdinanceDTO>> DeleteOrdinanceAsync(int id)
        {
            try
            {
                var response = await _ordinanceRepository.DeleteOrdinanceAsync(id);
                if(!response)
                {
                    return new ResponseDTO<OrdinanceDTO>
                    {
                        Success = false,
                        Message = "Ordinance not found."
                    };
                }
                await _ordinanceRepository.SaveChangesAsync();

                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = true,
                    Message = "Ordinance deleted successfully."
                };
            }
            catch(Exception ex)
            {
                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<OrdinanceDTO>> GetOrdinanceByIDAsync(int id)
        {
            try
            {
                var response = await _ordinanceRepository.GetOrdinanceByIdAsync(id);
                if (response == null)
                {
                    return new ResponseDTO<OrdinanceDTO>
                    {
                        Success = false,
                        Message = "Ordinance not found."
                    };
                }

                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = true,
                    Message = "Ordinance information.",
                    Data = new OrdinanceDTO
                    {
                        OrdinanceId = response.OrdinanceId,
                        OrdinanceNumber = response.OrdinanceNumber,
                        IntroducedBy = response.IntroducedBy,
                        Description = response.Description,
                        DateEnacted = response.DateEnacted,
                        Approved_By = response.Approved_By,
                        User = response.User,
                    }
                };
            }
            catch(Exception ex)
            {
                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<OrdinanceDTO>>> GetOrdinanceAsync()
        {
            try
            {
                var response = await _ordinanceRepository.GetAllOrdinanceAsync();

                var ordinance = response.Select(o => new OrdinanceDTO
                {
                    OrdinanceId = o.OrdinanceId,
                    OrdinanceNumber = o.OrdinanceNumber,
                    IntroducedBy = o.IntroducedBy,
                    Description = o.Description,
                    DateEnacted = o.DateEnacted,
                    Approved_By = o.Approved_By,
                    User = o.User,
                });

                return new ResponseDTO<IEnumerable<OrdinanceDTO>>
                {
                    Success = true,
                    Message = "Ordinance List's.",
                    Data = ordinance
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<OrdinanceDTO>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResponseDTO<OrdinanceDTO>> UpdateOrdinanceAsync(int id, UpdateOrdinanceDTO dto)
        {
            try
            {
                var response = await _ordinanceRepository.GetOrdinanceByIdAsync(id);
                if (response == null)
                {
                    return new ResponseDTO<OrdinanceDTO>
                    {
                        Success = false,
                        Message = "Ordinance not found.",

                    };
                }

                response.UpdateOrdinance(dto.OrdinanceNumber, dto.IntroducedBy, dto.Description, dto.DateEnacted, dto.Approved_By, dto.UserId);
                await _ordinanceRepository.SaveChangesAsync();

                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = true,
                    Message = "Ordinance updated successfully.",
                    Data = new OrdinanceDTO
                    {
                        OrdinanceId = response.OrdinanceId,
                        OrdinanceNumber = response.OrdinanceNumber,
                        IntroducedBy = response.IntroducedBy,
                        Description = response.Description,
                        DateEnacted = response.DateEnacted,
                        Approved_By = response.Approved_By,
                        User = response.User,
                    }
                };
            }
            catch(ArgumentException ex)
            {
                return new ResponseDTO<OrdinanceDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}

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

        public Task<ResponseDTO<BlotterDTO>> AddBlotterAsync(AddBlotterDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDTO<BlotterDTO>> DeleteBlotterAsync(int id)
        {
            try
            {
                var blotter = await _blotterRepository.DeleteBlotterAsync(id);
                if(!blotter)
                {
                    return new ResponseDTO<BlotterDTO>
                    {
                        Success = false,
                        Message = "Blotter not found."
                    };
                }

                await _blotterRepository.SaveChangesAsync();

                return new ResponseDTO<BlotterDTO>
                {
                    Success = true,
                    Message = "Blotter deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<BlotterDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<BlotterDTO>>> GetBlotterAsync()
        {
            try
            {
                var blotter = await _blotterRepository.GetAllBlotterAsync();
                var blotterList = blotter.Select(b => new BlotterDTO
                {
                    BlotterId = b.BlotterId,
                    BlotterDate = b.BlotterDate,
                    BlotterComplaint = b.BlotterComplaint,
                    BlotterActionTaken = b.BlotterActionTaken,
                    BlotterStatus = b.BlotterStatus,
                    LocationOfIncidence = b.LocationOfIncidence,
                    SettlementDate = b.SettlementDate,
                });
                return new ResponseDTO<IEnumerable<BlotterDTO>>
                {
                    Success = true,
                    Message = "Blotter list's.",
                    Data = blotterList
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<IEnumerable<BlotterDTO>>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<BlotterDTO>> GetBlotterByIDAsync(int id)
        {
            try
            {
                var blotter = await _blotterRepository.GetBlotterByIdAsync(id);
                if (blotter == null)
                {
                    return new ResponseDTO<BlotterDTO>
                    {
                        Success = false,
                        Message = "Blotter not found.",

                    };
                }

                return new ResponseDTO<BlotterDTO>
                {
                    Success = true,
                    Message = "Blotter information.",
                    Data = new BlotterDTO
                    {
                        BlotterId = blotter.BlotterId,
                        BlotterDate = blotter.BlotterDate,
                        BlotterComplaint = blotter.BlotterComplaint,
                        BlotterActionTaken = blotter.BlotterActionTaken,
                        BlotterStatus = blotter.BlotterStatus,
                        LocationOfIncidence = blotter.LocationOfIncidence,
                        SettlementDate = blotter.SettlementDate,
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<BlotterDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDTO<BlotterDTO>> UpdateBlotterAsync(UpdateBlotterDTO dto)
        {
            try
            {
                var blotter = await _blotterRepository.GetBlotterByIdAsync(dto.BlotterId);
                if (blotter == null) {
                    return new ResponseDTO<BlotterDTO> 
                    {
                        Success = false,
                        Message = "Blotter not found."
                    };
                }

                blotter.UpdateBlotter(dto.BlotterDate, dto.BlotterComplaint, dto.BlotterActionTaken, dto.BlotterStatus, dto.LocationOfIncidence, dto.SettlementDate, dto.ComplainantId);

                await _blotterRepository.SaveChangesAsync();

                return new ResponseDTO<BlotterDTO>
                {
                    Success = true,
                    Message = "Blotter updated successfully.",
                    Data = new BlotterDTO
                    {
                        BlotterId = blotter.BlotterId,
                        BlotterDate = blotter.BlotterDate,
                        BlotterComplaint = blotter.BlotterComplaint,
                        BlotterActionTaken = blotter.BlotterActionTaken,
                        BlotterStatus = blotter.BlotterStatus,
                        LocationOfIncidence = blotter.LocationOfIncidence,
                        SettlementDate = blotter.SettlementDate,
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<BlotterDTO>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
    }
}

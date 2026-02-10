using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class BlotterResidentRepository : IBlotterResidentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BlotterResidentRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlotterResident> AddBlotterResidentAsync(BlotterResident dto)
        {
            await _dbContext.BlottersResident.AddAsync(dto);
            await _dbContext.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteBlotterResidentAsync(int id)
        {
            var blotterResident = await _dbContext.BlottersResident.FirstOrDefaultAsync(b => b.BlotterId == id);

            if (blotterResident == null)
                return false;

            _dbContext.BlottersResident.Remove(blotterResident);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

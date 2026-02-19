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
    public class BlotterRepository : IBlotterRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BlotterRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blotter> AddBlotterAsync(Blotter dto)
        {
            await _dbContext.Blotters.AddAsync(dto);
            await _dbContext.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteBlotterAsync(int id)
        {
            var blotter = await _dbContext.Blotters.FirstOrDefaultAsync(b => b.BlotterId == id);
            if (blotter == null) 
                return false;

            _dbContext.Blotters.Remove(blotter);

            return true;
        }

        public async Task<IEnumerable<Blotter>> GetAllBlotterAsync()
        {
            var blotter = await _dbContext.Blotters
                .AsNoTracking()
                .Include(b =>  b.Complainant)
                .ThenInclude(u => u.User)
                .ToListAsync();

            return blotter;
        }

        public async Task<Blotter?> GetBlotterByIdAsync(int id)
        {
            var blotter = await _dbContext.Blotters.FirstOrDefaultAsync(b => b.BlotterId == id);
            if(blotter == null)
                return null;

            return blotter;

        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

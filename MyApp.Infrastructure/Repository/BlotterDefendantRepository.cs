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
    public class BlotterDefendantRepository : IBlotterDefendantRepository
    {
        private readonly ApplicationDBContext _context;
        public BlotterDefendantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BlotterDefendant> AddBlotterDefendantAsync(BlotterDefendant dto)
        {
            await _context.BlottersDefendant.AddAsync(dto);
            await _context.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteBlotterDefendantAsync(int id)
        {
            var defendant = await _context.BlottersDefendant.FirstOrDefaultAsync(d => d.BlotterDefendantId == id);
            if (defendant == null)
                return false;

            _context.BlottersDefendant.Remove(defendant);

            return true;
        }
    }
}

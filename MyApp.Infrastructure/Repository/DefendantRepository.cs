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
    public class DefendantRepository : IDefendantRepository
    {
        private readonly ApplicationDBContext _context;

        public DefendantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Defendant> AddDefendantAsync(Defendant dto)
        {
            await _context.Defendant.AddAsync(dto);
            await _context.SaveChangesAsync();

            return await _context.Defendant
                .Include(d => d.Resident)
                .FirstAsync(d => d.DefendantId == dto.DefendantId);
        }

        public async Task<bool> DeleteDefendantAsync(int id)
        {
            var defendant = await _context.Defendant.FirstOrDefaultAsync(d => d.DefendantId == id);
            if(defendant == null)
                return false;

            _context.Defendant.Remove(defendant);

            return true;
        }

        public async Task<IEnumerable<Defendant>> GetAllDefendantAsync()
        {
            var defendant = await _context.Defendant
                .Include(d => d.User)
                .AsNoTracking()
                .ToListAsync();

            return defendant;
        }

        public async Task<Defendant?> GetDefendantByIDAsync(int id)
        {
            var defendant = await _context.Defendant.FirstOrDefaultAsync(d => d.DefendantId == id);
            if(defendant == null)
                return null;

            return defendant;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

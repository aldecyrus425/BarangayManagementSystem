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
    public class ResidentRepository : IResidentRepository
    {
        private readonly ApplicationDBContext _context;

        public ResidentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Resident> AddResidentAsync(Resident resident)
        {
            await _context.Residents.AddAsync(resident);

            return resident;
        }

        public async Task<bool> DeleteResidentAsync(int id)
        {
            var resident = await _context.Residents.FirstOrDefaultAsync(r => r.ResidentId == id);

            if(resident == null) 
                return false;

            _context.Residents.Remove(resident);

            return true;
        }

        public async Task<IEnumerable<Resident>> GetAllResidentAsync()
        {
            var resident = await _context.Residents
                .Include(r => r.User)
                .AsNoTracking()
                .ToListAsync();

            return resident;
        }

        public async Task<Resident?> GetResidentByIdAsync(int id)
        {
            var resident = await _context.Residents
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ResidentId == id);

            if(resident == null)
                return null;

            return resident;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

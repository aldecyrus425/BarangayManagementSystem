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
    public class OrdinanceRepository : IOrdinanceRepository
    {
        private readonly ApplicationDBContext _context;
        public OrdinanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Ordinance> AddOrdinanceAsync(Ordinance ordinance)
        {
            await _context.Ordinances.AddAsync(ordinance);
            return ordinance;
        }

        public async Task<bool> DeleteOrdinanceAsync(int id)
        {
            var ordinance = await _context.Ordinances.FirstOrDefaultAsync(o => o.OrdinanceId == id);
            if(ordinance == null)
                return false;

            _context.Remove(ordinance);

            return true;
        }

        public async Task<IEnumerable<Ordinance>> GetAllOrdinanceAsync()
        {
            return await _context.Ordinances
                .Include(o => o.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Ordinance?> GetOrdinanceByIdAsync(int id)
        {
            var ordinance = await _context.Ordinances.FirstOrDefaultAsync(o => o.OrdinanceId == id);
            if (ordinance == null)
                return null;

            return ordinance;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

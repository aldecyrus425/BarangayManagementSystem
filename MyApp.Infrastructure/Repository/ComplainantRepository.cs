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
    public class ComplainantRepository : IComplainantRepository
    {
        private readonly ApplicationDBContext _context;

        public ComplainantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Complainant> AddComplainantAsync(Complainant complainant)
        {
            await _context.Complainants.AddAsync(complainant);
            await _context.SaveChangesAsync();

            return complainant;
        }

        public async Task<bool> DeleteComplainantAsync(int id)
        {
            var complainant = await _context.Complainants.FirstOrDefaultAsync(c => c.ComplainantId == id);
            if (complainant == null)
                return false;

            _context.Complainants.Remove(complainant);

            return true;
        }

        public async Task<IEnumerable<Complainant>> GetAllComplainantsAsync()
        {
            var complainants = await _context.Complainants
                .AsNoTracking()
                .ToListAsync();

            return complainants;
        }

        public Task<Complainant?> GetComplainantByIDAsync(int id)
        {
            var complainants = _context.Complainants.FirstOrDefaultAsync(c => c.ComplainantId == id);
            if (complainants == null)
                return null;

            return complainants;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

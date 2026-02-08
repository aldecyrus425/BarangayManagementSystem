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

        public Task<Complainant> AddComplainantAsync(Complainant complainant)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteComplainantAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Complainant>> GetAllComplainantsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Complainant?> GetComplainantByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}

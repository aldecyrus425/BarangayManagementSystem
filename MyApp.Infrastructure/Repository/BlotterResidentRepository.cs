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
    public class BlotterResidentRepository : IBlotterDefendantRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public BlotterResidentRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<BlotterDefendant> AddBlotterDefendantAsync(BlotterDefendant dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBlotterDefendantAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

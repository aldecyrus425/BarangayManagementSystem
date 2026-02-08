using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IComplainantRepository
    {
        Task<IEnumerable<Complainant>> GetAllComplainantsAsync();
        Task<Complainant?> GetComplainantByIDAsync(int id);
        Task<Complainant> AddComplainantAsync(Complainant complainant);
        Task<bool> DeleteComplainantAsync(int id);
        Task SaveChangesAsync();
    }
}

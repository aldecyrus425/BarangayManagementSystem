using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IOrdinanceRepository
    {
        Task<IEnumerable<Ordinance>> GetAllOrdinanceAsync();
        Task<Ordinance?> GetOrdinanceByIdAsync(int id);
        Task<Ordinance> AddOrdinanceAsync(Ordinance ordinance);
        Task<bool> DeleteOrdinanceAsync(int id);
        Task SaveChangesAsync();
    }
}

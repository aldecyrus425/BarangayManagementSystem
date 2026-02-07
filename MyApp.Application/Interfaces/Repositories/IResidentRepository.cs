using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Entities;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IResidentRepository
    {
        Task<IEnumerable<Resident>> GetAllResidentAsync();
        Task<Resident?> GetResidentByIdAsync(int id);
        Task<Resident> AddResidentAsync(Resident resident);
        Task<bool> DeleteResidentAsync(int id);
        Task SaveChangesAsync();
    }
}

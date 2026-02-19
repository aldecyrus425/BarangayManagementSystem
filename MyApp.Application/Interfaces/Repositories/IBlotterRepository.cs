using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IBlotterRepository
    {
        Task<IEnumerable<Blotter>> GetAllBlotterAsync();
        Task<Blotter?> GetBlotterByIdAsync(int id);
        Task<Blotter> AddBlotterAsync(Blotter dto);
        Task<bool> DeleteBlotterAsync(int id);
        Task SaveChangesAsync();
    }
}

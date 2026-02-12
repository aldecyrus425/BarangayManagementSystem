using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IDefendantRepository
    {
        Task<IEnumerable<Defendant>> GetAllDefendantAsync();
        Task<Defendant?> GetDefendantByIDAsync(int id);
        Task<Defendant> AddDefendantAsync(Defendant dto);
        Task<bool> DeleteDefendantAsync(int id);
        Task SaveChangesAsync();
    }
}

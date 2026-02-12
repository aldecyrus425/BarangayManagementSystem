using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IBlotterDefendantRepository
    {
        Task<BlotterDefendant> AddBlotterDefendantAsync(BlotterDefendant dto);

        Task<bool> DeleteBlotterDefendantAsync(int id);
    }
}

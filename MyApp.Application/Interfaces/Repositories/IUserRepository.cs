using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User?> GetUserById(int id);

        Task<User> AddUser(User user);

        Task SaveChanges();

        Task<bool> DeleteUser(int id);
    }
}

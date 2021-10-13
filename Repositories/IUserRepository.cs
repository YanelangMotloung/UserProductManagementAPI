using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProductManagementAPI.Models;

namespace UserProductManagementAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> CreateUser(User user);
    }
}

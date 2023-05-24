using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public interface IUserDomain
    {
        Task<User?> Save(User user);
        Task<User?> Update(int id, User user);
        Task<bool> Delete(int id);
        Task<User?> GetUser(int id);
        Task<List<User>> GetUsers();
    }
}

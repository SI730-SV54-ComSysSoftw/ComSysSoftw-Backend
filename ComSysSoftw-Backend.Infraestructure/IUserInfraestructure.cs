using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    public interface IUserInfraestructure
    {
        Task<List<User>> GetAll();
        Task<bool> Create(User user);
        Task<User> GetById(int id);
        Task<bool> Update(int id, User user);
        Task<bool> Delete(int id);
    }
}

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
        Task<bool> Create(User input);
        Task<bool> Update(int id, User user);
        Task<bool> Delete(int id);
        Task<User?> GetUser(int id);
        Task<User?> GetUserLogin(string name, string email);
        //Task<List<User>> GetUsers();
        Task<string> Login(User user);
        Task<int> Signup(User user);
        Task<User> GetByUsername(string username);
    }
}

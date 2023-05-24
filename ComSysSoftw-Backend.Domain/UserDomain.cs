using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComSysSoftw_Backend.Infraestructure;

namespace ComSysSoftw_Backend.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserInfraestructure _userInfraestructure;

        public UserDomain(IUserInfraestructure userInfraestructure)
        {
            _userInfraestructure = userInfraestructure;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _userInfraestructure.GetById(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userInfraestructure.GetAll();
        }

        public async Task<User?> Save(User user)
        {
            return await _userInfraestructure.Create(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userInfraestructure.Delete(id);
        }

        public async Task<User?> Update(int id, User user)
        {
            return await _userInfraestructure.Update(id, user);
        }
    }
}

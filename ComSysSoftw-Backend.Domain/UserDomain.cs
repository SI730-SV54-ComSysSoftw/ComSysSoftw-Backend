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
        private  IUserInfraestructure _userInfraestructure;

        public UserDomain(IUserInfraestructure userInfraestructure)
        {
            _userInfraestructure = userInfraestructure;
        }

        /*public async Task<User?> GetUser(int id)
        {
            return await _userInfraestructure.GetById(id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userInfraestructure.GetAll();
        }*/

        public async Task<bool> Create(User input)
        {
            if (input.name.Length < 3) throw new Exception("less than 3 char");
            if (input.name.Length > 10) throw new Exception("more than 10 char");
            return await _userInfraestructure.Create(input);
        }

        public async Task<bool> Delete(int id)
        {
            return await _userInfraestructure.Delete(id);
        }

        public async Task<bool> Update(int id, User user)
        {
            return await _userInfraestructure.Update(id, user);
        }
    }
}

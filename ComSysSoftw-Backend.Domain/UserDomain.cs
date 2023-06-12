﻿using Infraestructure.Models;
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
        private IEncryptDomain _encryptDomain;
        private ITokenDomain _tokenDomain;

        public UserDomain(IUserInfraestructure userInfraestructure, IEncryptDomain encryptDomain, ITokenDomain tokenDomain)
        {
            _userInfraestructure = userInfraestructure;
            _encryptDomain = encryptDomain;
            _tokenDomain = tokenDomain;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _userInfraestructure.GetById(id);
        }
        public async Task<User?> GetUserLogin(string name, string email)
        {
            var user = await _userInfraestructure.GetUserLogin(name, email);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        /*
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

        public async Task<string> Login(User user)
        {
            var foundUser = await _userInfraestructure.GetByUsername(user.UserName);

            if (_encryptDomain.Ecnrypt(user.Password) == foundUser.Password)
            {
                return _tokenDomain.GenerateJwt(foundUser.UserName);
            }

            throw new ArgumentException("Invalid username or password");
        }

        public async Task<int> Signup(User user)
        {
            user.Password = _encryptDomain.Ecnrypt(user.Password);
            return await _userInfraestructure.Signup(user);
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _userInfraestructure.GetByUsername(username);
        }
    }
}

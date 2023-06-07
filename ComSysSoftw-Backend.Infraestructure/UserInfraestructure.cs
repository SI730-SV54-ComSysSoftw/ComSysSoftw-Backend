using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace ComSysSoftw_Backend.Infraestructure;

public class UserInfraestructure : IUserInfraestructure
{
    private readonly VetDbContext _VetDBContext;
    public UserInfraestructure(VetDbContext context)
    {
        _VetDBContext = context;
    }

    public async Task<List<User>> GetAll()
    {
        return await _VetDBContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserLogin(string name, string email)
    {
         var user = await _VetDBContext.Users.FirstOrDefaultAsync(u => u.name == name && u.email == email);
        if (user == null) return null;
        return user;
    }

    public async Task<User> GetById(int id)
    {
        return await _VetDBContext.Users.FirstOrDefaultAsync(user=>user.Id==id);
    }

    public async Task<bool> Create(User user)
    {
        try
        {
            user.IsActive = true;
            _VetDBContext.Users.Add(user);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { return false; }
    }

    public async Task<bool> Delete(int id)
    {
            var userFound = _VetDBContext.Users.Find(id);
            userFound.IsActive = false;
        
            _VetDBContext.Users.Update(userFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        
    }

    public async Task<bool> Update(int id, User input)
    {
        try
        {
            var userFound =  _VetDBContext.Users.Find(id);
        
            userFound.name = input.name;
            userFound.email = input.email;
            userFound.age = input.age;
            _VetDBContext.Users.Update(userFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }
        catch (Exception exception) { return false; }
    }
}

using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;


namespace ComSysSoftw_Backend.Infraestructure
{
    public class UserInfraestructure : IUserInfraestructure
    {
        private readonly VetDbContext _context;
        public UserInfraestructure(VetDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userFound;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userFound != null)
            {
                _context.Users.Remove(userFound);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<User?> Update(int id, User user)
        {
            var userFound = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userFound == null)
                return null;
            userFound.name = user.name;
            userFound.Description = user.Description;
            userFound.Pets = user.Pets;
            await _context.SaveChangesAsync();
            return userFound;
        }
    }
}

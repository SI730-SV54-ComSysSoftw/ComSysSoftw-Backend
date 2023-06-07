using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    public class PetInfraestructure : IPetInfraestructure
    {
        private readonly VetDbContext _VetDBContext;
        public PetInfraestructure(VetDbContext context)
        {
            _VetDBContext = context;
        }
        public async Task<bool> Create(Pet pet)
        {
            try
            {
                _VetDBContext.Pets.Add(pet);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            var petFound = _VetDBContext.Pets.Find(id);

            _VetDBContext.Pets.Update(petFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pet>> GetAllByUser(int userId)
        {
            return await _VetDBContext.Pets.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Pet> GetById(int id)
        {
            return await _VetDBContext.Pets.FirstOrDefaultAsync(vet => vet.Id == id);
        }

        public async Task<bool> Update(int id, Pet pet)
        {
            try
            {
                var petFound = _VetDBContext.Pets.Find(id);

                petFound.name = pet.name; 
                petFound.age = pet.age;
                petFound.description = pet.description;
                _VetDBContext.Pets.Update(petFound);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }
    }
}

using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public class PetDomain : IPetDomain
    {
        private readonly IPetInfraestructure _petInfraestructure;

        public PetDomain(IPetInfraestructure petInfraestructure)
        {
            _petInfraestructure = petInfraestructure;
        }
        public async Task<bool> Create(Pet input)
        {
            return await _petInfraestructure.Create(input);
        }

        public async Task<bool> Delete(int id)
        {
            return await _petInfraestructure.Delete(id);
        }

        public async Task<Pet?> GetPet(int id)
        {
            return await _petInfraestructure.GetById(id);
        }

        public async Task<List<Pet>?> GetPetByUser(int userId)
        {
            return await _petInfraestructure.GetAllByUser(userId);
        }

        public async Task<bool> Update(int id, Pet pet)
        {
            return await _petInfraestructure.Update(id, pet);
        }
    }
}

using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public interface IPetDomain
    {
        Task<bool> Create(Pet input);
        Task<bool> Update(int id, Pet pet);
        Task<bool> Delete(int id);
        Task<Pet?> GetPet(int id);
        Task<List<Pet>?> GetPetByUser(int userId);
    }
}

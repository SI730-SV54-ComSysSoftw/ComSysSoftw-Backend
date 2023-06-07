using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    public interface IPetInfraestructure
    {
        Task<List<Pet>> GetAllByUser(int userId);
        Task<bool> Create(Pet pet);
        Task<Pet> GetById(int id);
        Task<bool> Update(int id, Pet pet);
        Task<bool> Delete(int id);
    }
}

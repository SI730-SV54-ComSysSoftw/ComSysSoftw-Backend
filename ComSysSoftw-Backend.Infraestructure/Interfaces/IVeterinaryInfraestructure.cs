using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Interfaces
{
    public interface IVeterinaryInfraestructure
    {
        Task<List<Veterinary>> GetAll();
        Task<bool> Create(Veterinary user);
        Task<Veterinary?> GetById(int id);
        Task<bool> Update(int id, Veterinary user);
        Task<bool> Delete(int id);
    }
}

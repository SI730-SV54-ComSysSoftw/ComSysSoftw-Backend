using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public interface IVeterinaryDomain
    {
        Task<bool> Create(Veterinary input);
        Task<bool> Update(int id, Veterinary veterinary);
        Task<bool> Delete(int id);
        Task<Veterinary?> GetVeterinary(int id);
    }
}

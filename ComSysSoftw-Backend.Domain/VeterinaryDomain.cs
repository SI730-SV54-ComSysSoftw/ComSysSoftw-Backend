using ComSysSoftw_Backend.Infraestructure;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public class VeterinaryDomain : IVeterinaryDomain
    {
        private readonly IVeterinaryInfraestructure _vetInfraestructure;

        public VeterinaryDomain(IVeterinaryInfraestructure vetInfraestructure)
        {
            _vetInfraestructure = vetInfraestructure;
        }
        public async Task<bool> Create(Veterinary input)
        {
            return await _vetInfraestructure.Create(input);
        }

        public async Task<bool> Delete(int id)
        {
            return await _vetInfraestructure.Delete(id);
        }

        public async Task<Veterinary?> GetVeterinary(int id)
        {
            return await _vetInfraestructure.GetById(id);
        }

        public async Task<bool> Update(int id, Veterinary veterinary)
        {
            return await _vetInfraestructure.Update(id, veterinary);
        }
    }
}

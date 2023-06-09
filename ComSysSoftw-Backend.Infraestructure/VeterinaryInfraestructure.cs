﻿using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    public class VeterinaryInfraestructure : IVeterinaryInfraestructure
    {
        private readonly VetDbContext _VetDBContext;
        public VeterinaryInfraestructure(VetDbContext context)
        {
            _VetDBContext = context;
        }

        public async Task<bool> Create(Veterinary veterinary)
        {
            try
            {
                _VetDBContext.Veterinaries.Add(veterinary);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            var vetyFound = _VetDBContext.Veterinaries.Find(id);

            _VetDBContext.Veterinaries.Update(vetyFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Veterinary>> GetAll()
        {
            return await _VetDBContext.Veterinaries.ToListAsync();
        }

        public async Task<Veterinary> GetById(int id)
        {
            return await _VetDBContext.Veterinaries.FirstOrDefaultAsync(vet => vet.Id == id);
        }

        public async Task<bool> Update(int id, Veterinary vety)
        {
            try
            {
                var vetyFound = _VetDBContext.Veterinaries.Find(id);

                vetyFound.name = vety.name;
                vetyFound.phone_number = vety.phone_number;
                vetyFound.district = vety.district;
                _VetDBContext.Veterinaries.Update(vetyFound);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }
    }
}

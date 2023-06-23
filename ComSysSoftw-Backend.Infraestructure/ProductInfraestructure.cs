using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    internal class ProductInfraestructure : IProductInfraestructure
    {
        private readonly VetDbContext _VetDBContext;
        public ProductInfraestructure(VetDbContext context)
        {
            _VetDBContext = context;
        }
        public  async Task<bool> Create(Product product)
        {
            try
            {
                product.IsActive = true;
                product.DateToProduct = DateTime.Now;
                _VetDBContext.Products.Add(product);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            var productFound = _VetDBContext.Products.Find(id);
            productFound.IsActive = false;
            _VetDBContext.Products.Update(productFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllByVet(int vetId)
        {
            return await _VetDBContext.Products.Where(p => p.VeterinaryId == vetId).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _VetDBContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(int id, Product product)
        {
            try
            {
                product.DateUpdated = DateTime.Now;
                var productFound = _VetDBContext.Products.Find(id);

                productFound.name = product.name;
                productFound.description = product.description;
                productFound.amount = product.amount;

                _VetDBContext.Products.Update(productFound);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }
    }
}

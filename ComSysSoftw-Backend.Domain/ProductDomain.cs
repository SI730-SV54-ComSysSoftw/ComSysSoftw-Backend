using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public class ProductDomain : IProductDomain
    {
        private readonly IProductInfraestructure _productInfraestructure;
        public ProductDomain(IProductInfraestructure productInfraestructure)
        {
            _productInfraestructure = productInfraestructure;
        }
        public async Task<bool> Create(Product input)
        {
            return await _productInfraestructure.Create(input);
        }

        public async Task<bool> Delete(int id)
        {
            return await _productInfraestructure.Delete(id);
        }

        public async Task<List<Product>> GetAllByVet(int vetId)
        {
            return await _productInfraestructure.GetAllByVet(vetId);
        }

        public async Task<Product> GetById(int id)
        {
            return await _productInfraestructure.GetById(id);
        }

        public async Task<bool> Update(int id, Product input)
        {
            return await _productInfraestructure.Update(id, input);
        }
    }
}

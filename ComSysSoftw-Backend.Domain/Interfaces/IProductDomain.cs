using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain.Interfaces
{
    public interface IProductDomain
    {
        Task<List<Product>> GetAllByVet(int vetId);
        Task<bool> Create(Product input);
        Task<Product> GetById(int id);
        Task<bool> Update(int id, Product input);
        Task<bool> Delete(int id);
    }
}

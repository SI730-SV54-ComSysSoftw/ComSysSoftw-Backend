using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Interfaces
{
    public interface IProductInfraestructure
    {
        Task<List<Product>> GetAllByVet(int vetId);
        Task<bool> Create(Product product);
        Task<Product> GetById(int id);
        Task<bool> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}

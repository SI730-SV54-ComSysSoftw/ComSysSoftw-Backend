using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain.Interfaces
{
    public interface ICommentDomain
    {
        Task<List<Comment>?> GetAllByUser(int userId);
        Task<List<Comment>?> GetAllByVet(int vetId);
        Task<bool> Create(Comment input);
        Task<Comment> GetById(int id);
        Task<bool> Update(int id, Comment comment);
        Task<bool> Delete(int id);
    }
}

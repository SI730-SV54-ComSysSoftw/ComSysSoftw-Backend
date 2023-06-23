using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public class CommentDomain : ICommentDomain
    {
        private readonly ICommentInfraestructure _commentInfraestructure;
        public CommentDomain(ICommentInfraestructure commentInfraestructure)
        {
            _commentInfraestructure = commentInfraestructure;
        }
        public async Task<bool> Create(Comment input)
        {
            return await _commentInfraestructure.Create(input);
        }

        public async Task<bool> Delete(int id)
        {
            return await _commentInfraestructure.Delete(id);
        }

        public async Task<List<Comment>?> GetAllByUser(int userId)
        {
            return await _commentInfraestructure.GetAllByUser(userId);
        }

        public async Task<List<Comment>?> GetAllByVet(int vetId)
        {
            return await _commentInfraestructure.GetAllByVet(vetId);
        }

        public async Task<Comment> GetById(int id)
        {
            return await _commentInfraestructure.GetById(id);
        }

        public async Task<bool> Update(int id, Comment comment)
        {
            return await _commentInfraestructure.Update(id, comment);
        }
    }
}

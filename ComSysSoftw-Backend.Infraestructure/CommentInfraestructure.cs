using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Context;
using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComSysSoftw_Backend.Infraestructure
{
    public class CommentInfraestructure : ICommentInfraestructure
    {
        private readonly VetDbContext _VetDBContext;
        public CommentInfraestructure(VetDbContext context)
        {
            _VetDBContext = context;
        }
        public async Task<bool> Create(Comment comment)
        {
            try
            {
                comment.IsActive = true;
                comment.DateToComment = DateTime.Now;
                _VetDBContext.Comments.Add(comment);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }

        public async Task<bool> Delete(int id)
        {
            var commentFound = _VetDBContext.Comments.Find(id);
            commentFound.IsActive = false;
            _VetDBContext.Comments.Update(commentFound);
            await _VetDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllByUser(int userId)
        {
            return await _VetDBContext.Comments.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<List<Comment>> GetAllByVet(int vetId)
        {
            return await _VetDBContext.Comments.Where(p => p.VeterinaryId == vetId).ToListAsync();
        }

        public async  Task<Comment> GetById(int id)
        {
            return await _VetDBContext.Comments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Update(int id, Comment comment)
        {
            try
            {
                comment.DateUpdated = DateTime.Now;
                var commentFound = _VetDBContext.Comments.Find(id);

                commentFound.title = comment.title;
                commentFound.text = comment.text;
               
                _VetDBContext.Comments.Update(commentFound);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }
    }
}

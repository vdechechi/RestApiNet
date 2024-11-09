using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.DTOs.Stock;
using RESTAPI.Interfaces;
using RESTAPI.Models;

namespace RESTAPI.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<Comment> CreateAsync(Stock stockModel)
        {
            throw new NotImplementedException();
        }

        public Task<Comment?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync() ;

        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public Task<Comment?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            throw new NotImplementedException();
        }
    }
}

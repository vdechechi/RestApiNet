using RESTAPI.DTOs.Comment;
using RESTAPI.DTOs.Stock;
using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(int id); //First or default podem ser null

        Task<Comment> CreateAsync(Comment commentModel);

        Task<Comment?> UpdateAsync(int id, Comment commentModel);

        Task<Comment?> DeleteAsync(int id);
    }
}

using RESTAPI.DTOs.Stock;
using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();

        Task<Comment?> GetByIdAsync(int id); //First or default podem ser null

        Task<Comment> CreateAsync(Stock stockModel);

        Task<Comment?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Comment?> DeleteAsync(int id);
    }
}

using RESTAPI.DTOs.Stock;
using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();

        Task<Stock?> GetByIdAsync(int id); //First or default podem ser null

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Stock?> DeleteAsync(int id);
    }
}

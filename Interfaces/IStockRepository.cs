using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
    }
}

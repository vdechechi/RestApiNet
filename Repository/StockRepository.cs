using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.Interfaces;
using RESTAPI.Models;

namespace RESTAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _context.Stocks.ToListAsync();
        }
    }
}

using RESTAPI.Data;
using RESTAPI.Interfaces;
using RESTAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Portifolio> CreateAsync(Portifolio portifolio)
        {
            await _context.Portifolios.AddAsync(portifolio);

            await _context.SaveChangesAsync();

            return portifolio;
        }

        public async Task<Portifolio> DeletePortfolio(AppUser user, string symbol)
        {
            var portfolioModel = await _context.Portifolios.FirstOrDefaultAsync(x => x.AppUserId == user.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portfolioModel == null) return null;

            _context.Portifolios.Remove(portfolioModel);

            await _context.SaveChangesAsync();

            return portfolioModel;
        }

        public async Task<List<Stock>> GetUserPortfolio(AppUser user)
        {
            return await _context.Portifolios
                .Where(u => u.AppUserId == user.Id)
                .Select(stock => new Stock
                {
                    Id = stock.StockId,
                    Symbol = stock.Stock.Symbol,
                    CompanyName = stock.Stock.CompanyName,
                    Purchase = stock.Stock.Purchase,
                    LastDiv = stock.Stock.LastDiv,
                    Industry = stock.Stock.Industry,
                    MarketCap = stock.Stock.MarketCap,
                })
                .ToListAsync();
        }
    }
}

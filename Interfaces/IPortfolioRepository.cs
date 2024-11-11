using RESTAPI.Models;

namespace RESTAPI.Interfaces
{
    public interface IPortfolioRepository
    {

        Task<List<Stock>> GetUserPortfolio(AppUser user);
        Task<Portifolio> CreateAsync(Portifolio portifolio);

        Task<Portifolio> DeletePortfolio(AppUser user, string symbol);
    }
}

using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }


    public DbSet<Comment> Comments { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }


    public DbSet<Comment> Comments { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    }
}

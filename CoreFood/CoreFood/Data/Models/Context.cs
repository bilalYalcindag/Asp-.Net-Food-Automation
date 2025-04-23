using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CoreFood.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NPQR203;Database=DbCoreFood;Trusted_Connection=True;TrustServerCertificate=True;");


        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; } 

    }
}

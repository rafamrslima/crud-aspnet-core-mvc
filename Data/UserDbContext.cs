using crud_aspnetcore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_aspnetcore_mvc.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserDb;Trusted_Connection=true;");
        }
    }
}
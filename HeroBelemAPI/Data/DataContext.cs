using HeroBelemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroBelemAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<HeroBelem> HeroesBelem { get; set; }
    }
}

using HeroBelemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroBelemAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<HeroBelem> HeroesBelem { get; set; }
    }
}

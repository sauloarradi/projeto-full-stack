using Microsoft.EntityFrameworkCore;
using WebAPI_Super.Models;

namespace WebAPI_Super.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<HeroiModel> Herois { get; set; }
        public DbSet<HeroisSuperPoderesModel> HeroisSuperPoderes { get; set; }
        public DbSet<SuperPoderesModel> SuperPoderes { get; set; }
    }
}

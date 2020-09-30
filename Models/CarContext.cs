using Microsoft.EntityFrameworkCore;

namespace CarAPI.Models
{
    public class CarContext : DbContext
    {
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<CarSpecification> CarSpecifications { get; set; }

        public CarContext(DbContextOptions<CarContext> options) :base((options))
        {
            
        }
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlServer(@"Server=DESKTOP-IT0TBQA;Database=Car;Trusted_Connection=True;");
    }
}
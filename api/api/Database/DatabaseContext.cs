using api.Database.Entities.Dispatcher;
using api.Database.Entities.Product;
using api.Database.Entities.RegisterMachine;
using api.Database.Entities.Sell;
using Microsoft.EntityFrameworkCore;

namespace api.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<DispatcherEntity> Dispatcher { get; set; }
        public DbSet<RegisterMachineEntity> RegisterMachine { get; set; }
        public DbSet<SellEntity> Sell { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SellEntity>()
                .HasKey(m => new { m.Product, m.Dispatcher, m.Machine });
        }
    }
}

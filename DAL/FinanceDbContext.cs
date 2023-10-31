using DAL.Seeds;
using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace DAL
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UsersSeed.Seed(modelBuilder);
            StoreSeed.Seed(modelBuilder);
            UnitSeed.Seed(modelBuilder);
            ProductSeed.Seed(modelBuilder);
            ProductUnitSeed.Seed(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }

    }
}

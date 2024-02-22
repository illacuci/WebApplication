using Microsoft.EntityFrameworkCore;
using Models.Entities.Centers;
using Models.Entities.Location;
using Models.Entities.Movements;
using Models.Entities.Products;
using Models.Entities.Stocks;
using Models.Entities.Vendor;
using System.Reflection.Metadata;

namespace OrdersAPI.Insfractucture.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brands> Brand { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Packaging> Packaging { get; set; }
        public DbSet<Generics> Generics { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Towns> Towns { get; set; }
        public DbSet<CentersCosts> CentersCosts { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Segments> Segments { get; set; }
        public DbSet<Sites> Sites { get; set; }
        public DbSet<Stock> Stocs { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetails> PurchaseOrdersDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura la clave primaria compuesta para Packaging
            modelBuilder.Entity<Packaging>()
                .HasKey(p => new { p.PresentacionId, p.IdItem });

            // Configura la clave primaria compuesta para Stock
            modelBuilder.Entity<Stock>()
                .HasKey(s => new { s.LogisticCenter, s.IdProduct });

            modelBuilder
                .Entity<Suppliers>()
                .HasOne(s => s.Town)
                .WithMany(t => t.Suppliers)
                .HasForeignKey(s => s.IdTown)
                .OnDelete(DeleteBehavior.NoAction);

        }

    }
}

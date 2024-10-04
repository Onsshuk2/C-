using Microsoft.EntityFrameworkCore;
using ShopLibrary.Entities;
using ShopLibrary.Helpers;

namespace ShopLibrary
{
    public class DbContextShop : DbContext
    {
        public DbSet<Categori> Categori { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Worker { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LCTPOKA\\SQLEXPRESS;Initial Catalog=BeatyShop;Integrated Security=True;TrustServerCertificate=True");
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne<Categori>(p=>p.Categori)
                .WithMany(c=>c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Worker>()
                .HasOne<Position>(w=>w.Position)
                .WithMany(p=>p.Workers)
                .HasForeignKey(w => w.PositionId);

            modelBuilder.Entity<Worker>()
                .HasOne<Shop>(w=>w.Shop)
                .WithMany(s=>s.Workers)
                .HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<City>()
                .HasOne<Country>(c=>c.Country)
                .WithMany(c=>c.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<City>()
                .HasMany<Shop>(c => c.Shops)
                .WithOne(c => c.City)
                .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<Shop>()
                .HasMany<Product>(s => s.Products)
                .WithMany(s => s.Shops);
            

            modelBuilder.SeedCategori();
            modelBuilder.SeedCountry();
            modelBuilder.SeedPosition();
            modelBuilder.SeedCity();
           
            modelBuilder.SeedProduct();
            modelBuilder.SeedShop();
            
            modelBuilder.SeedWorkert();
        }
    }
}

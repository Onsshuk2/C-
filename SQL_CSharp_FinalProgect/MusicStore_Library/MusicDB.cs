using Microsoft.EntityFrameworkCore;
using MusicStore_Library.Entities;
using MusicStore_Library.Helpers;
using static MusicStore_Library.Entities.Customer;


namespace MusicStore_Library
{
    public class MusicDB : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-LCTPOKA\\SQLEXPRESS;Initial Catalog=MusicStore;Integrated Security=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Record>()
       .Property(r => r.NameRecord)
       .IsRequired()
       .HasMaxLength(100);

            modelBuilder.Entity<Record>()
                .HasOne(r => r.Genre)
                .WithMany(g => g.Records)
                .HasForeignKey(r => r.GenreId);

            modelBuilder.Entity<Record>()
                .HasOne(r => r.Artist) 
                .WithMany(a => a.Record)
                .HasForeignKey(r => r.ArtistId);

            modelBuilder.Entity<Artist>()
                .Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Artist>()
                .Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Artist>()
                .HasOne(a => a.Country) 
                .WithMany(c => c.Artists)
                .HasForeignKey(a => a.CountryId);

            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Track>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Track>()
                .Property(t => t.Duration)
                .IsRequired();

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Record) 
                .WithMany(r => r.Tracks)
                .HasForeignKey(t => t.RecordId);

            modelBuilder.SeedRecords();
            modelBuilder.SeedArtists();
            modelBuilder.SeedCountry();
            modelBuilder.SeedGenre();
            modelBuilder.SeedTrack();
            modelBuilder.SeedCastomer();
            modelBuilder.SeedReservation();
        }


    }
}

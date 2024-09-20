using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sql_5
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MusicDb;Integrated Security=True");
        }

        public static void Initialize(MusicDbContext context)
        {
            if (context.Artists.Any() && context.Albums.Any() && context.Tracks.Any() && context.Playlists.Any())
            {
                return;
            }

            // Додавання артистів
            var artist1 = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
            var artist2 = new Artist { FirstName = "Jane", LastName = "Smith", Country = "UK" };
            context.Artists.AddRange(artist1, artist2);
            context.SaveChanges();

            // Додавання альбомів
            var album1 = new Album { Name = "Greatest Hits", Year = 2020, Genre = "Pop", ArtistId = artist1.Id };
            var album2 = new Album { Name = "The Best of Jane", Year = 2021, Genre = "Rock", ArtistId = artist2.Id };
            context.Albums.AddRange(album1, album2);
            context.SaveChanges();

            // Додавання треків
            var track1 = new Track { Name = "Hit Song 1", Duration = TimeSpan.FromMinutes(3.5), AlbumId = album1.Id };
            var track2 = new Track { Name = "Hit Song 2", Duration = TimeSpan.FromMinutes(4.0), AlbumId = album1.Id };
            var track3 = new Track { Name = "Rock Anthem", Duration = TimeSpan.FromMinutes(5.0), AlbumId = album2.Id };
            context.Tracks.AddRange(track1, track2, track3);
            context.SaveChanges();

            // Додавання плейлистів
            CreatePlaylist(context, "My Favorite Songs", "Mixed", new List<int> { track1.Id, track2.Id });
            CreatePlaylist(context, "Rock Classics", "Rock", new List<int> { track3.Id });
        }

        public static void CreatePlaylist(MusicDbContext context, string name, string category, List<int> trackIds)
        {
            var tracks = context.Tracks.Where(t => trackIds.Contains(t.Id)).ToList();
            var playlist = new Playlist { Name = name, Category = category, Tracks = tracks };
            context.Playlists.Add(playlist);
            context.SaveChanges();
        }
    }

    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }

    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
    }

    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int AlbumId { get; set; }
    }

    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MusicDbContext())
            {
                context.Database.EnsureCreated();
                MusicDbContext.Initialize(context);
            }
        }
    }
}

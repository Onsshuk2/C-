using Microsoft.EntityFrameworkCore;
using MusicStore_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MusicStore_Library.Entities.Customer;

namespace MusicStore_Library.Helpers
{
    public static class DbInitializer
    {
        public static void SeedRecords(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().HasData(
              new Record[]
              {     
                    new Record {
                        Id = 1,
                        NameRecord = "Greatest Hits", 
                        Year = 2020, 
                        Price=1000,
                        Discount=10,
                        GenreId = 4, 
                        ArtistId = 1 },

              });
            modelBuilder.Entity<Record>().HasData(
              new Record[]
              {
                    new Record {
                        Id = 2,
                        NameRecord = "The Best of Jane",
                        Year = 2021,
                        Price=2000,
                        Discount=15,
                        GenreId = 2,
                        ArtistId = 2},

              });
            modelBuilder.Entity<Record>().HasData(
              new Record[]
              {
                    new Record {
                        Id = 3,
                        NameRecord = "Top 3 of Ukraine", 
                        Year = 2021,
                        Price=1500,
                        Discount=13,
                        GenreId = 1,
                        ArtistId = 3 },

              });
            modelBuilder.Entity<Record>().HasData(
              new Record[]
              {
                    new Record {
                        Id = 4,
                        NameRecord = "Best of the word",
                        Year = 2021,
                        Price=2300,
                        Discount=18,
                        GenreId = 3, 
                        ArtistId = 4 },

              });
        }
        public static void SeedArtists(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
               new Artist[]
                  {
                    new Artist()
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Doe",
                        CountryId = 1
                    },

                    new Artist()
                    {   
                        Id = 2,
                        FirstName = "Jane",
                        LastName = "Smith",
                        CountryId = 2
                    },
                    new Artist()
                    { 
                        Id = 3,
                        FirstName = "Ann",
                        LastName = "Trincher",
                        CountryId = 3
                    },
                       new Artist()
                    {
                        Id = 4,
                        FirstName = "Tina",
                        LastName = "Karol",
                        CountryId = 4
                    },
                    });
        }
       
        public static void SeedCastomer(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
               new Customer[]
                  {
                    new Customer()
                    {
                        Id =1,
                        Username ="Ira083",
                        Password="1111",
                        FirstName ="Ira",
                        LastName="Onishchuk",
                        TotalSpent=23
                     },
                    new Customer()
                    {
                        Id =2,
                        Username ="Ann013",
                        Password="****",
                        FirstName ="Ann",
                        LastName="Polishchuk",
                        TotalSpent=20
                     },
                    new Customer()
                    {
                        Id =3,
                        Username ="Olga083",
                        Password="1123",
                        FirstName ="Olga",
                        LastName="Franchuk",
                        TotalSpent=10
                     },
                    new Customer()
                    {
                        Id =4,
                        Username ="Kate083",
                        Password="1211",
                        FirstName ="Katerina",
                        LastName="Shevchuk",
                        TotalSpent=15
                     }


                    });
        }
            public static void SeedCountry(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Country>().HasData(
                   new Country[]
                      {
                    new Country()
                    {   Id = 1,
                        Name = "USA"
                    },
                          new Country()
                    { 
                        Id= 2,
                        Name = "Ukraine"
                    }, 
                          new Country()
                    {
                        Id= 3,
                        Name = "Italy"
                    },
                          new Country()
                    {
                        Id= 4,
                        Name = "France"
                    }


                        });
            }
        public static void SeedGenre(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
               new Genre[]
                  {
                    new Genre()
                    {   Id= 1,
                        Name = "POP"
                    },
                          new Genre()
                    {   Id =2,
                        Name = "Rok"
                    },
                          new Genre()
                    {
                        Id=3,
                        Name = "Classic"
                    },
                          new Genre()
                    { 
                        Id=4,
                        Name = "Modern"
                    }


                    });
        }
        //створилась таблиця, але не записались дані
        public static void SeedReservation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
               new Reservation[]
                  {
                    new Reservation()
                    {   Id = 1,
                        RecordId =1,
                        CustomerId=2
                    },
                    new Reservation()
                    {   Id = 2,
                        RecordId =3,
                        CustomerId=3
                    },
                    new Reservation()
                    {   Id = 3,
                        RecordId =2,
                        CustomerId=4
                    },
                    new Reservation()
                    {   Id = 4,
                        RecordId =4,
                        CustomerId=1
                    }



                    });
        }
        public static void SeedTrack(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>().HasData(
               new Track[]
                  {
                    new Track()
                    {   Id= 1,
                        Name = "Unwritten",
                        Duration = TimeSpan.FromMinutes(3.5),              RecordId = 1
                    },
                          new Track()
                    {   Id =2,
                        Name = "Beatiful Things",
                        Duration = TimeSpan.FromMinutes(4.0),              RecordId =2
                    },
                          new Track()
                    {
                        Id=3,
                        Name = "Enemy",
                        Duration = TimeSpan.FromMinutes(5.0),              RecordId=3
                    },
                          new Track()
                    {
                        Id=4,
                        Name = "Everybody Knows",
                        Duration = TimeSpan.FromMinutes(5.0),              RecordId =4
                    }


                    });
        }


    }
}


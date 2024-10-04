using Microsoft.EntityFrameworkCore;
using ShopLibrary.Entities;


namespace ShopLibrary.Helpers
{
    public static class DbInitializerShop
    {
        public static void SeedShop(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData
                (
              new Shop[]
              {
                    new Shop { Id = 1, Name= "BeatyWord", Addres="Soborna 3a", ParkingArea =35, CityId=1
               },
                     new Shop { Id = 2, Name= "BROW", Addres="Shewchenka 14d", ParkingArea =30,CityId=2
               },
                     new Shop { Id = 3, Name= "Nail", Addres="Soborna 44b", ParkingArea =25, CityId=3 }
              });

        }

        public static void SeedCategori(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categori>().HasData(
               new Categori[]
               {
               new Categori()
               {
                   Id = 1,
                   Name = "Girl",
               },
               new Categori()
               {
                   Id = 2,
                   Name = "Boy",
               },
               new Categori()
               {
                   Id = 3,
                   Name = "Children",
               }
               });
        }
        public static void SeedCity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
               new City[]
               {
               new City()
               {
                   Id = 1,
                   Name = "Rivne",
                   CountryId=1
               },
               new City()
               {
                   Id = 2,
                   Name = "Lviv",
                   CountryId=2
               },
               new City()
               {
                   Id = 3,
                   Name = "Kyiv",
                   CountryId=3
               }
        });
    }
            public static void SeedCountry(this ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Country>().HasData(
                   new Country[]
                   {
                       new Country()
                       {
                           Id = 1,
                           Name = "Ukraine",
                       },
                       new Country()
                       {
                           Id = 2,
                           Name = "USA",
                       },
                       new Country()
                       {
                           Id = 3,
                           Name = "Italy",
                       }
                   });
            }
        public static void SeedPosition(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
               new Position[]
               {
                   new Position()
                   {
                       Id = 1,
                       Name = "Top Manegir",
                   },
                   new Position()
                   {
                       Id = 2,
                       Name = "Seller",
                   }
               });
        }
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
               new Product[]
               {
                   new Product()
                   {
                       Id = 1,
                       Name = "Brush",
                       Price = 80,
                       Discount = 8,
                       CategoryId = 1,
                       Quantity = 20,
                       IslnStock = true
                   },
                   new Product()
                   {
                       Id = 2,
                       Name = "Trimmer",
                       Price = 800,
                       Discount = 12,
                       
                       CategoryId = 2,
                       Quantity = 200,
                       IslnStock = true
                   },
                   new Product()
                   {
                       Id = 3,
                       Name = "Зomade",
                       Price = 120,
                       Discount = 80,
                       CategoryId = 3,
                       Quantity = 70,
                       IslnStock = true
                   }
               });
        }
        public static void SeedWorkert(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
               new Worker[]
               {
                   new Worker()
                   {
                       Id = 1,
                       Name = "Iruna",
                       Sername = "Onishchuk",
                       Salary = 80000,
                       Email = "onsshhuk086@gmail.com",
                       Phone = "+380680522048",
                       PositionId = 1,
                       ShopId = 1
                   },
                   new Worker()
                   {
                       Id = 2,
                       Name = "Tetiana",
                       Sername = "Poloshchuk",
                       Salary = 30000,
                       Email = "poll_tan@gmail.com",
                       Phone = "+380680590789",
                       PositionId = 2,
                       ShopId = 3
                   },
                   new Worker()
                   {
                       Id = 3,
                       Name = "Ann",
                       Sername = "Malyk",
                       Salary = 90000,
                       Email = "LunaM@gmail.com",
                       Phone = "+380687622008",
                       PositionId = 1,
                       ShopId = 1
                   }
               });
        }
    }

}


   


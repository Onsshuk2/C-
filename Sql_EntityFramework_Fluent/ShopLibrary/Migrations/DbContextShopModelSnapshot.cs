﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopLibrary;

#nullable disable

namespace ShopLibrary.Migrations
{
    [DbContext(typeof(DbContextShop))]
    partial class DbContextShopModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("ShopsId")
                        .HasColumnType("int");

                    b.HasKey("ProductsId", "ShopsId");

                    b.HasIndex("ShopsId");

                    b.ToTable("ProductShop");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Categori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categori");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Girl"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Boy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Children"
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Rivne"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Lviv"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Kyiv"
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Italy"
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Top Manegir"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Seller"
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<bool>("IslnStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Discount = 8f,
                            IslnStock = true,
                            Name = "Brush",
                            Price = 80m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Discount = 12f,
                            IslnStock = true,
                            Name = "Trimmer",
                            Price = 800m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Discount = 80f,
                            IslnStock = true,
                            Name = "Зomade",
                            Price = 120m,
                            Quantity = 70
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkingArea")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Addres = "Soborna 3a",
                            CityId = 1,
                            Name = "BeatyWord",
                            ParkingArea = 35
                        },
                        new
                        {
                            Id = 2,
                            Addres = "Shewchenka 14d",
                            CityId = 2,
                            Name = "BROW",
                            ParkingArea = 30
                        },
                        new
                        {
                            Id = 3,
                            Addres = "Soborna 44b",
                            CityId = 3,
                            Name = "Nail",
                            ParkingArea = 25
                        });
                });

            modelBuilder.Entity("ShopLibrary.Entities.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("ShopId");

                    b.ToTable("Worker");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "onsshhuk086@gmail.com",
                            Name = "Iruna",
                            Phone = "+380680522048",
                            PositionId = 1,
                            Salary = 80000m,
                            Sername = "Onishchuk",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "poll_tan@gmail.com",
                            Name = "Tetiana",
                            Phone = "+380680590789",
                            PositionId = 2,
                            Salary = 30000m,
                            Sername = "Poloshchuk",
                            ShopId = 3
                        },
                        new
                        {
                            Id = 3,
                            Email = "LunaM@gmail.com",
                            Name = "Ann",
                            Phone = "+380687622008",
                            PositionId = 1,
                            Salary = 90000m,
                            Sername = "Malyk",
                            ShopId = 1
                        });
                });

            modelBuilder.Entity("ProductShop", b =>
                {
                    b.HasOne("ShopLibrary.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopLibrary.Entities.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShopLibrary.Entities.City", b =>
                {
                    b.HasOne("ShopLibrary.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Product", b =>
                {
                    b.HasOne("ShopLibrary.Entities.Categori", "Categori")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categori");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Shop", b =>
                {
                    b.HasOne("ShopLibrary.Entities.City", "City")
                        .WithMany("Shops")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Worker", b =>
                {
                    b.HasOne("ShopLibrary.Entities.Position", "Position")
                        .WithMany("Workers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopLibrary.Entities.Shop", "Shop")
                        .WithMany("Workers")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Categori", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopLibrary.Entities.City", b =>
                {
                    b.Navigation("Shops");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Position", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("ShopLibrary.Entities.Shop", b =>
                {
                    b.Navigation("Workers");
                });
#pragma warning restore 612, 618
        }
    }
}

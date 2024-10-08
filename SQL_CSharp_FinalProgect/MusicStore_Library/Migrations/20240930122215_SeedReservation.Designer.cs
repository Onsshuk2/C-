﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore_Library;

#nullable disable

namespace MusicStore_Library.Migrations
{
    [DbContext(typeof(MusicDB))]
    [Migration("20240930122215_SeedReservation")]
    partial class SeedReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicStore_Library.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            FirstName = "Jane",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            FirstName = "Ann",
                            LastName = "Trincher"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 4,
                            FirstName = "Tina",
                            LastName = "Karol"
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ukraine"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "France"
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalSpent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ira",
                            LastName = "Onishchuk",
                            Password = "1111",
                            TotalSpent = 23m,
                            Username = "Ira083"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ann",
                            LastName = "Polishchuk",
                            Password = "****",
                            TotalSpent = 20m,
                            Username = "Ann013"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Olga",
                            LastName = "Franchuk",
                            Password = "1123",
                            TotalSpent = 10m,
                            Username = "Olga083"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Katerina",
                            LastName = "Shevchuk",
                            Password = "1211",
                            TotalSpent = 15m,
                            Username = "Kate083"
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "POP"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rok"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Modern"
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("NameRecord")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("GenreId");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            Discount = 10m,
                            GenreId = 4,
                            NameRecord = "Greatest Hits",
                            Price = 1000m,
                            Year = 2020
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 2,
                            Discount = 15m,
                            GenreId = 2,
                            NameRecord = "The Best of Jane",
                            Price = 2000m,
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 3,
                            Discount = 13m,
                            GenreId = 1,
                            NameRecord = "Top 3 of Ukraine",
                            Price = 1500m,
                            Year = 2021
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 4,
                            Discount = 18m,
                            GenreId = 3,
                            NameRecord = "Best of the word",
                            Price = 2300m,
                            Year = 2021
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RecordId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            RecordId = 1,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 3,
                            RecordId = 3,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 4,
                            RecordId = 2,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 1,
                            RecordId = 4,
                            ReservationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 0, 3, 30, 0),
                            Name = "Unwritten",
                            RecordId = 1
                        },
                        new
                        {
                            Id = 2,
                            Duration = new TimeSpan(0, 0, 4, 0, 0),
                            Name = "Beatiful Things",
                            RecordId = 2
                        },
                        new
                        {
                            Id = 3,
                            Duration = new TimeSpan(0, 0, 5, 0, 0),
                            Name = "Enemy",
                            RecordId = 3
                        },
                        new
                        {
                            Id = 4,
                            Duration = new TimeSpan(0, 0, 5, 0, 0),
                            Name = "Everybody Knows",
                            RecordId = 4
                        });
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Artist", b =>
                {
                    b.HasOne("MusicStore_Library.Entities.Country", "Country")
                        .WithMany("Artists")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Record", b =>
                {
                    b.HasOne("MusicStore_Library.Entities.Artist", "Artist")
                        .WithMany("Record")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore_Library.Entities.Genre", "Genre")
                        .WithMany("Records")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Reservation", b =>
                {
                    b.HasOne("MusicStore_Library.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore_Library.Entities.Record", "Record")
                        .WithMany("Reservations")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Record");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Track", b =>
                {
                    b.HasOne("MusicStore_Library.Entities.Record", "Record")
                        .WithMany("Tracks")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Record");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Artist", b =>
                {
                    b.Navigation("Record");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Country", b =>
                {
                    b.Navigation("Artists");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Genre", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("MusicStore_Library.Entities.Record", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}

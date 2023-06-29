﻿// <auto-generated />
using FlightManagement.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightManagement.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightManagement.Shared.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LatitudeDegree")
                        .HasColumnType("int");

                    b.Property<int>("LatitudeMinute")
                        .HasColumnType("int");

                    b.Property<int>("LatitudeSecond")
                        .HasColumnType("int");

                    b.Property<int>("LongitudeDegree")
                        .HasColumnType("int");

                    b.Property<int>("LongitudeMinute")
                        .HasColumnType("int");

                    b.Property<int>("LongitudeSecond")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airports");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LatitudeDegree = 9,
                            LatitudeMinute = 34,
                            LatitudeSecond = 36,
                            LongitudeDegree = 13,
                            LongitudeMinute = 36,
                            LongitudeSecond = 43,
                            Name = "GUCY"
                        },
                        new
                        {
                            Id = 2,
                            LatitudeDegree = 14,
                            LatitudeMinute = 44,
                            LatitudeSecond = 23,
                            LongitudeDegree = 17,
                            LongitudeMinute = 29,
                            LongitudeSecond = 25,
                            Name = "GOOY"
                        },
                        new
                        {
                            Id = 3,
                            LatitudeDegree = 5,
                            LatitudeMinute = 15,
                            LatitudeSecond = 40,
                            LongitudeDegree = 3,
                            LongitudeMinute = 54,
                            LongitudeSecond = 34,
                            Name = "DIAP"
                        },
                        new
                        {
                            Id = 4,
                            LatitudeDegree = 12,
                            LatitudeMinute = 38,
                            LatitudeSecond = 0,
                            LongitudeDegree = 8,
                            LongitudeMinute = 1,
                            LongitudeSecond = 0,
                            Name = "GABS"
                        },
                        new
                        {
                            Id = 5,
                            LatitudeDegree = 8,
                            LatitudeMinute = 37,
                            LatitudeSecond = 0,
                            LongitudeDegree = 13,
                            LongitudeMinute = 12,
                            LongitudeSecond = 0,
                            Name = "GFLL"
                        },
                        new
                        {
                            Id = 6,
                            LatitudeDegree = 6,
                            LatitudeMinute = 15,
                            LatitudeSecond = 10,
                            LongitudeDegree = 10,
                            LongitudeMinute = 21,
                            LongitudeSecond = 0,
                            Name = "GLRB"
                        },
                        new
                        {
                            Id = 7,
                            LatitudeDegree = 11,
                            LatitudeMinute = 53,
                            LatitudeSecond = 41,
                            LongitudeDegree = 15,
                            LongitudeMinute = 39,
                            LongitudeSecond = 13,
                            Name = "GGOV"
                        });
                });

            modelBuilder.Entity("FlightManagement.Shared.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirportId")
                        .HasColumnType("int");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightManagement.Shared.Flight", b =>
                {
                    b.HasOne("FlightManagement.Shared.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airport");
                });
#pragma warning restore 612, 618
        }
    }
}

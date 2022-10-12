﻿// <auto-generated />
using System;
using AltenAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AltenAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AltenAPI.Entities.Booking", b =>
                {
                    b.Property<Guid>("bookingNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("date");

                    b.Property<bool>("isCancelled")
                        .HasColumnType("bit");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("bookingNumber");

                    b.ToTable("tbBooking");
                });

            modelBuilder.Entity("AltenAPI.Entities.Hotel", b =>
                {
                    b.Property<int>("hotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("hotelId"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("hotelId");

                    b.ToTable("tbHotel");
                });

            modelBuilder.Entity("AltenAPI.Entities.Room", b =>
                {
                    b.Property<int>("roomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roomId"), 1L, 1);

                    b.Property<int>("hotelId")
                        .HasColumnType("int");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.HasKey("roomId");

                    b.ToTable("tbRoom");
                });

            modelBuilder.Entity("AltenAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

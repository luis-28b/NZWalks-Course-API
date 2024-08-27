﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NZWalks.API.Data;

#nullable disable

namespace NZWalks.API.Migrations
{
    [DbContext(typeof(NZWalksDbContext))]
    partial class NZWalksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NZWalks.API.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5e4c1aa0-7379-42d0-b7f6-f78117a9ced5"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("0892b522-5926-4980-ac67-a9f527448b5f"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("d3a0146f-2926-4706-9b4b-846b7275a808"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("370d19d1-ae10-41f1-aa9d-0908022c900f"),
                            Code = "AKL",
                            Name = "Auckland",
                            RegionImageUrl = "https://images-test.com/image/akl-1.jpg"
                        },
                        new
                        {
                            Id = new Guid("d47fed92-587e-4d21-a3a0-1d087ad271fb"),
                            Code = "NTL",
                            Name = "Northland",
                            RegionImageUrl = "https://images-test.com/image/ntl-1.jpg"
                        },
                        new
                        {
                            Id = new Guid("be9fbb5a-4a3e-4424-9362-95061abd1175"),
                            Code = "BOP",
                            Name = "Bay Of Plenty",
                            RegionImageUrl = "https://images-test.com/image/bop-1.jpg"
                        },
                        new
                        {
                            Id = new Guid("a80ffec9-4b34-41f6-aa81-46cf037e498a"),
                            Code = "WGN",
                            Name = "Wellington",
                            RegionImageUrl = "https://images-test.com/image/wgn-1.jpg"
                        },
                        new
                        {
                            Id = new Guid("a5b6b52b-c2c6-4f14-853c-53eb4b8b10e1"),
                            Code = "NSN",
                            Name = "Nelson",
                            RegionImageUrl = "https://images-test.com/image/nsn-1.jpg"
                        },
                        new
                        {
                            Id = new Guid("d12f5f47-ee13-4335-b420-63c4c29e2335"),
                            Code = "STL",
                            Name = "Southland",
                            RegionImageUrl = "https://images-test.com/image/stl-1.jpg"
                        });
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NZWalks.API.Models.Domain.Walk", b =>
                {
                    b.HasOne("NZWalks.API.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NZWalks.API.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}

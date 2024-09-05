using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty>  Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed the data for Difficulties: Easy, Medium, Hard
            var difficulties = new List<Difficulty>() {
                new Difficulty() {
                    Id = Guid.Parse("5e4c1aa0-7379-42d0-b7f6-f78117a9ced5"),
                    Name = "Easy",
                },
                new Difficulty() {
                    Id = Guid.Parse("0892b522-5926-4980-ac67-a9f527448b5f"),
                    Name = "Medium",
                },
                new Difficulty() {
                    Id = Guid.Parse("d3a0146f-2926-4706-9b4b-846b7275a808"),
                    Name = "Hard",
                },
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>() {
                new Region() {
                    Id = Guid.Parse("370d19d1-ae10-41f1-aa9d-0908022c900f"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images-test.com/image/akl-1.jpg"
                },
                new Region() {
                    Id = Guid.Parse("d47fed92-587e-4d21-a3a0-1d087ad271fb"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://images-test.com/image/ntl-1.jpg"
                },
                new Region() {
                    Id = Guid.Parse("be9fbb5a-4a3e-4424-9362-95061abd1175"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://images-test.com/image/bop-1.jpg"
                },
                new Region() {
                    Id = Guid.Parse("a80ffec9-4b34-41f6-aa81-46cf037e498a"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images-test.com/image/wgn-1.jpg"
                },
                new Region() {
                    Id = Guid.Parse("a5b6b52b-c2c6-4f14-853c-53eb4b8b10e1"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images-test.com/image/nsn-1.jpg"
                },
                new Region() {
                    Id = Guid.Parse("d12f5f47-ee13-4335-b420-63c4c29e2335"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://images-test.com/image/stl-1.jpg"
                },
            };
            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0892b522-5926-4980-ac67-a9f527448b5f"), "Medium" },
                    { new Guid("5e4c1aa0-7379-42d0-b7f6-f78117a9ced5"), "Easy" },
                    { new Guid("d3a0146f-2926-4706-9b4b-846b7275a808"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("370d19d1-ae10-41f1-aa9d-0908022c900f"), "AKL", "Auckland", "https://images-test.com/image/akl-1.jpg" },
                    { new Guid("a5b6b52b-c2c6-4f14-853c-53eb4b8b10e1"), "NSN", "Nelson", "https://images-test.com/image/nsn-1.jpg" },
                    { new Guid("a80ffec9-4b34-41f6-aa81-46cf037e498a"), "WGN", "Wellington", "https://images-test.com/image/wgn-1.jpg" },
                    { new Guid("be9fbb5a-4a3e-4424-9362-95061abd1175"), "BOP", "Bay Of Plenty", "https://images-test.com/image/bop-1.jpg" },
                    { new Guid("d12f5f47-ee13-4335-b420-63c4c29e2335"), "STL", "Southland", "https://images-test.com/image/stl-1.jpg" },
                    { new Guid("d47fed92-587e-4d21-a3a0-1d087ad271fb"), "NTL", "Northland", "https://images-test.com/image/ntl-1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0892b522-5926-4980-ac67-a9f527448b5f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5e4c1aa0-7379-42d0-b7f6-f78117a9ced5"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d3a0146f-2926-4706-9b4b-846b7275a808"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("370d19d1-ae10-41f1-aa9d-0908022c900f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5b6b52b-c2c6-4f14-853c-53eb4b8b10e1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a80ffec9-4b34-41f6-aa81-46cf037e498a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("be9fbb5a-4a3e-4424-9362-95061abd1175"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d12f5f47-ee13-4335-b420-63c4c29e2335"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d47fed92-587e-4d21-a3a0-1d087ad271fb"));
        }
    }
}

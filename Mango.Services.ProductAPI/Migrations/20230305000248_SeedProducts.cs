﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mango.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "productId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Shit", "https://dotnetmastery.blob.core.windows.net/mango/14.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "Shit", "https://dotnetmastery.blob.core.windows.net/mango/12.jpg", "Cup Cake", 18.0 },
                    { 3, "Appetizer", "Shit", "https://dotnetmastery.blob.core.windows.net/mango/11.jpg", "Shawarma", 22.0 },
                    { 4, "Appetizer", "Shit", "https://dotnetmastery.blob.core.windows.net/mango/13.jpg", "Pizza", 16.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "productId",
                keyValue: 4);
        }
    }
}

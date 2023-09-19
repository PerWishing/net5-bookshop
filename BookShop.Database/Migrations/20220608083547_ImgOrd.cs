using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Database.Migrations
{
    public partial class ImgOrd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CustomerImage",
                table: "Orders",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SellerImage",
                table: "Orders",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerImage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SellerImage",
                table: "Orders");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Database.Migrations
{
    public partial class DateAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentOfCancel",
                table: "Orders",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfClosingOrder",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfStatusChangeForCustomer",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfStatusChangeForSeller",
                table: "Orders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentOfCancel",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfClosingOrder",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfStatusChangeForCustomer",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateOfStatusChangeForSeller",
                table: "Orders");
        }
    }
}

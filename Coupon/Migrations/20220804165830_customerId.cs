using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coupon.Migrations
{
    public partial class customerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Used",
                table: "OTPs");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "OTPs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OTPs");

            migrationBuilder.AddColumn<bool>(
                name: "Used",
                table: "OTPs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Coupon.Migrations
{
    public partial class Customer_auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAuthenticated",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAuthenticated",
                table: "Customers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRUs.Repository.Migrations
{
    public partial class Inital4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "CustomerTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts");

            migrationBuilder.AddColumn<string>(
                name: "DiscountRate",
                table: "CustomerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId");
        }
    }
}

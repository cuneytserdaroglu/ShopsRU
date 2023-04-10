using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRUs.Repository.Migrations
{
    public partial class Inital6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_CustomerTypes_CustomerTypeId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "Discounts");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "CustomerTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTypes_DiscountId",
                table: "CustomerTypes",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerTypes_Discounts_DiscountId",
                table: "CustomerTypes",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerTypes_Discounts_DiscountId",
                table: "CustomerTypes");

            migrationBuilder.DropIndex(
                name: "IX_CustomerTypes_DiscountId",
                table: "CustomerTypes");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "CustomerTypes");

            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_CustomerTypes_CustomerTypeId",
                table: "Discounts",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

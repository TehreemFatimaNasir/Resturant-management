using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Foods_foodid",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_foodid",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "foodid",
                table: "Carts",
                newName: "subtotal");

            migrationBuilder.AddColumn<string>(
                name: "foodname",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foodname",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "subtotal",
                table: "Carts",
                newName: "foodid");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_foodid",
                table: "Carts",
                column: "foodid");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Foods_foodid",
                table: "Carts",
                column: "foodid",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

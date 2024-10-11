using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrbComercialInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustProductAndCategoryAjustSupplierStateAndCity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Suppliers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_StateId",
                table: "Suppliers",
                newName: "IX_Suppliers_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Cities_CityId",
                table: "Suppliers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Cities_CityId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Suppliers",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_CityId",
                table: "Suppliers",
                newName: "IX_Suppliers_StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SrbComercialInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustProductAndCategoryAjustSupplierStateAndCity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Cities_CityId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_States_CityId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "States");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CityId",
                table: "States",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Cities_CityId",
                table: "States",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_States_StateId",
                table: "Suppliers",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

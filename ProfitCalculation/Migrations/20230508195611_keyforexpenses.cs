using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class keyforexpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Conversions_Price",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "basic_Pricing",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conversions_Price",
                table: "Conversions_Price",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_basic_Pricing",
                table: "basic_Pricing",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversions_Price",
                table: "Conversions_Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_basic_Pricing",
                table: "basic_Pricing");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Conversions_Price");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "basic_Pricing");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class anotherkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversions_Price",
                table: "Conversions_Price");

            migrationBuilder.DropIndex(
                name: "IX_Conversions_Price_ConversionsID",
                table: "Conversions_Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_basic_Pricing",
                table: "basic_Pricing");

            migrationBuilder.DropIndex(
                name: "IX_basic_Pricing_CipherID",
                table: "basic_Pricing");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Conversions_Price");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "basic_Pricing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conversions_Price",
                table: "Conversions_Price",
                column: "ConversionsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_basic_Pricing",
                table: "basic_Pricing",
                column: "CipherID");
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

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_Price_ConversionsID",
                table: "Conversions_Price",
                column: "ConversionsID");

            migrationBuilder.CreateIndex(
                name: "IX_basic_Pricing_CipherID",
                table: "basic_Pricing",
                column: "CipherID");
        }
    }
}

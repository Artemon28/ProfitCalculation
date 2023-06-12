using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class anotherkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversions_Price",
                table: "Conversions_Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_basic_Pricing",
                table: "basic_Pricing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConversionsPrice",
                table: "Conversions_Price",
                column: "ConversionsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BasicPricing",
                table: "basic_Pricing",
                column: "CipherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConversionsPrice",
                table: "Conversions_Price");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BasicPricing",
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
    }
}

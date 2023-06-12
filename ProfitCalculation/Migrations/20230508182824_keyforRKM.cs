using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class keyforRKM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "guide_Calculation_Materials",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guide_Calculation_Materials",
                table: "guide_Calculation_Materials",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_guide_Calculation_Materials",
                table: "guide_Calculation_Materials");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "guide_Calculation_Materials");
        }
    }
}

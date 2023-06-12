using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class moredigits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "guide_Orders_details",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Exchange",
                table: "guide_Currency",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "guide_Cipher",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "guide_Cipher",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "avgPrice",
                table: "Conversions_Price",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Wastes",
                table: "basic_Pricing",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SpecialTreatment",
                table: "basic_Pricing",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Social_Insurance",
                table: "basic_Pricing",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "basic_Pricing",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AuxiliaryAdditionalExpenses",
                table: "basic_Pricing",
                type: "decimal(11,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "guide_Orders_details",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Exchange",
                table: "guide_Currency",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "guide_Cipher",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "guide_Cipher",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "avgPrice",
                table: "Conversions_Price",
                type: "decimal(8,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Wastes",
                table: "basic_Pricing",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SpecialTreatment",
                table: "basic_Pricing",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Social_Insurance",
                table: "basic_Pricing",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "basic_Pricing",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AuxiliaryAdditionalExpenses",
                table: "basic_Pricing",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)",
                oldNullable: true);
        }
    }
}

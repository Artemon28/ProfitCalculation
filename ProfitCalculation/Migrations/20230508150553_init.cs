using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitCalculation.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guide_Counterparty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Counterparty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "guide_Currency",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Exchange = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "guide_Types",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    TypeShort = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Types", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "guide_Units_Measurement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    shortName = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Units_Measurement", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "guide_Workshops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    WorkshopName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Workshops", x => x.ID);
                    table.UniqueConstraint("AK_guide_Workshops_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "guide_Contracts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    СounterpartyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Contracts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guide_Contracts_guide_Counterparty",
                        column: x => x.СounterpartyID,
                        principalTable: "guide_Counterparty",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "guide_Cipher",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    CipherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_cipher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guide_Cipher_guide_Types",
                        column: x => x.TypeID,
                        principalTable: "guide_Types",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "guide_Conversions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    ConversionName = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quide_Conversions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guide_Conversions_guide_Workshops",
                        column: x => x.WorkshopID,
                        principalTable: "guide_Workshops",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "guide_Orders_header",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ContractID = table.Column<int>(type: "int", nullable: false),
                    CargoRecipientID = table.Column<int>(type: "int", nullable: false),
                    PayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Orders_header", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guide_Orders_header_guide_Contracts",
                        column: x => x.ContractID,
                        principalTable: "guide_Contracts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Orders_header_guide_Counterparty",
                        column: x => x.CargoRecipientID,
                        principalTable: "guide_Counterparty",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Orders_header_guide_Counterparty1",
                        column: x => x.PayerID,
                        principalTable: "guide_Counterparty",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "basic_Pricing",
                columns: table => new
                {
                    ConversionID = table.Column<int>(type: "int", nullable: true),
                    CipherID = table.Column<long>(type: "bigint", nullable: false),
                    Wastes = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    AuxiliaryAdditionalExpenses = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    SpecialTreatment = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Social_Insurance = table.Column<decimal>(type: "decimal(8,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_basic_Pricing_guide_Cipher",
                        column: x => x.CipherID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_basic_Pricing_guide_Conversions",
                        column: x => x.ConversionID,
                        principalTable: "guide_Conversions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Conversions_Price",
                columns: table => new
                {
                    ConversionsID = table.Column<int>(type: "int", nullable: false),
                    avgPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Conversions_Price_guide_Conversions",
                        column: x => x.ConversionsID,
                        principalTable: "guide_Conversions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "guide_Calculation_Materials",
                columns: table => new
                {
                    MainSign = table.Column<int>(type: "int", nullable: true),
                    ConversionID = table.Column<int>(type: "int", nullable: true),
                    ReleaseID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedForID = table.Column<long>(type: "bigint", nullable: true),
                    ExpenseRatio = table.Column<decimal>(type: "decimal(5,3)", nullable: true),
                    LaborIntensityRatio = table.Column<decimal>(type: "decimal(5,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_guide_Calculation_Materials_guide_Cipher",
                        column: x => x.ReleaseID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Calculation_Materials_guide_Cipher1",
                        column: x => x.CreatedForID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Calculation_Materials_guide_Conversions",
                        column: x => x.ConversionID,
                        principalTable: "guide_Conversions",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Result_Chains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionId = table.Column<int>(type: "int", nullable: true),
                    ReleaseID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedForID = table.Column<long>(type: "bigint", nullable: true),
                    BaseMaterialID = table.Column<long>(type: "bigint", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: false),
                    ExpenseRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThroughFlowRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Distribute = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Remain = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Wastes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    addExpenses = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result_Chains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultChain_BaseMaterial",
                        column: x => x.BaseMaterialID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ResultChain_Conversion",
                        column: x => x.ConversionId,
                        principalTable: "guide_Conversions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ResultChain_CreatedFor",
                        column: x => x.CreatedForID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ResultChain_Release",
                        column: x => x.ReleaseID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "guide_Orders_details",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    HeaderID = table.Column<int>(type: "int", nullable: false),
                    CipherID = table.Column<long>(type: "bigint", nullable: false),
                    UnitsMeasurementID = table.Column<int>(type: "int", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_Orders_details", x => x.ID);
                    table.ForeignKey(
                        name: "FK_guide_Orders_details_guide_Cipher",
                        column: x => x.CipherID,
                        principalTable: "guide_Cipher",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Orders_details_guide_Currency",
                        column: x => x.CurrencyID,
                        principalTable: "guide_Currency",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Orders_details_guide_Orders_header",
                        column: x => x.HeaderID,
                        principalTable: "guide_Orders_header",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_guide_Orders_details_guide_Units_Measurement",
                        column: x => x.UnitsMeasurementID,
                        principalTable: "guide_Units_Measurement",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_basic_Pricing_CipherID",
                table: "basic_Pricing",
                column: "CipherID");

            migrationBuilder.CreateIndex(
                name: "IX_basic_Pricing_ConversionID",
                table: "basic_Pricing",
                column: "ConversionID");

            migrationBuilder.CreateIndex(
                name: "IX_Conversions_Price_ConversionsID",
                table: "Conversions_Price",
                column: "ConversionsID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Calculation_Materials_ConversionID",
                table: "guide_Calculation_Materials",
                column: "ConversionID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Calculation_Materials_CreatedForID",
                table: "guide_Calculation_Materials",
                column: "CreatedForID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Calculation_Materials_ReleaseID",
                table: "guide_Calculation_Materials",
                column: "ReleaseID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Cipher_TypeID",
                table: "guide_Cipher",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Contracts_СounterpartyID",
                table: "guide_Contracts",
                column: "СounterpartyID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Conversions_WorkshopID",
                table: "guide_Conversions",
                column: "WorkshopID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_details_CipherID",
                table: "guide_Orders_details",
                column: "CipherID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_details_CurrencyID",
                table: "guide_Orders_details",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_details_HeaderID",
                table: "guide_Orders_details",
                column: "HeaderID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_details_UnitsMeasurementID",
                table: "guide_Orders_details",
                column: "UnitsMeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_header_CargoRecipientID",
                table: "guide_Orders_header",
                column: "CargoRecipientID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_header_ContractID",
                table: "guide_Orders_header",
                column: "ContractID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Orders_header_PayerID",
                table: "guide_Orders_header",
                column: "PayerID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_Workshops",
                table: "guide_Workshops",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_Chains_BaseMaterialID",
                table: "Result_Chains",
                column: "BaseMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Chains_ConversionId",
                table: "Result_Chains",
                column: "ConversionId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Chains_CreatedForID",
                table: "Result_Chains",
                column: "CreatedForID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Chains_ReleaseID",
                table: "Result_Chains",
                column: "ReleaseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "basic_Pricing");

            migrationBuilder.DropTable(
                name: "Conversions_Price");

            migrationBuilder.DropTable(
                name: "guide_Calculation_Materials");

            migrationBuilder.DropTable(
                name: "guide_Orders_details");

            migrationBuilder.DropTable(
                name: "Result_Chains");

            migrationBuilder.DropTable(
                name: "guide_Currency");

            migrationBuilder.DropTable(
                name: "guide_Orders_header");

            migrationBuilder.DropTable(
                name: "guide_Units_Measurement");

            migrationBuilder.DropTable(
                name: "guide_Cipher");

            migrationBuilder.DropTable(
                name: "guide_Conversions");

            migrationBuilder.DropTable(
                name: "guide_Contracts");

            migrationBuilder.DropTable(
                name: "guide_Types");

            migrationBuilder.DropTable(
                name: "guide_Workshops");

            migrationBuilder.DropTable(
                name: "guide_Counterparty");
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfitCalculation.DataBase.Models;

#nullable disable

namespace ProfitCalculation.Migrations
{
    [DbContext(typeof(ProfitCalculatingContext))]
    [Migration("20230508150553_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.BasicPricing", b =>
                {
                    b.Property<decimal?>("AuxiliaryAdditionalExpenses")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<long>("CipherId")
                        .HasColumnType("bigint")
                        .HasColumnName("CipherID");

                    b.Property<int?>("ConversionId")
                        .HasColumnType("int")
                        .HasColumnName("ConversionID");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<decimal?>("SocialInsurance")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("Social_Insurance");

                    b.Property<decimal?>("SpecialTreatment")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<decimal?>("Wastes")
                        .HasColumnType("decimal(8, 2)");

                    b.HasIndex("CipherId");

                    b.HasIndex("ConversionId");

                    b.ToTable("basic_Pricing", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.ConversionsPrice", b =>
                {
                    b.Property<decimal>("AvgPrice")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("avgPrice");

                    b.Property<int>("ConversionsId")
                        .HasColumnType("int")
                        .HasColumnName("ConversionsID");

                    b.HasIndex("ConversionsId");

                    b.ToTable("Conversions_Price", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCalculationMaterial", b =>
                {
                    b.Property<int?>("ConversionId")
                        .HasColumnType("int")
                        .HasColumnName("ConversionID");

                    b.Property<long?>("CreatedForId")
                        .HasColumnType("bigint")
                        .HasColumnName("CreatedForID");

                    b.Property<decimal?>("ExpenseRatio")
                        .HasColumnType("decimal(5, 3)");

                    b.Property<decimal?>("LaborIntensityRatio")
                        .HasColumnType("decimal(5, 3)");

                    b.Property<int?>("MainSign")
                        .HasColumnType("int");

                    b.Property<long>("ReleaseId")
                        .HasColumnType("bigint")
                        .HasColumnName("ReleaseID");

                    b.HasIndex("ConversionId");

                    b.HasIndex("CreatedForId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("guide_Calculation_Materials", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCipher", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("CipherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int")
                        .HasColumnName("TypeID");

                    b.HasKey("Id")
                        .HasName("PK_guide_cipher");

                    b.HasIndex("TypeId");

                    b.ToTable("guide_Cipher", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideContract", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int>("СounterpartyId")
                        .HasColumnType("int")
                        .HasColumnName("СounterpartyID");

                    b.HasKey("Id");

                    b.HasIndex("СounterpartyId");

                    b.ToTable("guide_Contracts", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideConversion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("ConversionName")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int")
                        .HasColumnName("WorkshopID");

                    b.HasKey("Id")
                        .HasName("PK_quide_Conversions");

                    b.HasIndex("WorkshopId");

                    b.ToTable("guide_Conversions", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCounterparty", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("guide_Counterparty", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCurrency", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<decimal>("Exchange")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("guide_Currency", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideOrdersDetail", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long>("CipherId")
                        .HasColumnType("bigint")
                        .HasColumnName("CipherID");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int")
                        .HasColumnName("CurrencyID");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<int>("HeaderId")
                        .HasColumnType("int")
                        .HasColumnName("HeaderID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UnitsMeasurementId")
                        .HasColumnType("int")
                        .HasColumnName("UnitsMeasurementID");

                    b.HasKey("Id");

                    b.HasIndex("CipherId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("HeaderId");

                    b.HasIndex("UnitsMeasurementId");

                    b.ToTable("guide_Orders_details", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideOrdersHeader", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("CargoRecipientId")
                        .HasColumnType("int")
                        .HasColumnName("CargoRecipientID");

                    b.Property<int>("ContractId")
                        .HasColumnType("int")
                        .HasColumnName("ContractID");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PayerId")
                        .HasColumnType("int")
                        .HasColumnName("PayerID");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargoRecipientId");

                    b.HasIndex("ContractId");

                    b.HasIndex("PayerId");

                    b.ToTable("guide_Orders_header", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("TypeShort")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("guide_Types", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideUnitsMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("shortName");

                    b.HasKey("Id");

                    b.ToTable("guide_Units_Measurement", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideWorkshop", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("WorkshopName")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Code" }, "IX_guide_Workshops")
                        .IsUnique();

                    b.ToTable("guide_Workshops", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.ResultChain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,3)");

                    b.Property<long?>("BaseMaterialId")
                        .HasColumnType("bigint")
                        .HasColumnName("BaseMaterialID");

                    b.Property<int?>("ConversionId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CreatedForId")
                        .HasColumnType("bigint")
                        .HasColumnName("CreatedForID");

                    b.Property<decimal>("Distribute")
                        .HasColumnType("decimal(18,3)");

                    b.Property<decimal>("EndCostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ExpenseRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ReleaseId")
                        .HasColumnType("bigint")
                        .HasColumnName("ReleaseID");

                    b.Property<decimal>("Remain")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThroughFlowRatio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Wastes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("addExpenses")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BaseMaterialId");

                    b.HasIndex("ConversionId");

                    b.HasIndex("CreatedForId");

                    b.HasIndex("ReleaseId");

                    b.ToTable("Result_Chains", (string)null);
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.BasicPricing", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "Cipher")
                        .WithMany()
                        .HasForeignKey("CipherId")
                        .IsRequired()
                        .HasConstraintName("FK_basic_Pricing_guide_Cipher");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideConversion", "Conversion")
                        .WithMany()
                        .HasForeignKey("ConversionId")
                        .HasConstraintName("FK_basic_Pricing_guide_Conversions");

                    b.Navigation("Cipher");

                    b.Navigation("Conversion");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.ConversionsPrice", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideConversion", "Conversions")
                        .WithMany()
                        .HasForeignKey("ConversionsId")
                        .IsRequired()
                        .HasConstraintName("FK_Conversions_Price_guide_Conversions");

                    b.Navigation("Conversions");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCalculationMaterial", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideConversion", "Conversion")
                        .WithMany()
                        .HasForeignKey("ConversionId")
                        .HasConstraintName("FK_guide_Calculation_Materials_guide_Conversions");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "CreatedFor")
                        .WithMany()
                        .HasForeignKey("CreatedForId")
                        .HasConstraintName("FK_guide_Calculation_Materials_guide_Cipher1");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "Release")
                        .WithMany()
                        .HasForeignKey("ReleaseId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Calculation_Materials_guide_Cipher");

                    b.Navigation("Conversion");

                    b.Navigation("CreatedFor");

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCipher", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideType", "Type")
                        .WithMany("GuideCiphers")
                        .HasForeignKey("TypeId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Cipher_guide_Types");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideContract", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCounterparty", "Сounterparty")
                        .WithMany("GuideContracts")
                        .HasForeignKey("СounterpartyId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Contracts_guide_Counterparty");

                    b.Navigation("Сounterparty");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideConversion", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideWorkshop", "Workshop")
                        .WithMany("GuideConversions")
                        .HasForeignKey("WorkshopId")
                        .HasPrincipalKey("Code")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Conversions_guide_Workshops");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideOrdersDetail", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "Cipher")
                        .WithMany("GuideOrdersDetails")
                        .HasForeignKey("CipherId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_details_guide_Cipher");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCurrency", "Currency")
                        .WithMany("GuideOrdersDetails")
                        .HasForeignKey("CurrencyId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_details_guide_Currency");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideOrdersHeader", "Header")
                        .WithMany("GuideOrdersDetails")
                        .HasForeignKey("HeaderId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_details_guide_Orders_header");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideUnitsMeasurement", "UnitsMeasurement")
                        .WithMany("GuideOrdersDetails")
                        .HasForeignKey("UnitsMeasurementId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_details_guide_Units_Measurement");

                    b.Navigation("Cipher");

                    b.Navigation("Currency");

                    b.Navigation("Header");

                    b.Navigation("UnitsMeasurement");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideOrdersHeader", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCounterparty", "CargoRecipient")
                        .WithMany("GuideOrdersHeaderCargoRecipients")
                        .HasForeignKey("CargoRecipientId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_header_guide_Counterparty");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideContract", "Contract")
                        .WithMany("GuideOrdersHeaders")
                        .HasForeignKey("ContractId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_header_guide_Contracts");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCounterparty", "Payer")
                        .WithMany("GuideOrdersHeaderPayers")
                        .HasForeignKey("PayerId")
                        .IsRequired()
                        .HasConstraintName("FK_guide_Orders_header_guide_Counterparty1");

                    b.Navigation("CargoRecipient");

                    b.Navigation("Contract");

                    b.Navigation("Payer");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.ResultChain", b =>
                {
                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "BaseMaterial")
                        .WithMany("ResultBaseMaterial")
                        .HasForeignKey("BaseMaterialId")
                        .HasConstraintName("FK_ResultChain_BaseMaterial");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideConversion", "Conversion")
                        .WithMany("ResultChains")
                        .HasForeignKey("ConversionId")
                        .HasConstraintName("FK_ResultChain_Conversion");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "CreatedFor")
                        .WithMany("ResultChainCreatedFor")
                        .HasForeignKey("CreatedForId")
                        .HasConstraintName("FK_ResultChain_CreatedFor");

                    b.HasOne("ProfitCalculation.DataBase.Models.GuideCipher", "Release")
                        .WithMany("ResultChainRelease")
                        .HasForeignKey("ReleaseId")
                        .IsRequired()
                        .HasConstraintName("FK_ResultChain_Release");

                    b.Navigation("BaseMaterial");

                    b.Navigation("Conversion");

                    b.Navigation("CreatedFor");

                    b.Navigation("Release");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCipher", b =>
                {
                    b.Navigation("GuideOrdersDetails");

                    b.Navigation("ResultBaseMaterial");

                    b.Navigation("ResultChainCreatedFor");

                    b.Navigation("ResultChainRelease");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideContract", b =>
                {
                    b.Navigation("GuideOrdersHeaders");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideConversion", b =>
                {
                    b.Navigation("ResultChains");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCounterparty", b =>
                {
                    b.Navigation("GuideContracts");

                    b.Navigation("GuideOrdersHeaderCargoRecipients");

                    b.Navigation("GuideOrdersHeaderPayers");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideCurrency", b =>
                {
                    b.Navigation("GuideOrdersDetails");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideOrdersHeader", b =>
                {
                    b.Navigation("GuideOrdersDetails");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideType", b =>
                {
                    b.Navigation("GuideCiphers");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideUnitsMeasurement", b =>
                {
                    b.Navigation("GuideOrdersDetails");
                });

            modelBuilder.Entity("ProfitCalculation.DataBase.Models.GuideWorkshop", b =>
                {
                    b.Navigation("GuideConversions");
                });
#pragma warning restore 612, 618
        }
    }
}

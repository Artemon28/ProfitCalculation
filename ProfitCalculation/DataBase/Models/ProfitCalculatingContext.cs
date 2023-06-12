using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProfitCalculation.DataBase.Models;

public partial class ProfitCalculatingContext : DbContext
{
    public ProfitCalculatingContext()
    {
    }

    public ProfitCalculatingContext(DbContextOptions<ProfitCalculatingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BasicPricing> BasicPricings { get; set; }

    public virtual DbSet<ConversionsPrice> ConversionsPrices { get; set; }

    public virtual DbSet<GuideCalculationMaterial> GuideCalculationMaterials { get; set; }

    public virtual DbSet<GuideCipher> GuideCiphers { get; set; }

    public virtual DbSet<GuideContract> GuideContracts { get; set; }

    public virtual DbSet<GuideConversion> GuideConversions { get; set; }

    public virtual DbSet<GuideCounterparty> GuideCounterparties { get; set; }

    public virtual DbSet<GuideCurrency> GuideCurrencies { get; set; }

    public virtual DbSet<GuideOrdersDetail> GuideOrdersDetails { get; set; }

    public virtual DbSet<GuideOrdersHeader> GuideOrdersHeaders { get; set; }

    public virtual DbSet<GuideType> GuideTypes { get; set; }

    public virtual DbSet<GuideUnitsMeasurement> GuideUnitsMeasurements { get; set; }

    public virtual DbSet<GuideWorkshop> GuideWorkshops { get; set; }

    public virtual DbSet<ResultChain> ResultChains { get; set; }

    public virtual DbSet<ResultChain> OrderChains { get; set; }

    public virtual DbSet<ResultChain> CalcChains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=TestProfit;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BasicPricing>(entity =>
        {
            entity
                .ToTable("basic_Pricing");
            entity.HasKey(e => e.CipherId).HasName("PK_BasicPricing");

            entity.Property(e => e.AuxiliaryAdditionalExpenses).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.CipherId).HasColumnName("CipherID");
            entity.Property(e => e.ConversionId).HasColumnName("ConversionID");
            entity.Property(e => e.Salary).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.SocialInsurance)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("Social_Insurance");
            entity.Property(e => e.SpecialTreatment).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.Wastes).HasColumnType("decimal(11, 2)");

            entity.HasOne(d => d.Cipher).WithMany()
                .HasForeignKey(d => d.CipherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_basic_Pricing_guide_Cipher");

            entity.HasOne(d => d.Conversion).WithMany()
                .HasForeignKey(d => d.ConversionId)
                .HasConstraintName("FK_basic_Pricing_guide_Conversions");
        });

        modelBuilder.Entity<ConversionsPrice>(entity =>
        {
            entity
                .ToTable("Conversions_Price");
            entity.HasKey(e => e.ConversionsId).HasName("PK_ConversionsPrice");

            entity.Property(e => e.AvgPrice)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("avgPrice");
            entity.Property(e => e.ConversionsId).HasColumnName("ConversionsID");

            entity.HasOne(d => d.Conversions).WithMany()
                .HasForeignKey(d => d.ConversionsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conversions_Price_guide_Conversions");
        });

        modelBuilder.Entity<GuideCalculationMaterial>(entity =>
        {
            entity.ToTable("guide_Calculation_Materials");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.ConversionId).HasColumnName("ConversionID");
            entity.Property(e => e.CreatedForId).HasColumnName("CreatedForID");
            entity.Property(e => e.ExpenseRatio).HasColumnType("decimal(5, 3)");
            entity.Property(e => e.LaborIntensityRatio).HasColumnType("decimal(5, 3)");
            entity.Property(e => e.ReleaseId).HasColumnName("ReleaseID");

            entity.HasOne(d => d.Conversion).WithMany()
                .HasForeignKey(d => d.ConversionId)
                .HasConstraintName("FK_guide_Calculation_Materials_guide_Conversions");

            entity.HasOne(d => d.CreatedFor).WithMany()
                .HasForeignKey(d => d.CreatedForId)
                .HasConstraintName("FK_guide_Calculation_Materials_guide_Cipher1");

            entity.HasOne(d => d.Release).WithMany()
                .HasForeignKey(d => d.ReleaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Calculation_Materials_guide_Cipher");
        });

        modelBuilder.Entity<GuideCipher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_guide_cipher");

            entity.ToTable("guide_Cipher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.CipherName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.GuideCiphers)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Cipher_guide_Types");
        });

        modelBuilder.Entity<GuideContract>(entity =>
        {
            entity.ToTable("guide_Contracts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.СounterpartyId).HasColumnName("СounterpartyID");

            entity.HasOne(d => d.Сounterparty).WithMany(p => p.GuideContracts)
                .HasForeignKey(d => d.СounterpartyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Contracts_guide_Counterparty");
        });

        modelBuilder.Entity<GuideConversion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_quide_Conversions");

            entity.ToTable("guide_Conversions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConversionName).HasMaxLength(36);
            entity.Property(e => e.WorkshopId).HasColumnName("WorkshopID");

            entity.HasOne(d => d.Workshop).WithMany(p => p.GuideConversions)
                .HasPrincipalKey(p => p.Code)
                .HasForeignKey(d => d.WorkshopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Conversions_guide_Workshops");
        });

        modelBuilder.Entity<GuideCounterparty>(entity =>
        {
            entity.ToTable("guide_Counterparty");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<GuideCurrency>(entity =>
        {
            entity.ToTable("guide_Currency");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Exchange).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.Name).HasMaxLength(24);
            entity.Property(e => e.ShortName).HasMaxLength(5);
        });

        modelBuilder.Entity<GuideOrdersDetail>(entity =>
        {
            entity.ToTable("guide_Orders_details");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CipherId).HasColumnName("CipherID");
            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.DeliveryDate).HasColumnType("date");
            entity.Property(e => e.HeaderId).HasColumnName("HeaderID");
            entity.Property(e => e.Price).HasColumnType("decimal(11, 2)");
            entity.Property(e => e.Specifications).HasMaxLength(1000);
            entity.Property(e => e.UnitsMeasurementId).HasColumnName("UnitsMeasurementID");

            entity.HasOne(d => d.Cipher).WithMany(p => p.GuideOrdersDetails)
                .HasForeignKey(d => d.CipherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_details_guide_Cipher");

            entity.HasOne(d => d.Currency).WithMany(p => p.GuideOrdersDetails)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_details_guide_Currency");

            entity.HasOne(d => d.Header).WithMany(p => p.GuideOrdersDetails)
                .HasForeignKey(d => d.HeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_details_guide_Orders_header");

            entity.HasOne(d => d.UnitsMeasurement).WithMany(p => p.GuideOrdersDetails)
                .HasForeignKey(d => d.UnitsMeasurementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_details_guide_Units_Measurement");
        });

        modelBuilder.Entity<GuideOrdersHeader>(entity =>
        {
            entity.ToTable("guide_Orders_header");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CargoRecipientId).HasColumnName("CargoRecipientID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.PayerId).HasColumnName("PayerID");

            entity.HasOne(d => d.CargoRecipient).WithMany(p => p.GuideOrdersHeaderCargoRecipients)
                .HasForeignKey(d => d.CargoRecipientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_header_guide_Counterparty");

            entity.HasOne(d => d.Contract).WithMany(p => p.GuideOrdersHeaders)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_header_guide_Contracts");

            entity.HasOne(d => d.Payer).WithMany(p => p.GuideOrdersHeaderPayers)
                .HasForeignKey(d => d.PayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_guide_Orders_header_guide_Counterparty1");
        });

        modelBuilder.Entity<GuideType>(entity =>
        {
            entity.ToTable("guide_Types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.TypeName).HasMaxLength(36);
            entity.Property(e => e.TypeShort).HasMaxLength(8);
        });

        modelBuilder.Entity<GuideUnitsMeasurement>(entity =>
        {
            entity.ToTable("guide_Units_Measurement");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(8);
            entity.Property(e => e.ShortName)
                .HasMaxLength(3)
                .HasColumnName("shortName");
        });

        modelBuilder.Entity<GuideWorkshop>(entity =>
        {
            entity.ToTable("guide_Workshops");

            entity.HasIndex(e => e.Code, "IX_guide_Workshops").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.WorkshopName).HasMaxLength(36);
        });

        modelBuilder.Entity<ResultChain>(entity =>
        {
            entity.ToTable("Result_Chains");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ReleaseId).HasColumnName("ReleaseID");
            entity.Property(e => e.CreatedForId).HasColumnName("CreatedForID");
            entity.Property(e => e.BaseMaterialId).HasColumnName("BaseMaterialID");
            entity.Property(e => e.ExpenseRatio).HasColumnType("decimal(18,2)");
            entity.Property(e => e.ThroughFlowRatio).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Amount).HasColumnType("decimal(18,3)");
            entity.Property(e => e.Distribute).HasColumnType("decimal(18,3)");
            entity.Property(e => e.Remain).HasColumnType("decimal(18,3)");
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Wastes).HasColumnType("decimal(18,2)");
            entity.Property(e => e.addExpenses).HasColumnType("decimal(18,2)");
            entity.Property(e => e.CostPrice).HasColumnType("decimal(18,2)");
            entity.Property(e => e.EndCostPrice).HasColumnType("decimal(18,2)");

            entity.HasOne(d => d.Conversion)
                .WithMany(p => p.ResultChains)
                .HasForeignKey(d => d.ConversionId)
                .HasConstraintName("FK_ResultChain_Conversion");

            entity.HasOne(d => d.Release)
                .WithMany(p => p.ResultChainRelease)
                .HasForeignKey(d => d.ReleaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResultChain_Release");

            entity.HasOne(d => d.CreatedFor)
                .WithMany(p => p.ResultChainCreatedFor)
                .HasForeignKey(d => d.CreatedForId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResultChain_CreatedFor");

            entity.HasOne(d => d.BaseMaterial)
                .WithMany(p => p.ResultBaseMaterial)
                .HasForeignKey(d => d.BaseMaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResultChain_BaseMaterial");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

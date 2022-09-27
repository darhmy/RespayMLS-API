﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RespayMLS.Data;

namespace RespayMLS.Data.Migrations
{
    [DbContext(typeof(RespayMLSDbContext))]
    [Migration("20220927084004_AjustItemFeatureTable")]
    partial class AjustItemFeatureTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RespayMLS.Core.Models.Charge", b =>
                {
                    b.Property<int>("ChargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<double>("SetupFee")
                        .HasColumnType("float");

                    b.HasKey("ChargeId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("FrequencyId");

                    b.ToTable("Charge");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencySymbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Frequency", b =>
                {
                    b.Property<int>("FrequencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysInPeriod")
                        .HasColumnType("int");

                    b.Property<string>("FrequencyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrequencyTenure")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FrequencyId");

                    b.ToTable("Frequencies");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemFeature", b =>
                {
                    b.Property<int>("ItemFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeatureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("ItemFeatureId");

                    b.HasIndex("SectorId");

                    b.ToTable("ItemFeatures");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemSubFeature", b =>
                {
                    b.Property<int>("ItemSubFeatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemSubFeatureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("ItemSubFeatureId");

                    b.HasIndex("SectorId");

                    b.ToTable("ItemSubFeatures");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemSubType", b =>
                {
                    b.Property<int>("ItemSubTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemSubTypeId");

                    b.ToTable("ItemSubTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypeId");

                    b.HasIndex("SectorId");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ListingType", b =>
                {
                    b.Property<int>("ListingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Platforms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("ListingTypeId");

                    b.HasIndex("RoleId");

                    b.HasIndex("SectorId");

                    b.ToTable("ListingTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ModuleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModuleId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.PaymentMethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PaymentMethodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentMethodId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.PlanType", b =>
                {
                    b.Property<int>("PlanTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("PlanTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlanTypeId");

                    b.HasIndex("ModuleId");

                    b.ToTable("PlanTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("ChargeId")
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int?>("FrequencyId")
                        .HasColumnType("int");

                    b.Property<double>("MaximumListing")
                        .HasColumnType("float");

                    b.Property<int?>("PlanTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.Property<double>("SetupFee")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("ChargeId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("FrequencyId");

                    b.HasIndex("PlanTypeId");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("SectorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductCategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.HasIndex("SectorId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SectorName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectorId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Charge", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Currency", "Currency")
                        .WithMany("Charges")
                        .HasForeignKey("CurrencyId");

                    b.HasOne("RespayMLS.Core.Models.Frequency", "Frequency")
                        .WithMany("Charges")
                        .HasForeignKey("FrequencyId");

                    b.Navigation("Currency");

                    b.Navigation("Frequency");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemFeature", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany("ItemFeatures")
                        .HasForeignKey("SectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemSubFeature", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany("ItemSubFeatures")
                        .HasForeignKey("SectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ItemType", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany("ItemTypes")
                        .HasForeignKey("SectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ListingType", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Role", "Role")
                        .WithMany("ListingTypes")
                        .HasForeignKey("RoleId");

                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany("ListingTypes")
                        .HasForeignKey("SectorId");

                    b.Navigation("Role");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.PlanType", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Module", "Module")
                        .WithMany("PlanTypes")
                        .HasForeignKey("ModuleId");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Product", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Charge", null)
                        .WithMany("Products")
                        .HasForeignKey("ChargeId");

                    b.HasOne("RespayMLS.Core.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("RespayMLS.Core.Models.Frequency", "Frequency")
                        .WithMany()
                        .HasForeignKey("FrequencyId");

                    b.HasOne("RespayMLS.Core.Models.PlanType", "PlanType")
                        .WithMany()
                        .HasForeignKey("PlanTypeId");

                    b.HasOne("RespayMLS.Core.Models.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId");

                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.Navigation("Currency");

                    b.Navigation("Frequency");

                    b.Navigation("PlanType");

                    b.Navigation("ProductCategory");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Role", b =>
                {
                    b.HasOne("RespayMLS.Core.Models.Sector", "Sector")
                        .WithMany("Roles")
                        .HasForeignKey("SectorId");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Charge", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Currency", b =>
                {
                    b.Navigation("Charges");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Frequency", b =>
                {
                    b.Navigation("Charges");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Module", b =>
                {
                    b.Navigation("PlanTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Role", b =>
                {
                    b.Navigation("ListingTypes");
                });

            modelBuilder.Entity("RespayMLS.Core.Models.Sector", b =>
                {
                    b.Navigation("ItemFeatures");

                    b.Navigation("ItemSubFeatures");

                    b.Navigation("ItemTypes");

                    b.Navigation("ListingTypes");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}

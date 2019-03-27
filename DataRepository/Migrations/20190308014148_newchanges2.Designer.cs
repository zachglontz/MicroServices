﻿// <auto-generated />
using System;
using DataRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataRepository.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20190308014148_newchanges2")]
    partial class newchanges2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataRepository.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("EmailId")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("PhoneNumber")
                        .HasColumnName("Phone")
                        .HasMaxLength(10);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CustomerId");

                    b.HasAlternateKey("EmailId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DataRepository.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("GetUtcDate()");

                    b.Property<double>("MaxCoverage");

                    b.Property<double>("PricePerMonth");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("QuoteId");

                    b.HasIndex("CustomerId", "StartDate");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("DataRepository.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Model");

                    b.Property<string>("VehicleNumber");

                    b.Property<int?>("VehicleTypeId");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DataRepository.VehicleQuote", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("QuoteId");

                    b.HasKey("VehicleId", "QuoteId");

                    b.HasIndex("QuoteId");

                    b.ToTable("VehicleQuote");
                });

            modelBuilder.Entity("DataRepository.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId");

                    b.Property<string>("VehicleTypeName");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new { VehicleTypeId = 1, VehicleTypeName = "SUV" },
                        new { VehicleTypeId = 2, VehicleTypeName = "Sedan" },
                        new { VehicleTypeId = 3, VehicleTypeName = "Truck" },
                        new { VehicleTypeId = 4, VehicleTypeName = "EV" }
                    );
                });

            modelBuilder.Entity("DataRepository.Quote", b =>
                {
                    b.HasOne("DataRepository.Customer", "Customer")
                        .WithMany("Quotes")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Customer_Quotes")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataRepository.Vehicle", b =>
                {
                    b.HasOne("DataRepository.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DataRepository.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId");
                });

            modelBuilder.Entity("DataRepository.VehicleQuote", b =>
                {
                    b.HasOne("DataRepository.Quote", "Quote")
                        .WithMany("VehicleQuotes")
                        .HasForeignKey("QuoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataRepository.Vehicle", "Vehicle")
                        .WithMany("VehicleQuotes")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
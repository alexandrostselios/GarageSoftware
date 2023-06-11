﻿// <auto-generated />
using System;
using GarageAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageAPI.Migrations
{
    [DbContext(typeof(GarageAPIDbContext))]
    partial class GarageAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GarageAPI.Models.CarEngineTypes.CarEngineType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarEngineType");
                });

            modelBuilder.Entity("GarageAPI.Models.CarManufacturers.CarManufacturer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarManufacturer");
                });

            modelBuilder.Entity("GarageAPI.Models.CarModelManufacturerYear", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("CarManufacturerID")
                        .HasColumnType("bigint");

                    b.Property<long>("CarModelID")
                        .HasColumnType("bigint");

                    b.Property<long>("CarModelYearID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("CarManufacturerID");

                    b.HasIndex("CarModelID");

                    b.HasIndex("CarModelYearID");

                    b.ToTable("CarModelManufacturerYear");
                });

            modelBuilder.Entity("GarageAPI.Models.CarModelYears.CarModelYear", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarModelYear");
                });

            modelBuilder.Entity("GarageAPI.Models.CarModels.CarModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("GarageAPI.Models.EngineerSpeciality.EngineerSpeciality", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EngineerSpeciality");
                });

            modelBuilder.Entity("GarageAPI.Models.ServiceHistoryDTO", b =>
                {
                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("ServiceKilometer")
                        .HasColumnType("bigint");

                    b.Property<float?>("StartPrice")
                        .HasColumnType("real");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserModelsID")
                        .HasColumnType("bigint");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ServiceHistoryDTO");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.ServiceHistory", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("DiscountPercentage")
                        .HasColumnType("real");

                    b.Property<float?>("DiscountPrice")
                        .HasColumnType("real");

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<float>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<DateTime?>("FinishingDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<long>("ServiceKilometer")
                        .HasColumnType("bigint");

                    b.Property<float>("StartPrice")
                        .HasColumnType("real");

                    b.Property<DateTime?>("StartingDate")
                        .HasColumnType("datetime");

                    b.Property<long>("UserModelsID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("EngineerID");

                    b.HasIndex("UserModelsID");

                    b.ToTable("ServiceHistory");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.UserModels", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("Color")
                        .HasColumnType("bigint");

                    b.Property<long>("EngineTypeID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Kilometer")
                        .HasColumnType("bigint");

                    b.Property<string>("LicencePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ModelManufacturerYearID")
                        .HasColumnType("bigint");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<string>("VIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EngineTypeID");

                    b.HasIndex("ModelManufacturerYearID");

                    b.HasIndex("UserID");

                    b.ToTable("UserModels");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.UserModelsDTO", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<long>("Kilometer")
                        .HasColumnType("bigint");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Output");
                });

            modelBuilder.Entity("GarageAPI.Models.Users", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnableAccess")
                        .HasColumnType("int");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Speciality")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GarageAPI.Models.CarModelManufacturerYear", b =>
                {
                    b.HasOne("GarageAPI.Models.CarManufacturers.CarManufacturer", "CarManufacturer")
                        .WithMany()
                        .HasForeignKey("CarManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.CarModels.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.CarModelYears.CarModelYear", "CarModelYear")
                        .WithMany()
                        .HasForeignKey("CarModelYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarManufacturer");

                    b.Navigation("CarModel");

                    b.Navigation("CarModelYear");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.ServiceHistory", b =>
                {
                    b.HasOne("GarageAPI.Models.Users", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.UserModels.UserModels", "UserModels")
                        .WithMany()
                        .HasForeignKey("UserModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.UserModels", b =>
                {
                    b.HasOne("GarageAPI.Models.CarEngineTypes.CarEngineType", "EngineType")
                        .WithMany()
                        .HasForeignKey("EngineTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.CarModelManufacturerYear", "ModelManufacturerYear")
                        .WithMany()
                        .HasForeignKey("ModelManufacturerYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EngineType");

                    b.Navigation("ModelManufacturerYear");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

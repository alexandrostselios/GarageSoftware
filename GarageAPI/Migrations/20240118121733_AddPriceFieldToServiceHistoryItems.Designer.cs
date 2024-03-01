﻿// <auto-generated />
using System;
using GarageAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GarageAPI.Migrations
{
    [DbContext(typeof(GarageAPIDbContext))]
    [Migration("20240118121733_AddPriceFieldToServiceHistoryItems")]
    partial class AddPriceFieldToServiceHistoryItems
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("CarEngineType");
                });

            modelBuilder.Entity("GarageAPI.Models.CarManufacturers.CarManufacturer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

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

                    b.Property<long>("GarageID")
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

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("CarModelYear");
                });

            modelBuilder.Entity("GarageAPI.Models.CarModels.CarModel", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("GarageAPI.Models.Email", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ReceiverID")
                        .HasColumnType("bigint");

                    b.Property<long>("SenderID")
                        .HasColumnType("bigint");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("GarageAPI.Models.EngineerSpeciality.EngineerSpeciality", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EngineerSpeciality");
                });

            modelBuilder.Entity("GarageAPI.Models.GarageDetails", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("GarageDetails");
                });

            modelBuilder.Entity("GarageAPI.Models.Report", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistory", b =>
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

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

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

                    b.Property<bool>("isDiscountPercentage")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("EngineerID");

                    b.HasIndex("UserModelsID");

                    b.ToTable("ServiceHistory");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryDTO", b =>
                {
                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<long>("ID")
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

                    b.Property<bool>("isDiscountPercentage")
                        .HasColumnType("bit");

                    b.ToTable("ServiceHistoryDTO");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryItems", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SHID")
                        .HasColumnType("bigint");

                    b.Property<long>("SIID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("GarageID");

                    b.HasIndex("SHID");

                    b.HasIndex("SIID");

                    b.ToTable("ServiceHistoryItems");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryItemsDTO", b =>
                {
                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<long>("ID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("SHID")
                        .HasColumnType("bigint");

                    b.Property<long>("SIID")
                        .HasColumnType("bigint");

                    b.ToTable("ServiceHistoryItemsDTO");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryWithItemsDTO", b =>
                {
                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("DiscountPercentage")
                        .HasColumnType("real");

                    b.Property<float?>("DiscountPrice")
                        .HasColumnType("real");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<long>("ID")
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ServiceItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ServiceItemID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("ServiceItemPrice")
                        .HasColumnType("decimal(18,2)");

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

                    b.Property<bool>("isDiscountPercentage")
                        .HasColumnType("bit");

                    b.ToTable("ServiceHistoryWithItemsDTO");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceItems", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("ServiceItems");
                });

            modelBuilder.Entity("GarageAPI.Models.Settings", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("InsertDate")
                        .HasColumnType("datetime");

                    b.Property<long>("InsertUserID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("InsertUserID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("GarageAPI.Models.User.Users", b =>
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

            modelBuilder.Entity("GarageAPI.Models.User.UsersDTO", b =>
                {
                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnableAccess")
                        .HasColumnType("int");

                    b.Property<string>("EngineerSpeciality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

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

                    b.ToTable("UsersDTO");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.UserModel", b =>
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

                    b.Property<long>("GarageID")
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

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistory", b =>
                {
                    b.HasOne("GarageAPI.Models.User.Users", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.UserModels.UserModel", "UserModels")
                        .WithMany()
                        .HasForeignKey("UserModelsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engineer");

                    b.Navigation("UserModels");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryItems", b =>
                {
                    b.HasOne("GarageAPI.Models.GarageDetails", "GarageDetails")
                        .WithMany()
                        .HasForeignKey("GarageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.Service.ServiceHistory", "ServiceHistory")
                        .WithMany()
                        .HasForeignKey("SHID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.Service.ServiceItems", "ServiceItems")
                        .WithMany()
                        .HasForeignKey("SIID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GarageDetails");

                    b.Navigation("ServiceHistory");

                    b.Navigation("ServiceItems");
                });

            modelBuilder.Entity("GarageAPI.Models.Settings", b =>
                {
                    b.HasOne("GarageAPI.Models.User.Users", "InsertUser")
                        .WithMany()
                        .HasForeignKey("InsertUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsertUser");
                });

            modelBuilder.Entity("GarageAPI.Models.UserModels.UserModel", b =>
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

                    b.HasOne("GarageAPI.Models.User.Users", "User")
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

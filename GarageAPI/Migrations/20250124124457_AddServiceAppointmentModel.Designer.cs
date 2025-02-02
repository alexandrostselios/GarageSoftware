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
    [Migration("20250124124457_AddServiceAppointmentModel")]
    partial class AddServiceAppointmentModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GarageAPI.Models.CarEngineTypes.CarFuelType", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("CarFuelType");
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

            modelBuilder.Entity("GarageAPI.Models.CustomerCars.CustomerCar", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("Color")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerID")
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

                    b.Property<string>("VIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EngineTypeID");

                    b.HasIndex("ModelManufacturerYearID");

                    b.ToTable("CustomerCars");
                });

            modelBuilder.Entity("GarageAPI.Models.CustomerCars.CustomerCarDTO", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<string>("FuelType")
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

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("CustomerCarDTO");
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
                        .HasColumnType("datetime");

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

            modelBuilder.Entity("GarageAPI.Models.EngineerSpecialities.EngineerSpecialities", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<long>("SpecialityID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("EngineerSpecialities");
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

                    b.Property<long>("CustomerCarID")
                        .HasColumnType("bigint");

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

                    b.Property<long?>("NotifyDays")
                        .HasColumnType("bigint");

                    b.Property<bool?>("NotifyNextService")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<long>("ServiceKilometer")
                        .HasColumnType("bigint");

                    b.Property<float>("StartPrice")
                        .HasColumnType("real");

                    b.Property<DateTime?>("StartingDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("isDiscountPercentage")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CustomerCarID");

                    b.HasIndex("EngineerID");

                    b.ToTable("ServiceHistory");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistoryDTO", b =>
                {
                    b.Property<byte[]>("CarImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<long>("Color")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerCarID")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<long>("ID")
                        .HasColumnType("bigint");

                    b.Property<long?>("Kilometer")
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

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("ServiceKilometer")
                        .HasColumnType("bigint");

                    b.Property<float?>("StartPrice")
                        .HasColumnType("real");

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

                    b.Property<long>("CustomerCarID")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("DiscountPercentage")
                        .HasColumnType("real");

                    b.Property<float?>("DiscountPrice")
                        .HasColumnType("real");

                    b.Property<long>("EngineerID")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("FinalPrice")
                        .HasColumnType("real");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("GarageAPI.Models.ServiceAppointment.ServiceAppointment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"));

                    b.Property<long>("CustomerCarID")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<string>("ServiceAppointmentComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ServiceAppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("ServiceAppointmentTime")
                        .HasColumnType("time");

                    b.HasKey("ID");

                    b.ToTable("ServiceAppointment");
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

            modelBuilder.Entity("GarageAPI.Models.User.Customers.Customer", b =>
                {
                    b.Property<long>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CustomerID"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CustomerComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerHomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerMobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CustomerPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("GarageAPI.Models.User.Employees.Employee", b =>
                {
                    b.Property<long>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EmployeeID"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeHomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeMobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EmployeePhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("GarageAPI.Models.User.Engineer.Engineer", b =>
                {
                    b.Property<long>("EngineerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EngineerID"));

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EngineerComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerHomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerMobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("EngineerPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EngineerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GarageID")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("EngineerID");

                    b.ToTable("Engineer");
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

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("GarageAPI.Models.CustomerCars.CustomerCar", b =>
                {
                    b.HasOne("GarageAPI.Models.User.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.CarEngineTypes.CarFuelType", "EngineType")
                        .WithMany()
                        .HasForeignKey("EngineTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.CarModelManufacturerYear", "ModelManufacturerYear")
                        .WithMany()
                        .HasForeignKey("ModelManufacturerYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("EngineType");

                    b.Navigation("ModelManufacturerYear");
                });

            modelBuilder.Entity("GarageAPI.Models.Service.ServiceHistory", b =>
                {
                    b.HasOne("GarageAPI.Models.CustomerCars.CustomerCar", "CustomerCar")
                        .WithMany()
                        .HasForeignKey("CustomerCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GarageAPI.Models.User.Users", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerCar");

                    b.Navigation("Engineer");
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
#pragma warning restore 612, 618
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using GarageAPI.Models;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarModelYears;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace GarageAPI.Data
{
    public class GarageAPIDbContext: DbContext
    {
        public GarageAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //initDatabase(builder);

            base.OnModelCreating(builder);
        }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarManufacturer> CarManufacturer { get; set; }
        public DbSet<CarModelYear> CarModelYear { get; set; }
        public DbSet<CarModelManufacturerYear> CarModelManufacturerYear { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserModels> UserModels { get; set; }
        public DbSet<CustomerCars> CustomerCars { get; set; }
        public DbSet<Output> Output { get; set; }

        private void initDatabase(ModelBuilder builder)
        {
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 1, ManufacturerName = "Abarth" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 2, ManufacturerName = "Alfa Romeo" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 3, ManufacturerName = "Aston Martin" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 4, ManufacturerName = "Audi" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 5, ManufacturerName = "Bentley" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 6, ManufacturerName = "BMW" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 7, ManufacturerName = "Bugatti" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 8, ManufacturerName = "Cadillac" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 9, ManufacturerName = "Chevrolet" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 10, ManufacturerName = "Chrysler" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 11, ManufacturerName = "Citroën" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 12, ManufacturerName = "Dacia" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 13, ManufacturerName = "Daewoo" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 14, ManufacturerName = "Daihatsu" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 15, ManufacturerName = "Dodge" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 16, ManufacturerName = "Donkervoort" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 17, ManufacturerName = "DS" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 18, ManufacturerName = "Ferrari" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 19, ManufacturerName = "Fiat" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 20, ManufacturerName = "Fisker" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 21, ManufacturerName = "Ford" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 22, ManufacturerName = "Honda" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 23, ManufacturerName = "Hummer" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 24, ManufacturerName = "Hyundai" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 25, ManufacturerName = "Infiniti" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 26, ManufacturerName = "Iveco" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 27, ManufacturerName = "Jaguar" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 28, ManufacturerName = "Jeep" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 29, ManufacturerName = "Kia" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 30, ManufacturerName = "KTM" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 31, ManufacturerName = "Lada" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 32, ManufacturerName = "Lamborghini" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 33, ManufacturerName = "Lancia" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 34, ManufacturerName = "Land Rover" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 35, ManufacturerName = "Landwind" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 36, ManufacturerName = "Lexus" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 37, ManufacturerName = "Lotus" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 38, ManufacturerName = "Maserati" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 39, ManufacturerName = "Maybach" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 40, ManufacturerName = "Mazda" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 41, ManufacturerName = "McLaren" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 42, ManufacturerName = "Mercedes-Benz" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 43, ManufacturerName = "MG" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 44, ManufacturerName = "Mini" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 45, ManufacturerName = "Mitsubishi" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 46, ManufacturerName = "Morgan" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 47, ManufacturerName = "Nissan" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 48, ManufacturerName = "Opel" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 49, ManufacturerName = "Peugeot" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 50, ManufacturerName = "Porsche" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 51, ManufacturerName = "Renault" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 52, ManufacturerName = "Rolls-Royce" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 53, ManufacturerName = "Rover" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 54, ManufacturerName = "Saab" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 55, ManufacturerName = "Seat" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 56, ManufacturerName = "Skoda" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 57, ManufacturerName = "Smart" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 58, ManufacturerName = "SsangYong" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 59, ManufacturerName = "Subaru" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 60, ManufacturerName = "Suzuki" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 61, ManufacturerName = "Tesla" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 62, ManufacturerName = "Toyota" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 63, ManufacturerName = "Volkswagen" });
            builder.Entity<CarManufacturer>().HasData(new CarManufacturer { ID = 64, ManufacturerName = "Volvo" });


            builder.Entity<CarModel>().HasData(new CarModel { ID = 1, ModelName = "Accent" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 2, ModelName = "Atos" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 3, ModelName = "Prime" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 4, ModelName = "Coupé" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 5, ModelName = "Elantra" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 6, ModelName = "Galloper" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 7, ModelName = "Genesis" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 8, ModelName = "Getz" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 9, ModelName = "Grandeur" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 10, ModelName = "H350" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 11, ModelName = "H1" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 12, ModelName = "H1Bus" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 13, ModelName = "H1Van" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 14, ModelName = "H200" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 15, ModelName = "i10" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 16, ModelName = "i20" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 17, ModelName = "i30" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 18, ModelName = "i30 CW" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 19, ModelName = "i40" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 20, ModelName = "i40 CW" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 21, ModelName = "ix20" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 22, ModelName = "ix35" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 23, ModelName = "ix55" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 24, ModelName = "Lantra" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 25, ModelName = "Matrix" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 26, ModelName = "SantaFe" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 27, ModelName = "Sonata" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 28, ModelName = "Terracan" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 29, ModelName = "Trajet" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 30, ModelName = "Tucson" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 31, ModelName = "Veloster" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 32, ModelName = "Kona" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 33, ModelName = "Tucson" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 34, ModelName = "Bayon" });


            builder.Entity<CarModel>().HasData(new CarModel { ID = 35, ModelName = "145" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 36, ModelName = "146" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 37, ModelName = "147" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 38, ModelName = "155" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 39, ModelName = "156" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 40, ModelName = "156 Sportwagon" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 41, ModelName = "159" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 42, ModelName = "159 Sportwagon" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 43, ModelName = "164" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 44, ModelName = "166" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 45, ModelName = "4C" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 46, ModelName = "Brera" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 47, ModelName = "GTV" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 48, ModelName = "MiTo" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 49, ModelName = "Crosswagon" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 50, ModelName = "Spider" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 51, ModelName = "GT" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 52, ModelName = "Giulietta" });
            builder.Entity<CarModel>().HasData(new CarModel { ID = 53, ModelName = "Giulia" });

            int k = 1;
            for(int i= 1950; i <= DateTime.Now.Year; i++){
                builder.Entity<CarModelYear>().HasData(new CarModelYear { ID = k, Description = i.ToString() });
                k++;
            }

            builder.Entity<Users>().HasData(new Users { ID = 1, Name = "Alexandros", Surname = "Tselios", Email = "atselios@classter.com", Password = "1", UserType = 1, CreationDate = DateTime.Now, ModifiedDate = null, LastLoginDate = null, EnableAccess = Enum.EnableAccess.Enable });
            builder.Entity<Users>().HasData(new Users { ID = 2, Name = "Efthumia", Surname = "Varvagianni", Email = "efi.vanni@gmail.com", Password = "f1234!", UserType = 1, CreationDate = DateTime.Now, ModifiedDate = null, LastLoginDate = null, EnableAccess = Enum.EnableAccess.Enable });
            builder.Entity<Users>().HasData(new Users { ID = 3, Name = "Kostas", Surname = "Kitsikou", Email = "kkitsikou@hotmail.com", Password = "gafa#$#", UserType = 1, CreationDate = DateTime.Now, ModifiedDate = null, LastLoginDate = null, EnableAccess = Enum.EnableAccess.Enable });
            builder.Entity<Users>().HasData(new Users { ID = 4, Name = "Marios", Surname = "Papadopoulos", Email = "mpapadopoulos@yahoo.gr", Password = "DfG34#$%^", UserType = 1, CreationDate = DateTime.Now, ModifiedDate = null, LastLoginDate = null, EnableAccess = Enum.EnableAccess.Enable });
        }


    }
}
using Microsoft.EntityFrameworkCore;
using GarageAPI.Models;
using GarageAPI.Models.CarManufacturers;
using GarageAPI.Models.CarModels;
using GarageAPI.Models.CarModelYears;
using GarageAPI.Models.CarModelManufacturerYears;

namespace GarageAPI.Data
{
    public class GarageAPIDbContext: DbContext
    {
        public GarageAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarManufacturer> CarManufacturer { get; set; }
        public DbSet<CarModelYear> CarModelYear { get; set; }
        public DbSet<CarModelManufacturerYear> CarModelManufacturerYear { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserModels> UserModels { get; set; }

        public virtual DbSet<CarModelManufacturerYearDTO> CarModelManufacturerYearDTO { get; set; }

    }
}


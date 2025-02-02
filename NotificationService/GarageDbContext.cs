using GarageNotificationService.Models.CarModels;
using GarageNotificationService.Models.Service;
using Microsoft.EntityFrameworkCore;

namespace GarageNotificationService.Data
{
    public class GarageDbContext : DbContext
    {

        public GarageDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CarModel> CarModels { get; set; }

        public DbSet<ServiceHistory> ServiceHistory { get; set; }

        public DbSet<ServiceAppointment> ServiceAppointment { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using GarageManagementSoftwarePortal.Models;using Microsoft.AspNetCore.Http;

namespace GarageManagementSoftwarePortal.Data
{
    public class GarageManagementSoftwarePortalContext : DbContext
    {
        public GarageManagementSoftwarePortalContext (DbContextOptions<GarageManagementSoftwarePortalContext> options)
            : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Followers> Followers { get; set; }
        public DbSet<GarageManagementSoftwarePortal.Models.UserModels> UserModels { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using MBSCHospitalApp.Models.Entities;

namespace MBSCHospitalApp.Models 
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set;}
    }
}
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class JobTrackerDBContext : DbContext
    {
        public JobTrackerDBContext(DbContextOptions<JobTrackerDBContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Application> Applications => Set<Application>();
    }
}

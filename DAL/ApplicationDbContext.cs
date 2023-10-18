using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }
        // public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=DESKTOP-KNA89UR\\SQLEXPRESS;Initial Catalog=DecProg;Persist Security Info=True;User ID = sa;Password= 123;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
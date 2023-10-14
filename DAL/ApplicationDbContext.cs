using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        //public ApplicationDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MvcMovie.Data;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
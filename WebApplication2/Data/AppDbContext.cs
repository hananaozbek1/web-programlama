
using HealthyLife.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace HealthyLife.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

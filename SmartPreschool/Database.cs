using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static SmartPreschool.Models;

namespace SmartPreschool
{
    internal class Database
    {
        public class AppDbContext : DbContext
        {
            private string connectionString;

            public AppDbContext(string connectionString)
            {
                this.connectionString = connectionString;
            }

            public DbSet<Child> Children { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<Attendance> Attendance { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite(this.connectionString);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Group>()
                    .HasIndex(g => g.Name)
                    .IsUnique();
            }
        }
    }
}

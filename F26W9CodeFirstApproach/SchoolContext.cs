using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace F26W9CodeFirstApproach
{
    public class SchoolContext : DbContext
    {
        // entity sets - REQUIRED
        // define DbSet<> properties
        public DbSet<Standard> Standards { get; set; }
        public DbSet<Student> Students { get; set; }


        // define connection string - REQUIRED
        // override OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SchoolCF"].ConnectionString;
            optionsBuilder.UseSqlServer(connStr);
        }


        // data seeding - OPTIONAL
        // override OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Standard>().HasData(
                new Standard { StandardId = 1, StandardName = "Standard 1" },
                new Standard { StandardId = 2, StandardName = "Standard 2" },
                new Standard { StandardId = 3, StandardName = "Standard 3" },
                new Standard { StandardId = 4, StandardName = "Standard 4" },
                new Standard { StandardId = 5, StandardName = "Standard 5" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "John", StandardId = 1 },
                new Student { StudentId = 2, StudentName = "Anne", StandardId = 1 },
                new Student { StudentId = 3, StudentName = "Mark", StandardId = 2 },
                new Student { StudentId = 4, StudentName = "Lucy", StandardId = 3 }
            );
        }
    }
}

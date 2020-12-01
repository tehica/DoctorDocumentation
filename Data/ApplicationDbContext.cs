using System;
using System.Collections.Generic;
using System.Text;
using DoctorDoc1.Extensions.Seeders;
using DoctorDoc1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorDoc1.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Doctor_Specialization> Doctor_Specialization { get; set; }
        public DbSet<Doctor_Qualification> Doctor_Qualification { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Doctor_Specialization>()
                        .HasKey(key => new
                        {
                            key.SpecializationId,
                            key.DoctorId
                        });

            modelBuilder.Entity<Doctor_Qualification>()
                        .HasKey(key => new
                        {
                            key.DoctorId,
                            key.QualificationId
                        });

            // seed data
            modelBuilder.Seed();
        }
    }
}

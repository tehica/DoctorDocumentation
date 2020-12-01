using DoctorDoc1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Extensions.Seeders
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>().HasData(
                new Specialization
                {
                    Id = 1,
                    Name = "Specialization1"
                },
                new Specialization
                {
                    Id = 2,
                    Name = "Specialization2"
                });

            modelBuilder.Entity<Doctor_Specialization>().HasData(
                new Doctor_Specialization
                {
                    SpecializationId = 1,
                    DoctorId = 1,
                    AcquiredAt = DateTime.Now.ToShortDateString()
                },
                new Doctor_Specialization
                {
                    SpecializationId = 2,
                    DoctorId = 2,
                    AcquiredAt = DateTime.Now.ToShortDateString()
                });

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Toni",
                    LastName = "Musa",
                    Gender = "Male",
                    PhoneNumber = "0955335829",
                    Email = "tehica97@gmail.com",
                    HospitalId = 1
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Marko",
                    LastName = "Marić",
                    Gender = "Male",
                    PhoneNumber = "0927549283",
                    Email = "marko.maric1@gmail.com",
                    HospitalId = 2
                });

            modelBuilder.Entity<Qualification>().HasData(
                new Qualification
                {
                    Id = 1,
                    Name = "Qualification1",
                    InstituteName = "VVG"
                },
                new Qualification
                {
                    Id = 2,
                    Name = "Qualification2",
                    InstituteName = "TVZ"
                },
                new Qualification
                {
                    Id = 3,
                    Name = "Qualification3",
                    InstituteName = "FER"
                });

            modelBuilder.Entity<Hospital>().HasData(
                new Hospital
                {
                    Id = 1,
                    Name = "Bolnica1",
                    CityId = 2
                },
                new Hospital
                {
                    Id = 2,
                    Name = "Bolnica2",
                    CityId = 2
                },
                new Hospital
                {
                    Id = 3,
                    Name = "Bolnica3",
                    CityId = 2
                });

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Zagreb",
                    ZipCode = "10000"
                },
                new City
                {
                    Id = 2,
                    Name = "Rijeka",
                    ZipCode = "51000"
                },
                new City
                {
                    Id = 3,
                    Name = "Osijek",
                    ZipCode = "63274"
                });

        }
    }
}

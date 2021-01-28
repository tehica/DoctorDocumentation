using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Services
{
    // ne koristim više
    public class HospitalRepository : GenericRepository<Hospital>, IHospitalRepository
    {
        private readonly ApplicationDbContext _db;

        public HospitalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public async Task<Hospital> GetHospitalWithCity(int id)
        {
            var hospitalWithCity = await _db.Hospital.Include(c => c.City)
                                                     .FirstOrDefaultAsync(h => h.Id == id);
            return hospitalWithCity;
        }

        // GET CREATE
        public async Task<IEnumerable<City>> GetListOfCities()
        {
            var getCitiesFromDb = await _db.City.ToListAsync();
            return getCitiesFromDb;
        }

        // POST CREATE
        public async Task<ActionResult<HospitalAndCityViewModel>> CreateHospital(HospitalAndCityViewModel model)
        {
            _db.Hospital.Add(model.Hospital);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<ActionResult<HospitalAndCityViewModel>> UpdateHospital(HospitalAndCityViewModel model)
        {
            _db.Hospital.Update(model.Hospital);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}

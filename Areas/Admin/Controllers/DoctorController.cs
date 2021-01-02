using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly ApplicationDbContext _db;

        //private readonly ApplicationDbContext _db;
        //public DoctorController(ApplicationDbContext db)
        //{
        //    _db = db;
        //}

        public DoctorController(IDoctorRepository doctorRepository, ApplicationDbContext db)
        {
            _doctorRepository = doctorRepository;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> Index()
        {
            //var docFromDb = await _doctorRepository.ListAllAsync();
            //return View(docFromDb);
            var doctorListFromDb = await _db.Doctor.ToListAsync();
            return View(doctorListFromDb);
        }


        [HttpGet]
        public async Task<ActionResult<Doctor>> Details(int id)
        {
            var DoctorWithHospitalAndCity = await _db.Doctor.Include(h => h.Hospital)
                                                            .FirstOrDefaultAsync(d => d.Id == id);
            return View(DoctorWithHospitalAndCity);
        }

        [HttpGet]
        public async Task<ActionResult<DoctorAndHospitalViewModel>> Create()
        {
            DoctorAndHospitalViewModel model = new DoctorAndHospitalViewModel()
            {
                Doctor = new Doctor(),
                HospitalList = await _db.Hospital.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAndHospitalViewModel model)
        {
            if (ModelState.IsValid)
            {
                _db.Doctor.Add(model.Doctor);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult<Doctor>> Edit(int id)
        {
            DoctorAndHospitalViewModel model = new DoctorAndHospitalViewModel
            {
                Doctor = await _db.Doctor.FindAsync(id),
                HospitalList = await _db.Hospital.ToListAsync()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorAndHospitalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _db.Doctor.Update(model.Doctor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var doctorFromDb = await _db.Doctor.FindAsync(id);
            _db.Doctor.Remove(doctorFromDb);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

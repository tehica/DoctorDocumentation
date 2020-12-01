using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.Data;
using DoctorDoc1.Models;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QualificationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QualificationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualification>>> Index()
        {
            IEnumerable<Qualification> getQualificationsFromDb = await _db.Qualification.ToListAsync();

            return View(getQualificationsFromDb);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                _db.Qualification.Add(qualification);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(qualification);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            // dohvati doktore koji pripadaju toj kvalifikaciji
            List<Doctor_Qualification> doctors = await _db
                                         .Doctor_Qualification
                                         .Include(item => item.Doctor)
                                         .Where(ss => ss.QualificationId == id)
                                         .ToListAsync();
            if (doctors == null)
                return NotFound();

            Qualification qualification = await _db.Qualification.FirstOrDefaultAsync(s => s.Id == id);
            if (qualification == null)
                return NotFound();

            QualificationDetailsViewModel QualificationVM = new QualificationDetailsViewModel
            {
                Qualification = qualification,
                Doctors = doctors
            };

            return View(QualificationVM);
        }

        [HttpGet]
        public async Task<ActionResult<Qualification>> Edit(int id)
        {
            var qualification = await _db.Qualification.FindAsync(id);
            return View(qualification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<City>> Edit(Qualification model)
        {
            if (ModelState.IsValid)
            {
                _db.Qualification.Update(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var qualification = await _db.Qualification.FindAsync(id);

            _db.Qualification.Remove(qualification);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> AddDoctorToQualification(int id)
        {
            Qualification qualification = await _db.Qualification.FirstOrDefaultAsync(s => s.Id == id);
            List<Doctor> doctors = await _db.Doctor.ToListAsync();
            return View(new AddDoctorToQualificationViewModel(qualification, doctors));
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorToQualification(AddDoctorToQualificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctorID = model.DoctorId;
                var qualificationID = model.QualificationId;

                IList<Doctor_Qualification> existingDoctors = await _db.Doctor_Qualification
                                                               .Where(ss => ss.DoctorId == doctorID)
                                                               .Where(ss => ss.QualificationId == qualificationID)
                                                               .ToListAsync();

                if (existingDoctors.Count == 0)
                {
                    Doctor_Qualification doctor_Qualification = new Doctor_Qualification
                    {
                        Doctor = await _db.Doctor.FirstOrDefaultAsync(s => s.Id == doctorID),
                        Qualification = await _db.Qualification.FirstOrDefaultAsync(s => s.Id == qualificationID),
                        AcquiredAt = DateTime.Now.ToShortDateString()
                    };

                    _db.Doctor_Qualification.Add(doctor_Qualification);
                    await _db.SaveChangesAsync();
                }

                return Redirect(string.Format("/Qualification/Details/{0}", model.QualificationId));
            }

            return View(model);
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.Data;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using DoctorDoc1.Specifications;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Doctor>>> Index()
        {
            //var doctorListFromDb = await _db.Doctor.ToListAsync();
            var spec = new DoctorWithHospitalSpecification();
            var doctors = await _unitOfWork.Repository<Doctor>().ListAsync(spec);
            return View(doctors);
        }


        [HttpGet]
        public async Task<ActionResult<Doctor>> Details(int id)
        {
            //var DoctorWithHospitalAndCity = await _db.Doctor.Include(h => h.Hospital)
            //                                                .FirstOrDefaultAsync(d => d.Id == id);
            var spec = new DoctorWithHospitalSpecification(id);
            var doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithSpec(spec);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpGet]
        public async Task<ActionResult<DoctorAndHospitalViewModel>> Create()
        {
            DoctorAndHospitalViewModel model = new DoctorAndHospitalViewModel()
            {
                Doctor = new Doctor(),
                HospitalList = await _unitOfWork.Repository<Hospital>().ListAllAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAndHospitalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // refresh input elements
                return View(model);
            }
            await _unitOfWork.Repository<Doctor>().CreateAsync(model.Doctor);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult<Doctor>> Edit(int id)
        {
            var spec = new DoctorWithHospitalSpecification(id);
            DoctorAndHospitalViewModel model = new DoctorAndHospitalViewModel
            {
                Doctor = await _unitOfWork.Repository<Doctor>().GetEntityWithSpec(spec),
                HospitalList = await _unitOfWork.Repository<Hospital>().ListAllAsync()
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
            await _unitOfWork.Repository<Doctor>().UpdateAsync(model.Doctor);
            //                SaveAsync
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var doctorFromDb = await _db.Doctor.FindAsync(id);
            //_db.Doctor.Remove(doctorFromDb);
            //await _db.SaveChangesAsync();
            var doctor = await _unitOfWork.Repository<Doctor>().GetByIdAsync(id);
            await _unitOfWork.Repository<Doctor>().DeleteAsync(doctor);
            return RedirectToAction(nameof(Index));
        }
    }
}

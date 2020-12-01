using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.Data;
using DoctorDoc1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecializationController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialization>>> Index()
        {
            IEnumerable<Specialization> getSpecializationsFromDb = await _db.Specialization.ToListAsync();

            return View(getSpecializationsFromDb);
        }

        [HttpGet]
        public async Task<ActionResult<City>> Details(int id)
        {
            var getSpecFromDb = await _db.Specialization.FindAsync(id);
            return View(getSpecFromDb);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Specialization model)
        {
            if (ModelState.IsValid)
            {
                _db.Specialization.Add(model);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult<Specialization>> Edit(int id)
        {
            var spec = await _db.Specialization.FindAsync(id);
            return View(spec);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<City>> Edit(Specialization model)
        {
            if (ModelState.IsValid)
            {
                _db.Specialization.Update(model);
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

            var spec = await _db.Specialization.FindAsync(id);

            _db.Specialization.Remove(spec);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}

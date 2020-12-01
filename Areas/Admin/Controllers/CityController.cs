using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Index()
        {
            var getAllCities = await _cityRepository.ListAllAsync();
            return View(getAllCities);
        }

        [HttpGet]
        public async Task<ActionResult<City>> Details(int id)
        {
            var getCityFromDb = await _cityRepository.GetByIdAsync(id);
            return View(getCityFromDb);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City model)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<ActionResult<City>> Edit(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<City>> Edit(City model)
        {
            if (ModelState.IsValid)
            {
                await _cityRepository.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            await _cityRepository.DeleteAsync(city);

            return RedirectToAction(nameof(Index));
        }
    }
}

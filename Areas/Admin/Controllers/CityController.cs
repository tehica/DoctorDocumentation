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
        //private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;

        // ICityRepository cityRepository,
        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Index()
        {
            var cities = await _unitOfWork.Repository<City>().ListAllAsync();
            //var getAllCities = await _cityRepository.ListAllAsync();
            return View(cities);
        }

        [HttpGet]
        public async Task<ActionResult<City>> Details(int id)
        {
            //var getCityFromDb = await _cityRepository.GetByIdAsync(id);
            var getCityById = await _unitOfWork.Repository<City>().GetByIdAsync(id);
            return View(getCityById);
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
                //await _cityRepository.CreateAsync(model);
                await _unitOfWork.Repository<City>().CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult<City>> Edit(int id)
        {
            //var city = await _cityRepository.GetByIdAsync(id);
            var city = await _unitOfWork.Repository<City>().GetByIdAsync(id);
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<City>> Edit(City model)
        {
            if (ModelState.IsValid)
            {
                //await _cityRepository.UpdateAsync(model);
                await _unitOfWork.Repository<City>().UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var city = await _cityRepository.GetByIdAsync(id);
            var city = await _unitOfWork.Repository<City>().GetByIdAsync(id);
            //await _cityRepository.DeleteAsync(city);
            await _unitOfWork.Repository<City>().DeleteAsync(city);
            return RedirectToAction(nameof(Index));
        }
    }
}

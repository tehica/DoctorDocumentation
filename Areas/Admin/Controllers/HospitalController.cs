using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> Index()
        {
            var getHospitalsFromDb = await _hospitalRepository.ListAllAsync();
            return View(getHospitalsFromDb);
        }

        [HttpGet]
        public async Task<ActionResult<Hospital>> Details(int id)
        {
            var getHospitalWithCity = await _hospitalRepository.GetHospitalWithCity(id);
            return View(getHospitalWithCity);
        }

        [HttpGet]
        public async Task<ActionResult<HospitalAndCityViewModel>> Create()
        {
            HospitalAndCityViewModel model = new HospitalAndCityViewModel()
            {
                Hospital = new Hospital(),
                CityList = await _hospitalRepository.GetListOfCities()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<HospitalAndCityViewModel>> Create(HospitalAndCityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _hospitalRepository.CreateHospital(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult<HospitalAndCityViewModel>> Edit(int id)
        {
            HospitalAndCityViewModel model = new HospitalAndCityViewModel
            {
                Hospital = await _hospitalRepository.GetByIdAsync(id),
                CityList = await _hospitalRepository.GetListOfCities()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HospitalAndCityViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _hospitalRepository.UpdateHospital(model);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            await _hospitalRepository.DeleteAsync(hospital);

            return RedirectToAction(nameof(Index));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorDoc1.interfaces;
using DoctorDoc1.Models;
using DoctorDoc1.Specifications;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoctorDoc1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
    {
        //private readonly IHospitalRepository _hospitalRepository;
        private readonly IUnitOfWork _unitOfWork;

        // IHospitalRepository hospitalRepository,
        public HospitalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Hospital>>> Index()
        {
            //var getHospitalsFromDb = await _hospitalRepository.ListAllAsync();
            var spec = new GetHospitalWithCitySpecification();
            var hospitals = await _unitOfWork.Repository<Hospital>().ListAsync(spec);

            return View(hospitals);
        }

        [HttpGet]
        public async Task<ActionResult<Hospital>> Details(int id)
        {
            // var getHospitalWithCity = await _hospitalRepository.GetHospitalWithCity(id);

            var spec = new GetHospitalWithCitySpecification(id);
            var hospital = await _unitOfWork.Repository<Hospital>().GetEntityWithSpec(spec);


            if(hospital == null)
            {
                return NotFound();
            }
            
            return View(hospital);
        }

        [HttpGet]
        public async Task<ActionResult<HospitalAndCityViewModel>> Create()
        {
            HospitalAndCityViewModel model = new HospitalAndCityViewModel()
            {
                Hospital = new Hospital(),
                CityList = await _unitOfWork.Repository<City>().ListAllAsync()
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
            //await _hospitalRepository.CreateHospital(model);

            await _unitOfWork.Repository<Hospital>().CreateAsync(model.Hospital);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult<HospitalAndCityViewModel>> Edit(int id)
        {
            var spec = new GetHospitalWithCitySpecification(id);
            HospitalAndCityViewModel model = new HospitalAndCityViewModel
            {
                Hospital = await _unitOfWork.Repository<Hospital>().GetEntityWithSpec(spec),
                CityList = await _unitOfWork.Repository<City>().ListAllAsync()
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

            //await _hospitalRepository.UpdateHospital(model);
            await _unitOfWork.Repository<Hospital>().UpdateAsync(model.Hospital);
            //                SaveAsync
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //var h = await _hospitalRepository.GetByIdAsync(id);
            // await _hospitalRepository.DeleteAsync(hospital);
            var hospital = await _unitOfWork.Repository<Hospital>().GetByIdAsync(id);
            await _unitOfWork.Repository<Hospital>().DeleteAsync(hospital);
            return RedirectToAction(nameof(Index));
        }
    }
}

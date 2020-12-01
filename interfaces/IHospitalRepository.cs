using DoctorDoc1.Models;
using DoctorDoc1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.interfaces
{
    public interface IHospitalRepository : IGenericRepository<Hospital>
    {
        Task<Hospital> GetHospitalWithCity(int id);

        Task<IEnumerable<City>> GetListOfCities();

        Task<ActionResult<HospitalAndCityViewModel>> CreateHospital(HospitalAndCityViewModel model);

        Task<ActionResult<HospitalAndCityViewModel>> UpdateHospital(HospitalAndCityViewModel model);
    }
}

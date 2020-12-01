using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.ViewModels
{
    public class HospitalAndCityViewModel
    {
        public Hospital Hospital { get; set; }
        public IEnumerable<City> CityList { get; set; }

    }
}

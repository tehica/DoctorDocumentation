using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Specifications
{
    public class GetHospitalWithCitySpecification : BaseSpecification<Hospital>
    {
        public GetHospitalWithCitySpecification()
        {
            AddInclude(city => city.City);
        }

        public GetHospitalWithCitySpecification(int id) : base(h => h.Id == id)
        {
            AddInclude(city => city.City);
        }
    }
}

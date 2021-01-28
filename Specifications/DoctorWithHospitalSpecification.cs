using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Specifications
{
    public class DoctorWithHospitalSpecification : BaseSpecification<Doctor>
    {
        public DoctorWithHospitalSpecification()
        {
            AddInclude(hospital => hospital.Hospital);
        }

        public DoctorWithHospitalSpecification(int id) : base(doctor => doctor.Id == id)
        {
            AddInclude(hospital => hospital.Hospital);
        }
    }
}

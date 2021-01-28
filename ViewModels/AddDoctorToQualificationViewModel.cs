using DoctorDoc1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.ViewModels
{
    public class AddDoctorToQualificationViewModel
    {
        public AddDoctorToQualificationViewModel() { }

        public AddDoctorToQualificationViewModel(Qualification qualification, IEnumerable<Doctor> doctors)
        {
            Doctors = new List<SelectListItem>();

            foreach (var doctor in doctors)
            {
                Doctors.Add(new SelectListItem()
                {
                    Value = doctor.Id.ToString(),
                    Text = doctor.FirstName + " " + doctor.LastName
                });
            }

            Qualification = qualification;
        }

        public Qualification Qualification { get; set; }
        public List<SelectListItem> Doctors { get; set; }

        public int QualificationId { get; set; }
        public int DoctorId { get; set; }

    }
}

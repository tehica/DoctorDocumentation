using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.ViewModels
{
    public class QualificationDetailsViewModel
    {
        public Qualification Qualification { get; set; }
        public IList<Doctor_Qualification> Doctors { get; set; }
    }
}

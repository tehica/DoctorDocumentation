﻿using DoctorDoc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.ViewModels
{
    public class DoctorAndHospitalViewModel
    {
        public Doctor Doctor { get; set; }

        public IEnumerable<Hospital> HospitalList { get; set; }

    }
}

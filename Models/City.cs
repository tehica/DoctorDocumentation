﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class City : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ZipCode { get; set; }

    }
}

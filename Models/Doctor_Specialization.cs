using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class Doctor_Specialization
    {
        [Display(Name = "Specialization")]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }


        // SUBJECT FK
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }


        [Required]
        public string AcquiredAt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class Doctor_Qualification
    {
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }


        [Display(Name = "Qualification")]
        public int QualificationId { get; set; }
        public virtual Qualification Qualification { get; set; }

        [Required]
        public string AcquiredAt { get; set; }
    }
}

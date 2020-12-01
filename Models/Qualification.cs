using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class Qualification : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string InstituteName { get; set; }

        //[Required]
        //public DateTime AcquiredAt { get; set; }


        //// FK Doctor
        //public int DoctorId { get; set; }
        //[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; set; }
    }
}

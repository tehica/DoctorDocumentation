using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class Hospital : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        // FK City
        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}

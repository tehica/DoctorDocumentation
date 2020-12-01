using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorDoc1.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

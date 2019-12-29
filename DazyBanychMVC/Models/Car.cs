using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Car
    {
        [Display(Name = "Registration Number")]
        [Key]
        [Required]
        public int RegistrationNumber { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [StringLength(maximumLength:17,MinimumLength =17)]
        public string VIN { get; set; }
        [Required]
        public string Mark { get; set; }
        [Required]
        public string Model { get; set; }
        [Display(Name = "Policy Number")]
        [Required]
        public int PolicyNumber { get; set; }
    }
}

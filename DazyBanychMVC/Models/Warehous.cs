using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Warehous
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Building Number")]
        public int HouseNumber { get; set; }
    }
}

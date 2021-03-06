﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }

        public ICollection<Street> streets { get; set; }
    }
}

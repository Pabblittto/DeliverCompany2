using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Invoice// faktura
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        [Display(Name = "Date of Arrival")]
        [Required]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Path to file")]
        [Required]
        public string FilePath { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Position
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Minimum salary")]
        public int MinSalary { get; set; }
        [Required]
        [Display(Name = "Maximum salary")]
        public int MaxSalary { get; set; }

        public ICollection<Worker> workers { get; set; }
    }
}

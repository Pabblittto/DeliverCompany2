using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class ChamberType
    {
        [Display(Name = "Name")]
        [Key]
        public string TypeName { get; set; }

        [Required]
        [Display(Name = "Height (cm)")]
        public int Height { get; set; }

        [Required]
        [Display(Name = "Width (cm)")]
        public int Width { get; set; }

        public ICollection<Chamber> chambers { get; set; }
    }
}

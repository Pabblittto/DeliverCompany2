using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class PackType
    {
        [Key]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Minimal Weight (kg)")]
        public float MinWeight { get; set; }
        [Required]
        [Display(Name = "Maximum Weight (kg)")]
        public float MaxWeight { get; set; }
        [Required]
        public int Price { get; set; }
        public ICollection<Pack> packs { get; set; }

    }
}

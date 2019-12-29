using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Pack
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Package Type")]
        public string PackTypeId { get; set; }
        public PackType type { get; set; }
        [Required]
        [Display(Name = "Weight (kg)")]
        public int Weight { get; set; }
        [Required]
        [Display(Name = "Height (cm)")]
        public int Height { get; set; }
        public Order order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Chamber
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Parcel Locker")]
        [Required]
        public int ParcelLockerId { get; set; }
        public ParcelLocker parcelLocker { get; set; }

        [Display(Name = "Chamber Type")]
        [Required]
        public string ChamberTypeId { get; set; }
        public ChamberType chamberType { get; set; }

        [Display(Name = "Amount of chambers")]
        [Required]
        public int Amount { get; set; }
        [Display(Name = "Amount of free chambers")]
        [Required]
        public int FreeAmount { get; set; }

    }
}

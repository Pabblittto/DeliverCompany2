using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCompanyAPIBackend.Models
{
    public class Order// zamówienia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }
        public Department department { get; set; }
        [Required]
        [Display(Name = "Sender")]
        public int SenderId { get; set; }
        public Person Sender { get; set; }
        [Required]
        [Display(Name = "Reciver")]
        public int ReciverId { get; set; }
        public Person Receiver { get; set; }
        [Display(Name = "State of Package")]
        public string State { get; set; }//state of the order
        [Required]
        [Display(Name = "Package")]
        public int PackId { get; set; }
        [Display(Name = "Package")]
        public Pack pack { get; set; }
    }
}

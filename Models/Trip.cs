using System;
using System.ComponentModel.DataAnnotations;

namespace FuelDeliverySystem.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        public string DateCreated { get; set; }

        //Foreign Key Dependencies
        [Required]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace FuelDeliverySystem.Models
{
    public class Stop
    {
        [Key]
        public int StopId { get; set; }

        [Required]

        public string DateCreated { get; set; }

        [Required]
        public int FuelPercentageUsed { get; set; }

        [Required]
        public int FuelAmountUsed { get; set; }

        //Foreign Key Dependencies
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
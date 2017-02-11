using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelDeliverySystem.Models
{
    public class Stop
    {
        [Key]
        public int StopId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.Date)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public int FuelPercentageUsed { get; set; }

        //Foreign Key Dependencies
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
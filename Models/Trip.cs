using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelDeliverySystem
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.Date)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        //Foreign Key Dependencies
        [Required]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }

        public ICollection<Stop> Stops;
    }
}
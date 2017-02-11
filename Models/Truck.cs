using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelDeliverySystem
{
    public class Truck
    {
        [Key]
        public int TruckId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.Date)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Capacity { get; set; } = 100;

        //Foreign Key Dependencies
        [Required]
        public int OperatingRegionId { get; set; }
        public OperatingRegion OperatingRegion { get; set; }

        public ICollection<Trip> Trips;
    }
}
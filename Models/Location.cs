using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FuelDeliverySystem.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.Date)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Longitude { get; set; }

        [Required]
        public float Latitude { get; set; }

        [Required]
        public int PostalCode { get; set; }

        public int OperatingRegionId { get; set; }
        public OperatingRegion OperatingRegion { get; set; }
    }
}
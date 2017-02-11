using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FuelDeliverySystem.Models
{
    public class OperatingRegion
    {
        [Key]
        public int OperatingRegionId { get; set; }

        [Required]
        [DataTypeAttribute(DataType.Date)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        
        [Required]
        public int Radius { get; set; }
    }
}
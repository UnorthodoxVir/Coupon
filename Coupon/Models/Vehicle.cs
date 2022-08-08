using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coupon.Models
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Brand))]
        public Guid BrandId { get; set; }
        public VehicleBrand Brand { get; set; }
    }
}

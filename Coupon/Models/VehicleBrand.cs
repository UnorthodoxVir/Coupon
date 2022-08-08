using System;
using System.ComponentModel.DataAnnotations;

namespace Coupon.Models
{
    public class VehicleBrand
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

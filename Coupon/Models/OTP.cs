using System;
using System.ComponentModel.DataAnnotations;

namespace Coupon.Models
{
    public class OTP
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid CustomerId { get; set; }
        public bool isUsed { get; set; } = false;
    }
}

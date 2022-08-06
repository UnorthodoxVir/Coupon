using System;
using static Coupon.Models.Enum;

namespace Coupon.ViewModel
{
    public class CustomerViewModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public string Vehicle { get; set; }
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public Guid UsedCoupon { get; set; }
    }
}

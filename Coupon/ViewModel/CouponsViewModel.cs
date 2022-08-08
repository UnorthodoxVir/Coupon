using Coupon.Models;
using System.Collections.Generic;

namespace Coupon.ViewModel
{
    public class CouponsViewModel
    {
        public int? City { get; set; }
        public int? DiscountType { get; set; }
        public float DiscountAmount { get; set; }
        public List<CouponCard> CouponCards { get; set; }
    }
}

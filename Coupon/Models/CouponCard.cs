using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coupon.Models
{
    public class CouponCard
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(CompCoupon))]
        public Guid CouponId { get; set; }
        public virtual CompCoupon CompCoupon { get; set; }
        public string Code { get; set; }
        public bool Used { get; set; } = false;

        [ForeignKey(nameof(Customer))]
        public Guid? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Coupon.Models.Enum;

namespace Coupon.Models
{
    public class CompCoupon
    {
        public Guid Id { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Count { get; set; }
        public DiscountType DiscountType { get; set; }
        public float Discount { get; set; }
        [ForeignKey(nameof(Company))]
        public Guid CompId { get; set; }
        public virtual Company Company { get; set; }
    }
}

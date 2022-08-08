using Coupon.Models;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Models.CompCoupon> CompCoupons { get; set; }
        public DbSet<CouponCard> CouponCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        public DbSet<VehicleBrand> VehicleBrands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}

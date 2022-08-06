using Coupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupon.Data.Repositories
{



    public class CompCouponsRepository : IGenericRepository<CompCoupon>
    {

        private readonly ApplicationDbContext _context;
        public CompCouponsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CompCoupon entity)
        {
            _context.CompCoupons.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public CompCoupon Get(Guid id)
        {
            return _context.CompCoupons.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<CompCoupon> List()
        {
            return _context.CompCoupons.ToList();          
        }

        public void Update(CompCoupon entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

using Coupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupon.Data.Repositories
{



    public class CouponCardsRepository : IGenericRepository<CouponCard>
    {

        private readonly ApplicationDbContext _context;
        public CouponCardsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(CouponCard entity)
        {
            _context.CouponCards.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public CouponCard Get(Guid id)
        {
            return _context.CouponCards.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<CouponCard> List()
        {
            return _context.CouponCards.ToList();          
        }

        public void Update(CouponCard entity)
        {
            _context.CouponCards.Update(entity);
            _context.SaveChanges();
        }
    }
}

using Coupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupon.Data.Repositories
{
    public class OTPRepository : IGenericRepository<OTP>
    {
        private readonly ApplicationDbContext _context;
        public OTPRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(OTP entity)
        {
            _context.OTPs.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OTP Get(Guid id)
        {
            return _context.OTPs.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<OTP> List()
        {
            return _context.OTPs.ToList();
        }

        public void Update(OTP entity)
        {
            _context.OTPs.Update(entity);
            _context.SaveChanges();
        }
    }
}

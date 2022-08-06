using Coupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupon.Data.Repositories
{
    public class CompanyRepository : IGenericRepository<Company>
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Company entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Company Get(Guid id)
        {
            return _context.Companies.Where(o=>o.Id == id).FirstOrDefault();
        }

        public List<Company> List()
        {
            return _context.Companies.ToList();
        }

        public void Update(Company entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

using Coupon.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coupon.Data.Repositories
{



    public class CustomersRepository : IGenericRepository<Customer>
    {

        private readonly ApplicationDbContext _context;
        public CustomersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Where(o => o.Id == id).FirstOrDefault();
        }

        public List<Customer> List()
        {
            return _context.Customers.ToList();          
        }

        public void Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

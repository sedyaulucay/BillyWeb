using Billy.Web.Data;
using Billy.Web.Models;

namespace Billy.Web.Services
{
    public class CustomerService : ICustomerService
    {
        private ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
           _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}

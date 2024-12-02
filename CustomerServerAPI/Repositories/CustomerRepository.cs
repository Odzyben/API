using CustomerServerAPI.Interfaces;
using CustomerServerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerServerAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
            var customerToDelete = await GetById(id);

            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        //public async Task<Customer> UpdateCustomer(int id, Customer customer)
        //{
        //    //var customerToUdate = await _context.Customers.FindAsync(id);
        //    if (customer != null)
        //    {
        //        customer.Id = id;
        //        _context.Customers.Update(customer);
        //        customerToUdate.FirtsName = customer.FirtsName;
        //        customerToUdate.LastName = customer.LastName;
        //        customerToUdate.LastName = customer.LastName;
        //        customerToUdate.PhoneNumer = customer.PhoneNumer;
        //        customerToUdate.EmailAddress = customer.EmailAddress;
        //        customerToUdate.Address = customer.Address;
        //        await _context.SaveChangesAsync();
        //        return customer;
        //    }
            
        //}

    }
}
using CustomerServerAPI.Interfaces;
using CustomerServerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerServerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAll() => await _customerRepository.GetAll();

        public async Task<Customer> GetById(int id) => await _customerRepository.GetById(id);

        public async Task<Customer> InsertCustomer(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetById(customer.Id);
            if (existingCustomer != null)
            {
                return await UpdateCustomer(customer);
            }

            return await _customerRepository.InsertCustomer(customer);
        }

        public async Task<Customer> UpdateCustomer(Customer customer) => await _customerRepository.UpdateCustomer(customer);

        public async Task DeleteById(int id) => await _customerRepository.DeleteById(id);

    }
}

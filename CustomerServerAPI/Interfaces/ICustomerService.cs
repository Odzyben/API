using CustomerServerAPI.Models;

namespace CustomerServerAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetById(int id);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Customer> InsertCustomer(Customer customer);

        Task DeleteById(int id);
    }
}

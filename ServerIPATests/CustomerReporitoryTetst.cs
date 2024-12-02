using CustomerServerAPI.Interfaces;
using CustomerServerAPI.Models;
using FakeItEasy;
using FluentAssertions;

namespace ServerIPATests
{
    public class CustomerReporitoryTetst
    {
        ICustomerRepository _customerRepository;

        public CustomerReporitoryTetst()
        {
            _customerRepository = A.Fake<ICustomerRepository>();
        }

        [Fact]
        public void СustomerServerAPI_CustomerRepository_GetAll()
        {
            //dependencies
            var customers = A.Fake<IEnumerable<Customer>>();
            A.CallTo(() => _customerRepository.GetAll()).Returns(customers);

            //actions
            var result = _customerRepository.GetAll();

            //assert
            result.Should().BeOfType<Task<IEnumerable<Customer>>>();
            Assert.NotNull(result);

        }

        [Fact]
        public void СustomerServerAPI_CustomerRepository_GetById()
        {

            //dependencies
            var customer = A.Fake<Customer>();
            customer.Id = 1;
            A.CallTo(() => _customerRepository.GetById(customer.Id)).Returns(customer);

            //actions
            var result = _customerRepository.GetById(1);

            //assert
            result.Id.Should().Be(customer.Id);
            Assert.NotNull(result);

        }
    }
}
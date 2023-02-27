using RabbitMqCustomerAPI.Models;

namespace RabbitMqCustomerAPI.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetCustomerList();
        public Customer GetCustomerById(int id);
        public Customer AddCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public bool DeleteCustomer(int Id);
    }
}

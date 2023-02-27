using RabbitMqCustomerAPI.Data;
using RabbitMqCustomerAPI.Models;

namespace RabbitMqCustomerAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DbContextClass _dbContext;
        public CustomerService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Customer> GetCustomerList()
        {
            return _dbContext.Customer.ToList();
        }
        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customer.Where(x => x.Id == id).FirstOrDefault();
        }
        public Customer AddCustomer(Customer customer)
        {
            var result = _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            var result = _dbContext.Customer.Update(customer);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteCustomer(int Id)
        {
            var filteredData = _dbContext.Customer.Where(x => x.Id == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
    }
}

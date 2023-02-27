using Microsoft.AspNetCore.Mvc;
using RabbitMqCustomerAPI.Models;
using RabbitMqCustomerAPI.RabbitMQ;
using RabbitMqCustomerAPI.Services;

namespace RabbitMqCustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public CustomerController(ICustomerService _customerService, IRabitMQProducer rabitMQProducer)
        {
            customerService = _customerService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpGet("customerlist")]
        public IEnumerable<Customer> CustomerList()
        {
            var customerList = customerService.GetCustomerList();
            return customerList;
        }

        [HttpGet("getcustomerbyid")]
        public Customer GetCustomerById(int Id)
        {
            return customerService.GetCustomerById(Id);
        }

        [HttpPost("addcustomer")]
        public Customer AddCustomer(Customer customer)
        {
            var customerData = customerService.AddCustomer(customer);
            //send the inserted customer data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendCustomerMessage(customerData);
            return customerData;
        }

        [HttpPut("updatecustomer")]
        public Customer UpdateCustomer(Customer customer)
        {
            return customerService.UpdateCustomer(customer);
        }

        [HttpDelete("deletecustomer")]
        public bool DeleteCustomer(int Id)
        {
            return customerService.DeleteCustomer(Id);
        }
    }
}

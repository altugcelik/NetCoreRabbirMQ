using Microsoft.EntityFrameworkCore;
using RabbitMqCustomerAPI.Models;

namespace RabbitMqCustomerAPI.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Customer> Customer
        {
            get;
            set;
        }
    }
}

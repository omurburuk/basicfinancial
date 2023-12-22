using BasicFinancial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}

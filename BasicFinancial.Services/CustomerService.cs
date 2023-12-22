using BasicFinancial.Core;
using BasicFinancial.Core.Models;
using BasicFinancial.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers
                .AddAsync(newCustomer);

            return newCustomer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _unitOfWork.Customers.Remove(customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer customerToBeUpdated, Customer customer)
        {
            customerToBeUpdated.FirstName = customer.FirstName;
            customerToBeUpdated.LastName = customer.LastName;

            await _unitOfWork.CommitAsync();
        }
    }
}

using BasicFinancial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithAccountAsync();
        Task<Customer> GetWithAccountByIdAsync(int id); 
    }
}

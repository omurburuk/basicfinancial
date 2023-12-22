using BasicFinancial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAllWithCustomersAsync();
        Task<IEnumerable<Account>> GetAllWithCustomerByCustomerIdAsync(int customerId);
        Task<Account> GetWithAccountsByIdAsync(int id);
    }
}

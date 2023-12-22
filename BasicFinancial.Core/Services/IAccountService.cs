using BasicFinancial.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllWithCustomer();
        Task<Account> GetAccountById(int id);
        Task<IEnumerable<Account>> GetAccountsByCustomerId(int customerId);
        Task<Account> CreateAccount(Account newAccount);
        Task UpdateAccount(Account musicToBeUpdated, Account music);
        Task DeleteAccount(Account music);
    }
}

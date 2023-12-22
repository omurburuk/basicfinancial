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
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Account> CreateAccount(Account newAccount)
        {
            await _unitOfWork.Accounts.AddAsync(newAccount);
            await _unitOfWork.CommitAsync();
            return newAccount;
        }

        public async Task DeleteAccount(Account account)
        {
            _unitOfWork.Accounts.Remove(account);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Account>> GetAllWithCustomer()
        {
            return await _unitOfWork.Accounts
                .GetAllWithCustomersAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _unitOfWork.Accounts
                .GetWithAccountsByIdAsync(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsByCustomerId(int customerId)
        {
            return await _unitOfWork.Accounts
                .GetAllWithCustomerByCustomerIdAsync(customerId);
        }

        public async Task UpdateAccount(Account accountToBeUpdated, Account account)
        {
            accountToBeUpdated.Name = account.Name;
            accountToBeUpdated.CustomerId = account.CustomerId;

            await _unitOfWork.CommitAsync();
        }
    }
}

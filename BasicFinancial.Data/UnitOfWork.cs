using BasicFinancial.Core;
using BasicFinancial.Core.Repositories;
using BasicFinancial.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinancialDbContext _context;
        private AccountRepository _accountRepository;
        private CustomerRepository _customerRepository;
        private UserRepository _userRepository;

        public UnitOfWork(FinancialDbContext context)
        {
            this._context = context;
        }

        public IAccountRepository Accounts => _accountRepository = _accountRepository ?? new AccountRepository(_context);

        public ICustomerRepository Customers => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
       
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

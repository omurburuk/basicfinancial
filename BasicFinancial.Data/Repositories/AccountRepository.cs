using BasicFinancial.Core.Models;
using BasicFinancial.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(FinancialDbContext context)
             : base(context)
        { }

        public async Task<IEnumerable<Account>> GetAllWithCustomersAsync()
        {
            return await FinancialDbContext.Accounts
                .Include(m => m.Customer)
                .ToListAsync();
        }

        public async Task<Account> GetWithAccountsByIdAsync(int id)
        {
            return await FinancialDbContext.Accounts
                .Include(m => m.Customer)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        public async Task<IEnumerable<Account>> GetAllWithCustomerByCustomerIdAsync(int customerId)
        {
            return await FinancialDbContext.Accounts
                .Include(m => m.Customer)
                .Where(m => m.CustomerId == customerId)
                .ToListAsync();
        }
        private FinancialDbContext FinancialDbContext
        {
            get { return Context as FinancialDbContext; }
        }

    }
}

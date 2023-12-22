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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FinancialDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Customer>> GetAllWithAccountAsync()
        {
            return await FinancialDbContext.Customers
                .Include(a => a.Accounts)
                .ToListAsync();
        }

        public async Task<Customer> GetWithAccountByIdAsync(int id)
        {
            return await FinancialDbContext.Customers
                .Include(a => a.Accounts)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private FinancialDbContext FinancialDbContext
        {
            get { return Context as FinancialDbContext; }
        }
    }
}

using BasicFinancial.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}

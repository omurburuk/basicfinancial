using BasicFinancial.Core.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Login(string email, string password);
        Task<User> Register(User user);
        Task<User> GetById(int id);
    }
}

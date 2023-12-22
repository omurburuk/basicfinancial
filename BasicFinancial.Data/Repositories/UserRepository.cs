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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FinancialDbContext context)
            : base(context)
        { }
         
        public Task<User> GetById(int id)
        {
            return FinancialDbContext.User
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<User> Login(string email, string password)
        {
            return await FinancialDbContext.User
                 .SingleOrDefaultAsync(a => a.Email == email && a.Password == password); ;
        }
         

        public async Task<User> Register(User user)
        {
            return FinancialDbContext.User.Add(user).Entity; 
        }

        private FinancialDbContext FinancialDbContext
        {
            get { return Context as FinancialDbContext; }
        }
    }
}

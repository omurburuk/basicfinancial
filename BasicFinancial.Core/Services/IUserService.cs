using BasicFinancial.Core.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFinancial.Core.Services
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);
        Task<User> Register(User model); 
        Task<User> GetById(int id);
    }
}

using BasicFinancial.Core.Services;
using BasicFinancial.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicFinancial.Core.Models; 

namespace BasicFinancial.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> GetById(int id)
        {
           return await _unitOfWork.Users.GetById(id);
        }

        public async Task<User> Login(string email, string password)
        {
            return await _unitOfWork.Users.Login(email, password);
        }

        public async Task<User> Register(User model)
        {
            return await _unitOfWork.Users.Register(model);
        }
         
    }
}

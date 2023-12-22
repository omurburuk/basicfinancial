using BasicFinancial.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace BasicFinancial.Models.Request
{
    public class RegisterRequest
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } = string.Empty;

        public User MapToUser()
        {
            return new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
        }
    }
}

using BasicFinancial.Core.Models;
using BasicFinancial.Models;

namespace BasicFinancial.Models.Response
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }  
        public string Token { get; set; }  
        public string Email { get; set; } 

        public AuthenticateResponse(User user, string token )
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            FullName = FirstName + " " + LastName; 
            Email = user.Email;
            Token = token; 
        }
    }
}

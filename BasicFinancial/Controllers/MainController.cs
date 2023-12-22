
using BasicFinancial.Core.Models;
using BasicFinancial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicFinancial.Controllers.Mobile
{
    public class MainController : ControllerBase
    {
        // global static methods...

        public static string getUserFullName(User user)
        {
            return user.FirstName + " " + user.LastName;
        }  
        
        public static User getUser(IHttpContextAccessor _httpContextAccessor)
        {
            return (User)_httpContextAccessor.HttpContext.Items["User"];
        }
    }
}

 
using System.ComponentModel.DataAnnotations;

namespace BasicFinancial.Core.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; } 
        public string IdentityNumber { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}

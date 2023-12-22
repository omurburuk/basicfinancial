 
using System.ComponentModel.DataAnnotations;

namespace BasicFinancial.Core.Models
{
    public class Account : IEntity 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public string Currency { get; set; } 

        public Customer Customer { get; set; }
    }
}

 
using System.Text.Json.Serialization;

namespace BasicFinancial.Core.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public int Status { get; set; } = 0;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}

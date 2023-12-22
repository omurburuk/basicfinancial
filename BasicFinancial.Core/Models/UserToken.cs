 
namespace BasicFinancial.Core.Models
{
    public class UserToken : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public int Status { get; set; } // 0 - live, 1 Revoked, 2 Logouted
        public Nullable<DateTime> CreateDate { get; set; } = DateTime.Now; 
        public Nullable<DateTime> MaxUseDate { get; set; } // maximum session gmt datetime
    }
}

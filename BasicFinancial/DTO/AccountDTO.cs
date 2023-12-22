namespace BasicFinancial.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}

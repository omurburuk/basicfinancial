namespace BasicFinancial.Models.Response
{
    public class ServiceResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPageNumber { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; } = 200;
        public bool Success { get; set; } = true; 
    }
}

namespace RESTAPI.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = String.Empty;
        public string? CompanyName { get; set; } = String.Empty;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}

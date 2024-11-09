﻿namespace RESTAPI.Helpers
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = String.Empty;
        public string? CompanyName { get; set; } = String.Empty;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}

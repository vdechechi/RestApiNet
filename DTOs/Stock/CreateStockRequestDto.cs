﻿using RESTAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.DTOs.Stock
{
    public class CreateStockRequestDto // Possui Tudo menos o ID
    {
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        

    }
}

using RESTAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.DTOs.Stock
{
    public class CreateStockRequestDto // Possui Tudo menos o ID
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(20, ErrorMessage = "{0} cannot be over 20 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10000000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "{0} cannot be over 20 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 10000000000000)]
        public long MarketCap { get; set; }
        

    }
}

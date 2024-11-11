using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPI.Models
{
    [Table("Portifolios")]
    public class Portifolio
    {
        public string AppUserId { get; set; }  
        public int StockId { get; set; }

        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}

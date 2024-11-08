using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpGet] 

        public async Task<IActionResult> GetAll()
        {
            var stocks = await _context.Stocks.AsNoTracking().ToListAsync();

            if(stocks == null || stocks.Count == 0) { return NoContent(); }

            return Ok(stocks);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var stock = await _context.Stocks.AsNoTracking().Where(s => s.Id == id).FirstAsync();

            if (stock == null) { return NotFound(); }

            return Ok(stock);

        }


    }
}

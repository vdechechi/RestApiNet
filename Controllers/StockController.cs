using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Data;
using RESTAPI.DTOs.Stock;
using RESTAPI.Interfaces;
using RESTAPI.Mappers;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDbContext context, IStockRepository stockRepo)
        {
            _stockRepo = stockRepo;
            _context = context;
            
        }

        [HttpGet] 

        public async Task<IActionResult> GetAll()
        {

            var stocks = 

            var stockDto = stocks.Select(s => s.ToStockDto());

            return Ok(stocks);

        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var stock = await _context.Stocks.AsNoTracking().Where(s => s.Id == id).FirstAsync();

            if (stock == null) { return NotFound(); }

            return Ok(stock.ToStockDto());
             
        }


        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {

            var stockModel =  stockDto.ToStockFromCreateDto();

            _context.Stocks.Add(stockModel);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());


        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
        {

            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null)
            {
                return NotFound();
            }
                stockModel.Symbol = updateDto.Symbol;
                stockModel.CompanyName = updateDto.CompanyName;
                stockModel.Purchase = updateDto.Purchase;
                stockModel.Industry = updateDto.Industry;
                stockModel.MarketCap = updateDto.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());

        }

        [HttpDelete]
        [Route("{id:int}")]


        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(stockModel == null)
            {
                return NotFound(id);
            }
            _context.Stocks.Remove(stockModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    } 
}

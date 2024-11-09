using Microsoft.AspNetCore.Mvc;
using RESTAPI.DTOs.Comment;
using RESTAPI.Interfaces;
using RESTAPI.Mappers;

namespace RESTAPI.Controllers
{

    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {

            if(!ModelState.IsValid) { return BadRequest(); }

            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());
             
            if (comments == null) { return NotFound(); }

            return Ok(commentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (!ModelState.IsValid) { return BadRequest(); }

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null) { return NotFound(); };

            return Ok(comment.ToCommentDto());

        }

        [HttpPost]
        [Route("stock/{stockId:int}")]

        public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommentRequestDto commentDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }


            if (!await _stockRepo.StockExists(stockId))
            {
                return BadRequest("Stock does not exist");
            }

            else
            {
                var commentModel = commentDto.ToCommentFromCreate(stockId);

                await _commentRepo.CreateAsync(commentModel);

                return CreatedAtAction(nameof(GetById), new {id = commentModel.Id}, commentModel.ToCommentDto());
            }

        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequestDto updateDto)
        {

            if (!ModelState.IsValid) { return BadRequest(); }


            var comment = await _commentRepo.UpdateAsync(id, updateDto.ToCommentFromUpdate());

            if(comment == null)
            {
                return NotFound("Comment Not Found");
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete ([FromRoute] int id)
        {

            if (!ModelState.IsValid) { return BadRequest(); }

            var comment = await _commentRepo.DeleteAsync(id);

            if(comment == null) { return NotFound("Comment Does not exist"); }

            return Ok(comment.ToCommentDto());

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RESTAPI.Interfaces;
using RESTAPI.Mappers;

namespace RESTAPI.Controllers
{

    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            if (comments == null) { return NotFound(); }

            return Ok(commentDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null) { return NotFound(); };

            return Ok(comment.ToCommentDto());

        }
    }
}

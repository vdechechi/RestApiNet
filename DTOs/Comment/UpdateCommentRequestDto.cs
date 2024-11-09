using System.ComponentModel.DataAnnotations;

namespace RESTAPI.DTOs.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "{0} must have at least 5 character ")]
        [MaxLength(280, ErrorMessage = "{0} can´t be over 280 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "{0} must have at least 5 character ")]
        [MaxLength(280, ErrorMessage = "{0} can´t be over 280 characters")]
        public string Content { get; set; } = string.Empty;

    }
}

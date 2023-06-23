using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class CommentInput
    {
        [Required]
        [MaxLength(60)]
        [MinLength(1)]
        public string text { get; set; }
        public string title { get; set; }
        public int UserId { get; set; }
        public int VeterinaryId { get; set; }
    }
}

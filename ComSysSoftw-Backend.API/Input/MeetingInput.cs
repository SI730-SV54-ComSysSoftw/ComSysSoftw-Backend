using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class MeetingInput
    {
        [Required]
        public DateTime DateToMeet { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VeterinaryId { get; set; }
    }
}

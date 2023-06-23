using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class VeterinaryInput
    {
        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string name { get; set; }

        public string district { get; set; }

        public string phone_number { get; set; }
        public int UserId { get; set; }
        public string ImgUrl { get; set; }
    }
}

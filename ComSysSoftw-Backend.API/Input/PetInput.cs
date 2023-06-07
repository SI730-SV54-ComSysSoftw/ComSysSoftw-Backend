using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class PetInput
    {
        [Required]
        [MaxLength(30)]
        [MinLength(1)]
        public string name { get; set; }
        public int age { get; set; }
        public string description { get; set; }

        public int UserId { get; set; }
    }
}

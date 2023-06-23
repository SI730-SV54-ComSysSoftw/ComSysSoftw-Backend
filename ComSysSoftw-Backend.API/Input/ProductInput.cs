using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class ProductInput
    {
        [Required]
        [MaxLength(60)]
        [MinLength(1)]
        public string name { get; set; }
        public string description { get; set; }
        public float amount { get; set; }
        public int VeterinaryId { get; set; }
    }
}

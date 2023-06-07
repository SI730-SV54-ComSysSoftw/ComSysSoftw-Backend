using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComSysSoftw_Backend.API.Input
{
    public class LoginRequest
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}

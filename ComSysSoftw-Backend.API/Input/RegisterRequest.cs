using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}

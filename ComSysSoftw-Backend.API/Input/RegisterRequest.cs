using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MinLength(8)]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Roles { get; set; } = string.Empty;
    }
}

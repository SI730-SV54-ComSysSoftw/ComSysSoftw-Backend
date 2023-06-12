using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ComSysSoftw_Backend.API.Input
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}

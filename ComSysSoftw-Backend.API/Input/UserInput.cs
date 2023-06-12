using System.ComponentModel.DataAnnotations;

namespace ComSysSoftw_Backend.API.Input;

public class UserInput
{
    [Required]
    [MaxLength(30)]
    [MinLength(1)]
    public string name { get; set; }
    public string email { get; set; }
    public int age { get; set; }
    public bool isVet { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Roles { get; set; }
}

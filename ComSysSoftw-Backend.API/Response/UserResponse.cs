namespace ComSysSoftw_Backend.API.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string name { get; set; }

    public string email { get; set; }

    public int age { get; set; }

    public bool isVet { get; set; }

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;
}

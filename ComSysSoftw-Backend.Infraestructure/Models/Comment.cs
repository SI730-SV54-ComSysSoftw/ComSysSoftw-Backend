

namespace ComSysSoftw_Backend.Infraestructura.Model;

public class Comment
{
    public int Id { get; set }
    public string description { get; set; }
    public int UserId { get; set; }
    public int VeterinaryId { get; set; }
}
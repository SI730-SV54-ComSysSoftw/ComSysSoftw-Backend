using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Models; 
public class User : BaseModel
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;
    public string name { get; set; }
    public string email { get; set; }
    public int age { get; set; }
    public bool IsVet { get; set; } = false;
    public List<Veterinary>? veterinaries { get; set; } = new List<Veterinary>();
    public List<Pet>? pets { get; set; } = new List<Pet>();
    public List<Meeting>? meetings { get; set; } = new List<Meeting>();
}


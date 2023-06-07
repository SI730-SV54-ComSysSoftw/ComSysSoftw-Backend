using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models;
public class Veterinary
{
    public int Id { get; set; }
    public string name { get; set; }

    public string district { get; set; }

    public string phone_number{ get; set; }
    public User User { get; set; }
    public int UserId { get; set; }

    public List<Meeting>? meetings { get; set; } = new List<Meeting>();
}


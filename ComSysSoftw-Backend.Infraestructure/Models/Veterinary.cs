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

    public List<User> Users { get; set; }
}


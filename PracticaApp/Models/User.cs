using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infraestructure.Models; 
public class User
{
    public int Id { get; set; }
    public string name { get; set; }

    public string Description { get; set; }

    public List<Pet>Pets { get; set; } //una usuario puede tener varias mascotas
}


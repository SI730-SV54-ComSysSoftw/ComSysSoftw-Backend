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

    public string email { get; set; }

    public int age { get; set; }

    public bool IsActive { get; set; }

    //una usuario puede tener varias mascotas
}


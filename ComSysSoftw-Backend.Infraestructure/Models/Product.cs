using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Models
{
    public class Product:BaseModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public DateTime DateToProduct { get; set; }
        public int VeterinaryId { get; set; }
    }
}

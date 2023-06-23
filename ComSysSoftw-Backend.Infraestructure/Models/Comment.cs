using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Models
{
    public class Comment:BaseModel
    {
        
        public string text { get; set; }
        public string title { get; set; }
        public DateTime DateToComment { get; set; }
        public int UserId { get; set; }
        public int VeterinaryId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Models
{
    public class Meeting : BaseModel
    {
        public DateTime DateToMeet { get; set; }
        public int UserId { get; set; }
        public int VeterinaryId { get; set; }
    }
}

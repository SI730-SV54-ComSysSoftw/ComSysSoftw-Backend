using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure.Interfaces
{
    public interface IMeetingInfraestructure
    {
        Task<bool> Meet(Meeting meet);
    }
}

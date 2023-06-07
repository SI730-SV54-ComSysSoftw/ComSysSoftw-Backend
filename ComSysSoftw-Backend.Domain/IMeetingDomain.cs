using ComSysSoftw_Backend.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public interface IMeetingDomain
    {
        Task<bool> Meet(Meeting meet);
    }
}

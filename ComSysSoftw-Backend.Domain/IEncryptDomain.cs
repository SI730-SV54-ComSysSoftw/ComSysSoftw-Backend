using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public interface IEncryptDomain
    {
        string Ecnrypt(string password);
    }
}

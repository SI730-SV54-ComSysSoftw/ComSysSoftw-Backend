using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Context;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Infraestructure
{
    public class MeetingInfraestructure : IMeetingInfraestructure
    {
        private readonly VetDbContext _VetDBContext;
        public MeetingInfraestructure(VetDbContext context)
        {
            _VetDBContext = context;
        }
        public async Task<bool> Meet(Meeting meet)
        {
            try
            {
                _VetDBContext.Meetings.Add(meet);
                await _VetDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception exception) { return false; }
        }
    }
}

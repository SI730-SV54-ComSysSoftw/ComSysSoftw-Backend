using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComSysSoftw_Backend.Domain
{
    public class MeetingDomain : IMeetingDomain
    {
        private readonly IMeetingInfraestructure _meetingInfraestructure;

        public MeetingDomain(IMeetingInfraestructure meetingInfraestructure)
        {
            _meetingInfraestructure = meetingInfraestructure;
        }
        public async Task<bool> Meet(Meeting meet)
        {
            return await _meetingInfraestructure.Meet(meet);
        }
    }
}

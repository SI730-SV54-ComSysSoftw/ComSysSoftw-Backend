using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.Domain;
using ComSysSoftw_Backend.Infraestructure;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingDomain _meetDomain;
        private readonly IMeetingInfraestructure _meetInfra;
        private readonly IMapper _mapper;

        public MeetingController(IMapper mapper, IMeetingDomain meetDomain, IMeetingInfraestructure meetInfra)
        {

            _mapper = mapper;
            _meetDomain = meetDomain;
            _meetInfra = meetInfra;
        }
        [HttpPost]
        public async Task<IActionResult> PostMeet(MeetingInput request)
        {
            if (ModelState.IsValid)
            {
                var meet = _mapper.Map<MeetingInput, Meeting>(request);
                await _meetDomain.Meet(meet);
                return Ok(meet);
            }
            return StatusCode(400);
        }
    }
}

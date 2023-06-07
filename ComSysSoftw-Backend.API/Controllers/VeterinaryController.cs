using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain;
using ComSysSoftw_Backend.Infraestructure;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinaryController : ControllerBase
    {
        private readonly IVeterinaryDomain _vetDomain;
        private readonly IVeterinaryInfraestructure _vetInfra;
        private readonly IMapper _mapper;

        public VeterinaryController(IMapper mapper, IVeterinaryDomain vetDomain, IVeterinaryInfraestructure vetInfra)
        {

            _mapper = mapper;
            _vetDomain = vetDomain;
            _vetInfra = vetInfra;
        }

        [HttpGet]
        public async Task<List<VeterinaryResponse>> Get()
        {
            var result = await _vetInfra.GetAll();
            var list = _mapper.Map<List<Veterinary>, List<VeterinaryResponse>>(result);
            return list;
        }

        [HttpGet("{id}")]
        public async Task<VeterinaryResponse> GetById(int id)
        {
            var vetyFound = await _vetInfra.GetById(id);
            var result = _mapper.Map<Veterinary, VeterinaryResponse>(vetyFound);

            return result;

        }

        [HttpPost]
        public async Task<IActionResult> Post(VeterinaryInput request)
        {
            if (ModelState.IsValid)
            {
                var veterinary = _mapper.Map<VeterinaryInput, Veterinary>(request);
                await _vetDomain.Create(veterinary);
                return Ok(veterinary);
            }
            return StatusCode(400);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  VeterinaryInput input)
        {
            if (ModelState.IsValid)
            {
                var vety = _mapper.Map<VeterinaryInput, Veterinary>(input);


                await _vetDomain.Update(id, vety);
                return NoContent();
            }
            else
            {

                return StatusCode(400);
            }
        }
    }
}

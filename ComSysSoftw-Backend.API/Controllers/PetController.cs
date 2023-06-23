using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetDomain _petDomain;
        private readonly IPetInfraestructure _petInfra;
        private readonly IMapper _mapper;

        public PetController(IMapper mapper, IPetDomain petDomain, IPetInfraestructure petInfra)
        {

            _mapper = mapper;
            _petDomain = petDomain;
            _petInfra = petInfra;
        }

        [HttpGet("User/{id}")]
        public async Task<List<PetResponse>> GetAllByUser(int id)
        {
            var result = await _petInfra.GetAllByUser(id);
            var list = _mapper.Map<List<Pet>, List<PetResponse>>(result);
            return list;
        }


        [HttpGet("{id}")]
        public async Task<PetResponse> GetById(int id)
        {
            var petFound = await _petInfra.GetById(id);
            var result = _mapper.Map<Pet, PetResponse>(petFound);

            return result;

        }
        
        [HttpPost]
        public async Task<IActionResult> Post(PetInput request)
        {
            if (ModelState.IsValid)
            {
                var pet = _mapper.Map<PetInput, Pet>(request);
                await _petDomain.Create(pet);
                return Ok(pet);
            }
            return StatusCode(400);

        }
    }
}

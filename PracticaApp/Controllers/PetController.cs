using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaApp.Models;

namespace PracticaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PracticaContext _context;

        public PetController(PracticaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Pets.ToList());
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Pet>> Registrar(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return Ok(pet);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var mascotaEncontrado = await _context.Pets.FindAsync(id);

            if (mascotaEncontrado == null)
                return NotFound("No se pudo encontrar a la mascota");

            return Ok(mascotaEncontrado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pet>> ActualizarMascota(int id, [FromBody] Pet pet)
        {
            try
            {
                var mascotaEncontrado = await _context.Pets.FindAsync(id);

                if (mascotaEncontrado == null)
                    return NotFound("No se pudo encontrar la mascota");

                mascotaEncontrado.name = pet.name;
                mascotaEncontrado.age = pet.age;
                await _context.SaveChangesAsync();
                return Ok(mascotaEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}


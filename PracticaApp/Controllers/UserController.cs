using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaApp.Models;

namespace PracticaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PracticaContext _context;

        public UserController(PracticaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<User>> Registrar(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var usuarioEncontrado = await _context.Users.FindAsync(id);

            if (usuarioEncontrado == null)
                return NotFound("No se pudo encontrar al usuario");

            return Ok(usuarioEncontrado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> ActualizarUsuario(int id, [FromBody]User usuario)
        {
            try
            {
                var usuarioEncontrado = await _context.Users.FindAsync(id);

                if (usuarioEncontrado == null)
                    return NotFound("No se pudo encontrar usuario");

                usuarioEncontrado.name = usuario.name;
                usuarioEncontrado.Description = usuario.Description;
                usuarioEncontrado.Pets = usuario.Pets;
                await _context.SaveChangesAsync();
                return Ok(usuarioEncontrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}

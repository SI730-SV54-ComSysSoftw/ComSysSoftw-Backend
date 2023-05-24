using ComSysSoftw_Backend.Domain;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;

        public UserController (IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _userDomain.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userFound = await _userDomain.GetUser(id);
            if (userFound == null)
                return NotFound("Usuario no encontrado");
            return Ok(userFound);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            try
            {
                await _userDomain.Save(user);
                return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
            }
            catch (Exception)
            {
                throw;
            }
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest();

            var userFound = await _userDomain.GetUser(id);
            if (userFound == null)
                return NotFound("Usuario no encontrado");

            await _userDomain.Update(id, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFound = await _userDomain.GetUser(id);
            if (userFound == null)
                return NotFound("Usuario no encontrado");

            await _userDomain.Delete(id);
            return NoContent();
        }
    }
}

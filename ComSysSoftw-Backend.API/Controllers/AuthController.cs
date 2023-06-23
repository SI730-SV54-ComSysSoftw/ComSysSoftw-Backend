using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain.Interfaces;
using Infraestructure.Context;
using ComSysSoftw_Backend.Domain;
using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VetDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserDomain _userDomain;

        public AuthController(VetDbContext context, IMapper mapper, IUserDomain userDomain)
        {
            _context = context;
            _mapper = mapper;
            _userDomain = userDomain;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserInput request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserInput, User>(request);
                await _userDomain.Create(user);
                return Ok();
            }
            return StatusCode(400);

        }

        //[HttpPost("Login")]
        //public async Task<ActionResult> Login(LoginRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userFound = await _userDomain.GetUserLogin(request.Name, request.Email);
        //        if (userFound == null) return NotFound("No se encontro el usuario");
        //        return Ok(_mapper.Map<User, UserResponse>(userFound));
        //    }
        //    return StatusCode(400);
        //}
    }
}

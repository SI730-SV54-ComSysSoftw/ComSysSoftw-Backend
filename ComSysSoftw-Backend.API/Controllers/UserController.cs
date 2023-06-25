using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain;
using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUserDomain _userDomain;
        private IUserInfraestructure _userInfraestructure;
        private IMapper _mapper;

        public UserController (IUserDomain userDomain, IUserInfraestructure userInfraestructure, IMapper mapper)
        {
            _userDomain = userDomain;
            _userInfraestructure = userInfraestructure;
            _mapper = mapper;
        }

        [Filter.Authorize("admin")]
        [HttpGet]
        public async Task<List<UserResponse>> Get()
        {
            var result=await _userInfraestructure.GetAll();
            var list=_mapper.Map<List<User>,List<UserResponse>>(result);
            return list;
        }

        [HttpGet("{id}")]
        public async Task<UserResponse> GetById(int id)
        {
            var userFound = await _userInfraestructure.GetById(id);
            var result = _mapper.Map<User,UserResponse>(userFound);
            
            return result;
            
        }

        [HttpGet("Username/{username}")]
        public async Task<UserResponse> GetByUsername(string username)
        {
            var userFound = await _userDomain.GetByUsername(username);
            var result = _mapper.Map<User,UserResponse>(userFound);
            
            return result;
            
        }

        [HttpPost("create")]
        public async Task Post([FromBody] UserInput input)
        {
            if (ModelState.IsValid)
            {
                var user=_mapper.Map<UserInput,User>(input);
                await _userDomain.Create(user);
            }
            else
            {
                StatusCode(400);
            }

        }

        [HttpPut("{id}")]
        public async Task Put (int id, [FromBody] UserInput input)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserInput, User>(input);
            

                await _userDomain.Update(id, user);

            }
            else
            { 

                StatusCode(400);
            }
        }

        [HttpDelete("{id}")]
        public async Task Update(int id)
        {
             await _userDomain.Delete(id);          
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest userInput)
        {
            try
            {
                var user = _mapper.Map<LoginRequest, User>(userInput);

                var jwt = await _userDomain.Login(user);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }

        // POST: api/User
        [AllowAnonymous]
        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(RegisterRequest userInput)
        {

            var user = _mapper.Map<RegisterRequest, User>(userInput);
            var id = await _userDomain.Signup(user);

            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }
    }
}

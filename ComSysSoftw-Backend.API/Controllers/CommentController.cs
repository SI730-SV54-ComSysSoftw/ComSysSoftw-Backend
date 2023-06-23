using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain;
using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;



namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentDomain _commentDomain;
        private readonly ICommentInfraestructure _commentInfra;
        private readonly IMapper _mapper;
        public CommentController(IMapper mapper, ICommentDomain commentDomain, ICommentInfraestructure commentInfra)
        {

            _mapper = mapper;
            _commentDomain = commentDomain;
            _commentInfra = commentInfra;
        }

        // GET: api/<CommentController>
        [HttpGet("User/{id}")]
        public async Task<List<CommentResponse>> GetAllByUser(int id)
        {
            var result = await _commentInfra.GetAllByUser(id);
            var list = _mapper.Map<List<Comment>, List<CommentResponse>>(result);
            return list;
        }

        [HttpGet("Veterinary/{id}")]
        public async Task<List<CommentResponse>> GetAllByVet(int id)
        {
            var result = await _commentInfra.GetAllByVet(id);
            var list = _mapper.Map<List<Comment>, List<CommentResponse>>(result);
            return list;
        }

        [HttpGet("{id}")]
        public async Task<CommentResponse> GetById(int id)
        {
            var commentFound = await _commentInfra.GetById(id);
            var result = _mapper.Map<Comment, CommentResponse>(commentFound);

            return result;

        }



        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Post(CommentInput input)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<CommentInput, Comment>(input);
                await _commentDomain.Create(comment);
                return Ok(comment);
            }
            return StatusCode(400);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CommentInput input)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<CommentInput, Comment>(input);


                await _commentDomain.Update(id, comment);
                return NoContent();
            }
            else
            {

                return StatusCode(400);
            }
        }
        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task Update([FromBody] int id)
        {
            await _commentDomain.Delete(id);
        }
    }
}

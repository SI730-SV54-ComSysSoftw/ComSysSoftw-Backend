using AutoMapper;
using ComSysSoftw_Backend.API.Input;
using ComSysSoftw_Backend.API.Response;
using ComSysSoftw_Backend.Domain;
using ComSysSoftw_Backend.Domain.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Interfaces;
using ComSysSoftw_Backend.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComSysSoftw_Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDomain _productDomain;
        private readonly IProductInfraestructure _productInfra;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductDomain productDomain, IProductInfraestructure productInfra)
        {

            _mapper = mapper;
            _productDomain = productDomain;
            _productInfra = productInfra;
        }

        // GET: api/<ProductController>
        [HttpGet("{id}")]
        public async Task<ProductResponse> GetById(int id)
        {
            var productFound = await _productInfra.GetById(id);
            var result = _mapper.Map<Product, ProductResponse>(productFound);

            return result;

        }

        // GET api/<ProductController>/5
        [HttpGet("Veterinary/{id}")]
        public async Task<List<ProductResponse>> GetAllByVet(int id)
        {
            var result = await _productInfra.GetAllByVet(id);
            var list = _mapper.Map<List<Product>, List<ProductResponse>>(result);
            return list;
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post(ProductInput input)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<ProductInput, Product>(input);
                await _productDomain.Create(product);
                return Ok(product);
            }
            return StatusCode(400);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProductInput input)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<ProductInput, Product>(input);


                await _productDomain.Update(id, product);
                return NoContent();
            }
            else
            {

                return StatusCode(400);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Update([FromBody] int id)
        {
            await _productDomain.Delete(id);
        }
    }
}

using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using GerenciamentoDePedidos.Core.Entities;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace GerenciamentoDePedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        private readonly GerenciamentoDbContext _context;
        private readonly IOrderService _service;
        public OrderController(GerenciamentoDbContext context, IOrderService service)
        {
            _context = context;
            _service = service;
        }
        [HttpPost]
        public IActionResult Post(CreateOrderInputModel model)
        {
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var result = _service.GetAll();            

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateorderInputModel model)
        {
            var result = _service.Update(model);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id}/description")]
        public IActionResult PostDescription (int id, CreateDescriptionInputModel model)
        {
            var result = _service.InsertDescription(id, model);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }           

            return NoContent();
        }
    }
}

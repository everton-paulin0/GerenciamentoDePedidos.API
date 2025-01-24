using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePedidos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GerenciamentoDbContext _context;
        private readonly IUserService _service;
        public UserController(GerenciamentoDbContext context, IUserService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
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

        [HttpPut]
        public IActionResult Put(int id, UpdateUserInputModel model)
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

    }
}

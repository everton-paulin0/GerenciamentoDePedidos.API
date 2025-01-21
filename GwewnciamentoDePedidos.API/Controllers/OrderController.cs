using GerenciamentoDePedidos.API.Model;
using GerenciamentoDePedidos.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GerenciamentoDePedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderTotalCostConfig _config;
        private readonly IConfigService _configService;
        public OrderController(IOptions<OrderTotalCostConfig> options, IConfigService configService)
        {
            //Options para limitar o valores total do pedido
            _config = options.Value;
            _configService = configService;
            

        }
        [HttpPost]
        public IActionResult Post(CreateOrderInputModel model)
        {
            if (model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum)
            {
                return BadRequest("Valor Incorreto");
            }
            
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpPost("{id}/description")]
        public IActionResult PostDescription (int id, CreateDescriptionInputModel model)
        {
            return Ok();
        }
    }
}

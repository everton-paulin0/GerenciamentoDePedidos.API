using GerenciamentoDePedidos.API.Model;
using GerenciamentoDePedidos.API.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace GerenciamentoDePedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        private readonly GerenciamentoDbContext _context;
        public OrderController(GerenciamentoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(CreateOrderInputModel model)
        {
           var order = model.ToEntityOrder(model.Product, model.Quantity, model.Price , model.TotalCost);

            _context.Orders.Add(order);
            _context.SaveChanges();
            
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var orders = _context.Orders.Where(o => !o.IsDeleted).ToList();

            var model = orders.Select(OrderViewModel.FromEntityOrder).ToList();
            

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            var model = OrderViewModel.FromEntityOrder(order);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateorderInputModel model)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return NotFound();
            }
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

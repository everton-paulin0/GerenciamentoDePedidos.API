using GerenciamentoDePedidos.Application.Model;
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
        public OrderController(GerenciamentoDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post(CreateOrderInputModel model)
        {
           var order = model.ToEntityOrder();

            _context.Orders.Add(order);
            _context.SaveChanges();
            
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var orders = _context.Orders.Where(o => !o.IsDeleted && (search == "" || o.Product.Contains(search)))
            .ToList();

            var model = orders.Select(OrderViewModel.FromEntityOrder).ToList();
            

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return NotFound();
            }

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

            order.Update(model.Product,model.Quantity, model.Price, model.TotalCost);

            _context.Orders.Update(order);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return NotFound();
            }

            order.SetAsDeleted();
            _context.Orders.Update(order);
            _context.SaveChanges(); 

            return NoContent();
        }

        [HttpPost("{id}/description")]
        public IActionResult PostDescription (int id, CreateDescriptionInputModel model)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return NotFound();
            }

            var comment = new Description(model.Content, model.IdOrder, model.IdUser);

            _context.Descriptions.Add(comment);
            _context.SaveChanges();

            return Ok();
        }
    }
}

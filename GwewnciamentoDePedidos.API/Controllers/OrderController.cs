using GerenciamentoDePedidos.Application.Commands.CancelOrder;
using GerenciamentoDePedidos.Application.Commands.CompleteOrder;
using GerenciamentoDePedidos.Application.Commands.DeleteOrder;
using GerenciamentoDePedidos.Application.Commands.InsertComment;
using GerenciamentoDePedidos.Application.Commands.InsertOrder;
using GerenciamentoDePedidos.Application.Commands.SetAsPending;
using GerenciamentoDePedidos.Application.Commands.UpdateOrder;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Application.Queries.GetAllOrders;
using GerenciamentoDePedidos.Application.Queries.GetOrderById;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace GerenciamentoDePedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {        
        private readonly IOrderService _service;
        private readonly IMediator _mediator;
        public OrderController(GerenciamentoDbContext context, IOrderService service, IMediator mediator)
        {
            
            _service = service;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post(InsertOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            //var result = _service.GetAll();
            var query = new GetAllOrderQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIDQuery(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPost("{id}/description")]
        public async Task<IActionResult> PostDescription (int id, InsertCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }           

            return NoContent();
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/paymentpending")]
        public async Task<IActionResult> CSetPaymentPending(int id)
        {
            var result = await _mediator.Send(new SetAsPendingOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}

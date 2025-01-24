using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Commands.CancelOrder
{
    public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, ResultViewModel>
    {
        private readonly GerenciamentoDbContext _context;
        public CancelOrderHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }
            order.Complete();

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

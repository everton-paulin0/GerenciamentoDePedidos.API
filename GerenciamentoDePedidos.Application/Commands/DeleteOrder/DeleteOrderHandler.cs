using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Commands.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, ResultViewModel>
    {
        private readonly GerenciamentoDbContext _context;
        public DeleteOrderHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

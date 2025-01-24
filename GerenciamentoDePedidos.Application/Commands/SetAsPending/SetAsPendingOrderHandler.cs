using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Commands.CompleteOrder;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Commands.SetAsPending
{
    public class SetAsPendingOrderHandler : IRequestHandler<SetAsPendingOrderCommand, ResultViewModel>
    {
        private readonly GerenciamentoDbContext _context;
        public SetAsPendingOrderHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(SetAsPendingOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<UserViewModel>.Error("Pedido não existe");
            }

            order.SetPaymentPending();

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

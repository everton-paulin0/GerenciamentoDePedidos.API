using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Queries.GetOrderById
{
    public class GetOrderByIDQuery : IRequest<ResultViewModel<OrderViewModel>>
    {
        public GetOrderByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIDQuery, ResultViewModel<OrderViewModel>>
    {
        private readonly GerenciamentoDbContext _context;
        public GetOrderByIdHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<OrderViewModel>> Handle(GetOrderByIDQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.Id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            var model = OrderViewModel.FromEntityOrder(order);

            return ResultViewModel<OrderViewModel>.Sucess(model);
        }
    }
}

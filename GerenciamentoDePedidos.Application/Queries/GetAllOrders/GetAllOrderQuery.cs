using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Queries.GetAllOrders
{
    public class GetAllOrderQuery : IRequest <ResultViewModel<List<OrderItemViemModel>>>
    {
        
        public GetAllOrderQuery()
        {

        }

        public class GetAllordesHandler : IRequestHandler<GetAllOrderQuery, ResultViewModel<List<OrderItemViemModel>>>
        {
            private readonly GerenciamentoDbContext _context;
            public GetAllordesHandler(GerenciamentoDbContext context)
            {
                _context = context;
            }
            public async Task<ResultViewModel<List<OrderItemViemModel>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders.Where(o => !o.IsDeleted).ToListAsync();

                var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


                return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
            }
        }
    }
}


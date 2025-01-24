using System;
using System.Collections.Generic;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Commands.InsertOrder
{
    
    public class InsertOrderHandler : IRequestHandler<InsertOrderCommand, ResultViewModel<int>>
    {
        private readonly GerenciamentoDbContext _context;
        public InsertOrderHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(InsertOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntityOrder();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Sucess(order.Id);
        }
    }

   
}

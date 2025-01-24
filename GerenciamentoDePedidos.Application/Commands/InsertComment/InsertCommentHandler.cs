using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Core.Entities;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Application.Commands.InsertComment
{
    public class InsertCommentHandler : IRequestHandler<InsertCommentCommand, ResultViewModel>
    {
        private readonly GerenciamentoDbContext _context;
        public InsertCommentHandler(GerenciamentoDbContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(InsertCommentCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(p => p.Id == request.IdOrder);

            if (order is null)
            {
                return ResultViewModel<CreateDescriptionInputModel>.Error("Pedido não existe");
            }

            var comment = new Description(request.Content, request.IdOrder, request.IdUser);

            _context.Descriptions.Add(comment);
            await _context.SaveChangesAsync();

            return ResultViewModel.Success();
        }
    }
}

using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<ResultViewModel>
    {
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}


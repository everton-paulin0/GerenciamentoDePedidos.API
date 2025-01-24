using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.CompleteOrder
{
    public class CompleteOrderCommand : IRequest<ResultViewModel>
    {
        public CompleteOrderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

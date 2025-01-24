using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.CancelOrder
{
    public class CancelOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}

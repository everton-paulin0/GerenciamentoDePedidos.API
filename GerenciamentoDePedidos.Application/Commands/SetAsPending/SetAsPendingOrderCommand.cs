using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.SetAsPending
{
    public class SetAsPendingOrderCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }

        public SetAsPendingOrderCommand(int id)
        {
            Id = id;
        }
    }
}

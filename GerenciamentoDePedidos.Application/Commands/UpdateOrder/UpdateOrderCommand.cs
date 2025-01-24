using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.API.Enum;
using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<ResultViewModel>
    {
        public int IdOrder { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Core.Entities;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.InsertOrder
{
    public class InsertOrderCommand : IRequest <ResultViewModel<int>>
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int IdClient { get; set; }
        public int IdUser { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public Order ToEntityOrder()
            => new Order(Product, Quantity, IdClient, IdUser, Price, TotalCost);
    }
}

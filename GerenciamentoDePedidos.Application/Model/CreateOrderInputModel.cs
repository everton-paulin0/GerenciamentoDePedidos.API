

using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class CreateOrderInputModel
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int IdClient{ get; set; }
        public int IdUser { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public Order ToEntityOrder()
            => new Order (Product, Quantity, IdClient, IdUser, Price, TotalCost);
                
    }
}

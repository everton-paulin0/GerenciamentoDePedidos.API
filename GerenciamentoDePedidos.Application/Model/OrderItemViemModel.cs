

using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class OrderItemViemModel
    {
        public OrderItemViemModel(int id, string product, int quantity, double price, double totalCost)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            Price = price;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

        public static OrderItemViemModel FromEntityOrder(Order order)
            => new OrderItemViemModel(order.Id, order.Product, order.Quantity, order.Price, order.TotalCost);
    }
}

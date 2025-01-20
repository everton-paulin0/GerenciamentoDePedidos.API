using GerenciamentoDePedidos.API.Enum;

namespace GerenciamentoDePedidos.API.Entities
{
    public class Order
    {
        public string Products { get; set; }
        public int Quantity { get; set; }
        public Description Description { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public OrderStatus Status { get; set; }
    }
}

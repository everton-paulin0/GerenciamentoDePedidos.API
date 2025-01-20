using GerenciamentoDePedidos.API.Entities;
using GerenciamentoDePedidos.API.Enum;

namespace GerenciamentoDePedidos.API.Model
{
    public class CreateOrderInputModel
    {
        public string Products { get; set; }
        public int Quantity { get; set; }
        public int IdClient{ get; set; }
        public int IdSeller { get; set; }
        public Description Description { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public OrderStatus Status { get; set; }
    }
}

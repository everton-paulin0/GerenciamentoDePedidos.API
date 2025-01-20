using GerenciamentoDePedidos.API.Entities;
using GerenciamentoDePedidos.API.Enum;

namespace GerenciamentoDePedidos.API.Model
{
    public class UpdateorderInputModel
    {
        public int IdOrder { get; set; }
        public string Products { get; set; }
        public int Quantity { get; set; }
        public Description Description { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public OrderStatus Status { get; set; }
    }
}

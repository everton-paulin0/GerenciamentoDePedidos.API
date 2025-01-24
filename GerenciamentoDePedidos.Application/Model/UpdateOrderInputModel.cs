
using GerenciamentoDePedidos.Core.Enum;

namespace GerenciamentoDePedidos.Application.Model
{
    public class UpdateorderInputModel
    {
        public int IdOrder { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }        
        public double Price { get; set; }
        public double TotalCost { get; set; }
        
    }
}

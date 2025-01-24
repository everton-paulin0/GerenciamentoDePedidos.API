using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string product, int quantity, int idClient, int idUser, double price, double totalCost, List<Description> comments)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            IdClient = idClient;            
            IdUser = idUser;            
            Price = price;
            TotalCost = totalCost;

            //Comments = comments.Select(c=> c.Content).ToList(); 
            Comments = [];


        }

        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int IdClient { get; set; }        
        public int IdUser { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public List<string> Comments { get; set; }

        public static OrderViewModel FromEntityOrder(Order entity)
            => new (entity.Id, entity.Product, entity.Quantity, entity.IdClient, entity.IdUser, entity.Price, entity.TotalCost, entity.Comments);
        
    }
}

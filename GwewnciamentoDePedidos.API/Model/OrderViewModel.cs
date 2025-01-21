using GerenciamentoDePedidos.API.Entities;

namespace GerenciamentoDePedidos.API.Model
{
    public class OrderViewModel
    {
        public OrderViewModel(int id, string product, int quantity, int idClient, string clientName, int idUser, string userName, double price, double totalCost, List<Description> comments)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            IdClient = idClient;
            ClientName = clientName;
            IdUser = idUser;
            UserName = userName;
            Price = price;
            TotalCost = totalCost;

            Comments = comments.Select(c=> c.Content).ToList(); 


        }

        public int Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int IdClient { get; set; }
        public string ClientName { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }
        public List<string> Comments { get; set; }
    }
}

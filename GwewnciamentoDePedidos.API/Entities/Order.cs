using System.Net.Sockets;
using GerenciamentoDePedidos.API.Enum;

namespace GerenciamentoDePedidos.API.Entities
{
    public class Order:BaseEntities
    {
        public Order()
        {
            
        }
        public Order(string product, int quantity, int idClient, int idUser,  double price, double totalCost, OrderStatus status, List<Description> comments):base()
        {
            Product = product;
            Quantity = quantity;
            IdClient = idClient;
            IdUser = idUser;
            Price = price;
            TotalCost = totalCost;
            Status = OrderStatus.Started;
            Comments = [];
        }

        public string Product { get; set; }
        public int Quantity { get; set; }
        public int IdClient { get; set; }        
        public User Client { get; set; }
        public int IdUser { get; set; }
        public User UserName { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }        
        public OrderStatus Status { get; set; }
        public List<Description> Comments { get; set; }

        public void Update(string product, int quantity, double price, double totalCost , string status)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
            TotalCost = totalCost;
        }
    }
}

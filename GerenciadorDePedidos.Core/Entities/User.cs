using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace GerenciamentoDePedidos.Core.Entities
{
    public class User: BaseEntities
    {
        public User()
        {
            
        }
        public User(string userName, string emailAddress, long docNumber, int idOrder):base()
        {
            UserName = userName;
            EmailAddress = emailAddress;
            DocNumber = docNumber;
            IdOrder = idOrder;
            IsActive = true;

            OwnedOrders = [];
            SellerOrders = [];
            Comments = [];
        }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }
        [NotMapped]
        public int IdOrder { get; set; }
        [NotMapped]
        public bool IsActive { get; set; }
        public List<Order>  OwnedOrders{ get; set; }
        [NotMapped]
        public List<Order> SellerOrders { get; set; }
        [NotMapped]
        public List<Description> Comments { get; set; }
        

        public void UpdateUser(string userName, string emailAddress, long docNumber)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            DocNumber = docNumber;
            UpdatedAt = DateTime.Now;
        }
    }
}

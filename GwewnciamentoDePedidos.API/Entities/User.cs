namespace GerenciamentoDePedidos.API.Entities
{
    public class User: BaseEntities
    {
        public User(string userName, string emailAddress, long docNumber, int idOrder, int idDescription, bool isActive):base()
        {
            UserName = userName;
            EmailAddress = emailAddress;
            DocNumber = docNumber;
            IdOrder = idOrder;
            IdDescription = idDescription;
            IsActive = isActive;

            OwnedOrders = [];
            SellerOrders = [];
            Comments = [];
        }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }
        public int IdOrder { get; set; }        
        public int IdDescription { get; set; }
        public bool IsActive { get; set; }
        public List<Order>  OwnedOrders{ get; set; }
        public List<Order> SellerOrders { get; set; }
        public List<Description> Comments { get; set; }
    }
}

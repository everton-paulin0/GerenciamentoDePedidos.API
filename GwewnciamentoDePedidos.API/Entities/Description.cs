namespace GerenciamentoDePedidos.API.Entities
{
    public class Description
    {
        public Description(string content, int idOrder, int idUser)
        {
            Content = content;
            IdOrder = idOrder;
            IdUser = idUser;
        }

        public string Content { get; set; }
        public int IdOrder { get; set; }
        public User Order { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }

    }
}

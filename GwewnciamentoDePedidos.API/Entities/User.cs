namespace GerenciamentoDePedidos.API.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }
        public int IdOrder { get; set; }
        public int IdDescription { get; set; }
        public bool IsActive { get; set; }
    }
}

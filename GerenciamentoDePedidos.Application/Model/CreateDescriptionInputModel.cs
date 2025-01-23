namespace GerenciamentoDePedidos.Application.Model
{
    public class CreateDescriptionInputModel
    {
        public string Content { get; set; }
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
    }
}

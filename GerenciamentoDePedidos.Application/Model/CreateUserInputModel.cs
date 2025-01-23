

using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class CreateUserInputModel
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }
        public int IdOrder { get; set; }
        public User ToEntityUser()
            => new User (UserName, EmailAddress, DocNumber, IdOrder);

    }
}

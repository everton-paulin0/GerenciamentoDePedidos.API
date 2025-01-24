

using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class UserItemViewModel
    {
        public UserItemViewModel(int id, string userName, string emailAddress, long docNumber)
        {
            Id = id;
            UserName = userName;
            EmailAddress = emailAddress;
            DocNumber = docNumber;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }

        public static UserItemViewModel FromEntityUser(User user)
            => new UserItemViewModel(user.Id, user.UserName, user.EmailAddress, user.DocNumber);
    }

}

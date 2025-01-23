

using GerenciamentoDePedidos.Core.Entities;

namespace GerenciamentoDePedidos.Application.Model
{
    public class UserViewModel
    {
        public UserViewModel(string userName, string emailAddress, long docNumber)
        {
            UserName = userName;
            EmailAddress = emailAddress;
            DocNumber = docNumber;
        }

        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public long DocNumber { get; set; }

        public static UserViewModel FromEntityUser(User user)
        {
            return new UserViewModel (user.UserName, user.EmailAddress, user.DocNumber);
        }
    }
}

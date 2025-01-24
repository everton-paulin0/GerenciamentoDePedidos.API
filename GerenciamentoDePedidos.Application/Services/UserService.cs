using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using GerenciamentoDePedidos.Infrastruture.Persistence;

namespace GerenciamentoDePedidos.Application.Services
{
   public class UserService : IUserService
    {
        private readonly GerenciamentoDbContext _context;
        public UserService(GerenciamentoDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<UserViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();
            _context.Orders.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<UserItemViewModel>> GetAll(string search = "")
        {
            var users = _context.Users.Where(o => !o.IsDeleted && (search == "" || o.UserName.Contains(search)))
                .ToList();

            var model = users.Select(UserItemViewModel.FromEntityUser).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Sucess(model);
        }

        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Pedido não existe");
            }

            var model = UserViewModel.FromEntityUser(user);

            return ResultViewModel<UserViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateUserInputModel model)
        {
            var user = model.ToEntityUser();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(user.Id);
        }

        public ResultViewModel Update(UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == model.IdUser);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Pedido não existe");
            }

            user.UpdateUser(model.UserName, model.EmailAddress, model.DocNumber);

            _context.Users.Update(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}

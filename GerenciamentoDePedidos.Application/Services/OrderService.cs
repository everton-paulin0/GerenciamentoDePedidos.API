using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Application.Services.Interfaces;
using GerenciamentoDePedidos.Core.Entities;
using GerenciamentoDePedidos.Infrastruture.Persistence;

namespace GerenciamentoDePedidos.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly GerenciamentoDbContext _context;
        public OrderService(GerenciamentoDbContext context)
        {
            _context = context;
        }
        public ResultViewModel Delete(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.SetAsDeleted();
            _context.Orders.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();

        }

        public ResultViewModel<List<OrderItemViemModel>> GetAll(string search = "")
        {
            var orders = _context.Orders.Where(o => !o.IsDeleted && (search == "" || o.Product.Contains(search)))
                .ToList();

            var model = orders.Select(OrderItemViemModel.FromEntityOrder).ToList();


            return ResultViewModel<List<OrderItemViemModel>>.Sucess(model);
        }

        public ResultViewModel<OrderViewModel> GetById(int id)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            var model = OrderViewModel.FromEntityOrder(order);

            return ResultViewModel<OrderViewModel>.Sucess(model);
        }

        public ResultViewModel<int> Insert(CreateOrderInputModel model)
        {
            var order = model.ToEntityOrder();

            _context.Orders.Add(order);
            _context.SaveChanges();

            return ResultViewModel<int>.Sucess(order.Id);
        }

        public ResultViewModel InsertDescription(int id, CreateDescriptionInputModel model)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == id);

            if (order is null)
            {
                return ResultViewModel<CreateDescriptionInputModel>.Error("Pedido não existe");
            }

            var comment = new Description(model.Content, model.IdOrder, model.IdUser);

            _context.Descriptions.Add(comment);
            _context.SaveChanges();

            return ResultViewModel<CreateDescriptionInputModel>.Sucess(model);
        }

        public ResultViewModel Update(UpdateorderInputModel model)
        {
            var order = _context.Orders.SingleOrDefault(p => p.Id == model.IdOrder);

            if (order is null)
            {
                return ResultViewModel<OrderViewModel>.Error("Pedido não existe");
            }

            order.Update(model.Product, model.Quantity, model.Price, model.TotalCost);

            _context.Orders.Update(order);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}

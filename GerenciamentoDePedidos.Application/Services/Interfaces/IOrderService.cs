using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;

namespace GerenciamentoDePedidos.Application.Services.Interfaces
{
    public interface IOrderService
    {
        ResultViewModel<List<OrderItemViemModel>> GetAll(string Search = "");
        ResultViewModel<OrderViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateOrderInputModel model);
        ResultViewModel Update(UpdateorderInputModel model);
        ResultViewModel Delete(int id);
        ResultViewModel InsertDescription(int id, CreateDescriptionInputModel model);

    }
}

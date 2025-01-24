using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;

namespace GerenciamentoDePedidos.Application.Services.Interfaces
{
    public interface IUserService
    {
        
        ResultViewModel<List<UserItemViewModel>> GetAll(string Search = "");
        ResultViewModel<UserViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateUserInputModel model);
        ResultViewModel Update(UpdateUserInputModel model);
        ResultViewModel Delete(int id);
        
    }
}

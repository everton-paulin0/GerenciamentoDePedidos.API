using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDePedidos.Application.Model;
using MediatR;

namespace GerenciamentoDePedidos.Application.Commands.InsertComment
{
    public class InsertCommentCommand : IRequest<ResultViewModel>
    {
        public string Content { get; set; }
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
    }
}

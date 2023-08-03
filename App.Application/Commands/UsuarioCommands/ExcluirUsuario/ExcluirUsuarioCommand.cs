using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Commands.UsuarioCommands.ExcluirUsuario
{
    public class ExcluirUsuarioCommand : IRequest<Unit>
    {
        public ExcluirUsuarioCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}

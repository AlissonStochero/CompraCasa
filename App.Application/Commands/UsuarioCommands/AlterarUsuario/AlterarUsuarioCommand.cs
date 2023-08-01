using App.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Commands.UsuarioCommands.AlterarUsuario
{
    public class AlterarUsuarioCommand : IRequest<Unit>
    {
        public AlterarUsuarioCommand(Guid id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}

using App.Application.Commands.UsuarioCommands.CriarUsuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Validators
{
    public class CriarUsuarioCommandValidador : AbstractValidator<CriarUsuarioCommand>
    {
        public CriarUsuarioCommandValidador()
        {
            RuleFor(x => x.Nome).Length(10, 100).WithMessage("Informe o nome completo.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Endereço de e-mail invalido.");
            RuleFor(x => x.Senha).NotEmpty().NotNull().WithMessage("Senha é invalida.");
        }
    }
}

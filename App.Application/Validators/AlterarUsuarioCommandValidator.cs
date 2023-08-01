using App.Application.Commands.UsuarioCommands.AlterarUsuario;
using FluentValidation;

namespace App.Application.Validators
{
    public class AlterarUsuarioCommandValidator : AbstractValidator<AlterarUsuarioCommand>
    {
        public AlterarUsuarioCommandValidator()
        {
            RuleFor(x => x.Nome).Length(10, 100).WithMessage("Informe o nome completo.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Endereço de e-mail invalido.");
        }
    }
}

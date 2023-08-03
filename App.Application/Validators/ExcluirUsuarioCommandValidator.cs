using App.Application.Commands.UsuarioCommands.ExcluirUsuario;
using FluentValidation;

namespace App.Application.Validators
{
    public class ExcluirUsuarioCommandValidator : AbstractValidator<ExcluirUsuarioCommand>
    {
        public ExcluirUsuarioCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull()
            .WithMessage("O campo Id deve ser um ID válido.");
        }
    }
}

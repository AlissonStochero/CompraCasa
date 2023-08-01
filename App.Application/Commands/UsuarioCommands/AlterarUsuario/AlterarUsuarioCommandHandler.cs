using App.Domain.Repositories;
using MediatR;

namespace App.Application.Commands.UsuarioCommands.AlterarUsuario
{
    public class AlterarUsuarioCommandHandler : IRequestHandler<AlterarUsuarioCommand, Unit>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public AlterarUsuarioCommandHandler(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }
        public async Task<Unit> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await usuarioRepository.GetUsuarioByIdAsync(request.Id);

            if(usuario is null)
                throw new ArgumentException("Usuário não encontrado.");

            usuario.Update(request.Nome, request.Email);
            await usuarioRepository.UpdateUsuarioAsync(usuario);
            return Unit.Value;
        }
    }
}

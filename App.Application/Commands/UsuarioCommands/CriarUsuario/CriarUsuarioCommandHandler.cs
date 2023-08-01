using App.Domain.Entities;
using App.Domain.Repositories;
using App.Infrastructure.Persistence;
using MediatR;

namespace App.Application.Commands.UsuarioCommands.CriarUsuario;

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Usuario>
{
    private readonly IUsuarioRepository usuarioRepository;
    public CriarUsuarioCommandHandler(IUsuarioRepository _usuarioRepository)
    {
        usuarioRepository = _usuarioRepository;
    }
    public async Task<Usuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(request.Nome, request.Email, request.Senha);
        var usuarioCadastrado = await usuarioRepository.CreateUsuarioAsync(usuario);
        return new Usuario(usuarioCadastrado);
    }
}

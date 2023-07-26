using App.Domain.Entities;
using App.Infrastructure.Persistence;
using MediatR;

namespace App.Application.Commands.UsuarioCommands.CriarUsuario;

public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, Usuario>
{
    private readonly AppDbContext appDbContext;
    public CriarUsuarioCommandHandler(AppDbContext _appDbContext)
    {
        appDbContext = _appDbContext;
    }
    public async Task<Usuario> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario(request.Nome, request.Email, request.Senha);
        var usuarioCadastrado = await appDbContext.Usuarios.AddAsync(usuario);
        _ = await appDbContext.SaveChangesAsync();
        return usuario;
    }
}

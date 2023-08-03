using App.Domain.Repositories;
using MediatR;
using System.Data;

namespace App.Application.Commands.UsuarioCommands.ExcluirUsuario;

public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
{
    private readonly IUsuarioRepository usuarioRepository;
    public ExcluirUsuarioCommandHandler(IUsuarioRepository _usuarioRepository)
    {
        usuarioRepository = _usuarioRepository;            
    }
    public async Task<Unit> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
    {
        await VerificacoesExcluirUsuario(request);

        await usuarioRepository.DeleteUsuarioAsync(request.Id);
        return Unit.Value;
    }
    private async Task<bool> VerificaUsuarioExiste(ExcluirUsuarioCommand request)
    {
        var usuario = await usuarioRepository.GetUsuarioByIdAsync(request.Id);
        return usuario is null;
    }
    private async Task VerificacoesExcluirUsuario(ExcluirUsuarioCommand request)
    {
        if(await VerificaUsuarioExiste(request))
        {
            throw new DeletedRowInaccessibleException("Usuario inexistente.");
        }
    }
}

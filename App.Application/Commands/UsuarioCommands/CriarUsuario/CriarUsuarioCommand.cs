using App.Domain.Entities;
using MediatR;

namespace App.Application.Commands.UsuarioCommands.CriarUsuario;

public class CriarUsuarioCommand : IRequest<Usuario>
{
    public CriarUsuarioCommand(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        CriadoEm = DateTime.Now;
    }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public DateTime CriadoEm { get; private set; }
}

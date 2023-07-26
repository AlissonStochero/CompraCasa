namespace App.Domain.Entities;

public class Usuario : BaseEntity
{
    public Usuario(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        CriadoEm = DateTime.Now;
        AlteradoEm = DateTime.Now;
    }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
}

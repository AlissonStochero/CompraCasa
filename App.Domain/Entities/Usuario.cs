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
    public Usuario(Usuario usuario)
    {
        Id = usuario.Id;
        Nome = usuario.Nome;
        Email = usuario.Email;
        Senha = string.Empty;
        CriadoEm = usuario.CriadoEm;
        AlteradoEm = usuario.AlteradoEm;
    }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public void Update(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}

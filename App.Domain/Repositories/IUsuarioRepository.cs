using App.Domain.Entities;

namespace App.Domain.Repositories;

public interface IUsuarioRepository
{
    public Task<Usuario> CreateUsuarioAsync(Usuario usuario);

    // READ
    public Task<Usuario> GetUsuarioByIdAsync(int id);

    public Task<Usuario> GetUsuarioByEmailAsync(string email);

    public Task<List<Usuario>> GetAllUsuariosAsync();

    // UPDATE
    public Task UpdateUsuarioAsync(Usuario usuario);

    // DELETE
    public Task DeleteUsuarioAsync(int id);
}

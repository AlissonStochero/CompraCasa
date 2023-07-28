using App.Domain.Entities;
using App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
    {
        var usuariocriado = await _context.Usuarios.AddAsync(usuario);
        _ = await _context.SaveChangesAsync();
        return usuariocriado.Entity;
    }

    // READ
    public async Task<Usuario> GetUsuarioByIdAsync(int id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    public async Task<Usuario> GetUsuarioByEmailAsync(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<List<Usuario>> GetAllUsuariosAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    // UPDATE
    public async Task UpdateUsuarioAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteUsuarioAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}

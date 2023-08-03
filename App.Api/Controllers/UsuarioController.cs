using App.Application.Commands.UsuarioCommands.AlterarUsuario;
using App.Application.Commands.UsuarioCommands.CriarUsuario;
using App.Application.Commands.UsuarioCommands.ExcluirUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand usuario)
    {
        return CreatedAtAction(nameof(CriarUsuario), await _mediator.Send(usuario));
    }
    [HttpPut]
    public async Task<IActionResult> AlterarUsuario([FromBody] AlterarUsuarioCommand usuario)
    {
        try
        {
            return CreatedAtAction(nameof(AlterarUsuario), await _mediator.Send(usuario));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> ExcluirUsuario([FromBody] ExcluirUsuarioCommand usuario)
    {
        try
        {
            await _mediator.Send(usuario);
            return Ok();
        }
        catch (DeletedRowInaccessibleException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

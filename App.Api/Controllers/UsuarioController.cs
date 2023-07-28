using App.Application.Commands.UsuarioCommands.CriarUsuario;
using App.Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}

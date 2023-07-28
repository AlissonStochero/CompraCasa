using App.Api.Filters;
using App.Application.Commands.UsuarioCommands.CriarUsuario;
using App.Application.Validators;
using App.Domain.Repositories;
using App.Infrastructure.Persistence;
using App.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(c =>
    {
        c.Filters.Add(typeof(ValidationFilter));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompraCasa API", Version = "v1" });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CriarUsuarioCommand).Assembly);
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("CompraCasaDb")
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//builder.Services
//    .AddValidatorsFromAssemblyContaining<CriarUsuarioCommandValidador>()
//    .AddFluentValidationAutoValidation();

builder.Services.AddTransient<IValidator<CriarUsuarioCommand>, CriarUsuarioCommandValidador>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

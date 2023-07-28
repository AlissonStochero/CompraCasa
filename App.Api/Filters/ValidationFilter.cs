using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using FluentValidation.AspNetCore;

namespace App.Api.Filters;

public class ValidationFilter : IAsyncActionFilter
{
    private readonly IServiceProvider serviceProvider;
    private readonly ProblemDetailsFactory problernDetailsFactory;
    public ValidationFilter(IServiceProvider _serviceProvider, ProblemDetailsFactory _problernDetailsFactory)
    {
        serviceProvider = _serviceProvider;
        problernDetailsFactory = _problernDetailsFactory;
    }
    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public async Task OnActionExecutingAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            context.Result = new BadRequestObjectResult(messages);
        }
        await next();
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var parameter in context.ActionDescriptor.Parameters)
        {
            if (parameter.BindingInfo.BindingSource == BindingSource.Body || (parameter.BindingInfo.BindingSource == BindingSource.Query && parameter.ParameterType.IsClass))
            {
                var validator = serviceProvider.GetService(typeof(IValidator<>).MakeGenericType(parameter.ParameterType)) as IValidator;
                if(validator != null)
                {
                    var subject = context.ActionArguments[parameter.Name];
                    var result = await validator.ValidateAsync(new ValidationContext<object>(subject), context.HttpContext.RequestAborted);
                    if(!result.IsValid)
                    {
                        result.AddToModelState(context.ModelState, null);
                    }
                }
            }
        }
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState
                .SelectMany(ms => ms.Value.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            context.Result = new BadRequestObjectResult(messages);
        }
        else
        {
            await next();
        }
    }
}

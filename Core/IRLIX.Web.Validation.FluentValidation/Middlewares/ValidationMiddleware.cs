using FluentValidation;
using FluentValidation.Results;
using IRLIX.Core.Serializers;
using IRLIX.Web.Validation.FluentValidation.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Text;

namespace IRLIX.Web.Validation.FluentValidation.Middlewares;

public class ValidationMiddleware(
    ISerializer<string> serializer
    ) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext context,
        RequestDelegate next)
    {
        await ValidateAsync(context, context.RequestAborted);

        await next(context);
    }

    private async ValueTask ValidateAsync(
        HttpContext context,
        CancellationToken ct)
    {
        var endpoint = context.GetEndpoint();
        var parameters = endpoint?.Metadata.GetMetadata<ControllerActionDescriptor>()?.Parameters;
        if (parameters == null)
        {
            return;
        }

        var validationResults = new List<ValidationResult>();

        foreach (var parameter in parameters)
        {
            var modelType = parameter.ParameterType;
            var validatorType = typeof(IValidator<>).MakeGenericType(modelType);
            if (context.RequestServices.GetService(validatorType) is not IValidator validator)
            {
                continue;
            }

            object model;

            if (parameter.BindingInfo?.BindingSource?.Id == Consts.RequestType.Body)
            {
                context.Request.EnableBuffering();
                using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
                var body = await reader.ReadToEndAsync(ct);
                context.Request.Body.Position = 0;

                model = serializer.ForceDeserialize(body, modelType);
            }
            else if (parameter.BindingInfo?.BindingSource?.Id == Consts.RequestType.Query)
            {
                var query = context.Request.Query.ToDictionary(q => q.Key, q => q.Value.ToString());
                var queryStr = serializer.Serialize(query);

                model = serializer.ForceDeserialize(queryStr, modelType);
            }
            else
            {
                continue;
            }

            var validationContext = new ValidationContext<object>(model);
            var validationResult = validator.Validate(validationContext);

            if (validationResult.IsValid)
            {
                continue;
            }

            validationResults.Add(validationResult);
        }

        BadValidationException.ThrowWhenNotEmpty(validationResults);
    }
}

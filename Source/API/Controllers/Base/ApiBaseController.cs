using API.Api.Responses;
using Domain.Extensions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Controllers.Base;

[Route("/api/[controller]")]
public class ApiBaseController(IServiceProvider serviceProvider) : ControllerBase
{
    protected async Task<(bool IsValid, IActionResult? Response)> ValidateRequestAsync<TRequest>(TRequest request)
        where TRequest : class
    {
        if (!ModelState.IsValid)
        {
            return (false, CreateModelStateErrorResponse());
        }

        var validator = serviceProvider.GetRequiredService<IValidator<TRequest>>();

        var result = await validator.ValidateAsync(request);

        return result.IsValid ? (true, null) : (false, CreateValidationErrorResponse(result));
    }

    private BadRequestObjectResult CreateModelStateErrorResponse()
    {
        var response = new ApiErrorResponse();

        foreach (var key in ModelState.Keys)
        {
            var property = ModelState[key];

            if (property?.ValidationState == ModelValidationState.Invalid)
            {
                response.AddError(
                    key,
                    $"Invalid value '{property.AttemptedValue}' for property '{key.ReplaceWithAzRegex(" $0")}'",
                    "InvalidValue");
            }
        }
        
        return new BadRequestObjectResult(response);
    }

    private static BadRequestObjectResult CreateValidationErrorResponse(ValidationResult validationResult)
    {
        var response = new ApiErrorResponse();

        validationResult.Errors.ForEach(x => response.AddError(x.PropertyName, x.ErrorMessage, x.ErrorCode));

        return new BadRequestObjectResult(response);
    }
}
using API.Api.Requests;
using API.Controllers.Base;
using Application.Services.Users.Create;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class UsersController(
    IServiceProvider serviceProvider,
    ICreateUser createUser
) : ApiBaseController(serviceProvider)
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var validationResult = await ValidateRequestAsync(request);

        //TODO: Verificar nullable referency
        if (!validationResult.IsValid)
            return validationResult.Response!;

        var result = await createUser.CreateUserAsync(CreateUserRequest.ToCreateUserDto(request));
        
        return result.Match<IActionResult>(
            guid => CreatedAtAction(nameof(CreateUser), new { guid }),
            validation => BadRequest(validation.Notifications),
            conflict => Conflict(conflict.Notifications));
    }
}
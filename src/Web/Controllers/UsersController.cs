using Microsoft.AspNetCore.Mvc;
using service_template.Application.DTOs;
using service_template.Application.UseCases;

namespace service_template.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(CreateUserUseCase useCase) : ControllerBase
{
    [HttpPost("create")] // добавляем конкретный сегмент маршрута
    [ProducesResponseType(typeof(CreateUserRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        await useCase.ExecuteAsync(request.Username, request.Email);
        return Ok(new { message = "User created successfully" });
    }
}
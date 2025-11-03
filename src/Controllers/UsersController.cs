using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using service_template.Data;
using service_template.Models;
using service_template.Services;

namespace service_template.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(AppDbContext db, IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await db.Users.ToListAsync();
        return Ok(users);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await db.Users.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        db.Users.Add(user);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
}
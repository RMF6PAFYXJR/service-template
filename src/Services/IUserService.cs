using Microsoft.EntityFrameworkCore;
using service_template.Models;

namespace service_template.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
}


public class UserService(Data.AppDbContext db) : IUserService
{
    public async Task<User?> GetByIdAsync(int id) => await db.Users.FindAsync(id);
}
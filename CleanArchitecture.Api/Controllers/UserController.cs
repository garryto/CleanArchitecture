using System;
using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly CreateUserUseCase _createUserCase;
    private readonly IUserRepository _userRepository;

    public UserController(CreateUserUseCase createUserCase, IUserRepository userRepository)
    {
        _createUserCase = createUserCase;
        _userRepository = userRepository;
    }

   /* public static readonly List<User> Users = new()
{
    new User {Id = Guid.NewGuid(), Name = "Juan Perez", Email="juanp@example.com"},
    new User {Id = Guid.NewGuid(), Name="Ana Lopez", Email="anal@example.com"}
};*/

    [HttpPost]
    public async Task<IActionResult> CreateUser(User User)
    {
        try
        {
            var user = await _createUserCase.Execute(User.Name.ToString(), User.Email.ToString());
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userRepository.GetAll();
        return Ok(users);
    }
}

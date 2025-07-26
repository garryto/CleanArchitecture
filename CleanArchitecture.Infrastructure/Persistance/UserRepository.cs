using System;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public async Task<IEnumerable<User>> GetAll()
    {
        return await Task.FromResult(_users);
    }

    public async Task Save(User user)
    {
        _users.Add(user);
        await Task.CompletedTask;
    }
}

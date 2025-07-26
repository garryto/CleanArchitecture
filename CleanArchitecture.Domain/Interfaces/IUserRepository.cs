using System;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IUserRepository
{
    Task Save(User user);

    Task<IEnumerable<User>> GetAll();

}

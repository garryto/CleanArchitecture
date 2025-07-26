using System;

namespace CleanArchitecture.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        if (!email.Contains("@"))
        {
            throw new ArgumentException("Email no valido.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Email = email;  
    }

}

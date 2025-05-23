using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserPersistence : IUserRepository
{
    private readonly List<User> _users = new();

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}

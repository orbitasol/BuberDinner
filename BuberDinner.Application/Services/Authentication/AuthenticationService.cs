using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        // Validate that the user don't already exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
        }

        // Create user (generate a unique ID)
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password // In a real application, you should hash the password
        };

        _userRepository.Add(user);

        // Create a JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        // Validate that the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // Validate that the password is correct (in a real application, you should hash the password and compare)
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // Create a JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}
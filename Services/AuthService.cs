using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeManagement.Data;
using TraineeManagement.Exceptions;



namespace TraineeManagement.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _databaseContext;
    private readonly JwtService _jwtService;
    private readonly ILogger<AuthService> _logger;


    public AuthService(AppDbContext appDbContext, JwtService jwtService, ILogger<AuthService> logger)
    {
        _databaseContext = appDbContext;
        _jwtService = jwtService;
        _logger = logger;
    }
    
    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        User? user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);
        if(user == null)
        {
            _logger.LogInformation("User not found with username: {username}", loginRequest.UserName);
            throw new UnauthorizedException($"Invalid username or password.");
        }
        bool res = PasswordHasherService.VerifyPassword(loginRequest.PassWord, user.PasswordHash);
        if (!res)
        {
            _logger.LogInformation("Invalid username or password: {username}", loginRequest.UserName);
            throw new UnauthorizedException($"Invalid username or password.");
        }
        string token = _jwtService.GenerateToken(user.Id, user.UserName, user.Role);
        return new LoginResponse
        {
            Token = token,
            ExpiresIn = 60 * 60,
            User = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            }
        };
    }


    
}
using TraineeManagement.Models;
using TraineeManagement.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TraineeManagement.Data;



namespace TraineeManagement.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _databaseContext;
    private readonly JwtService _jwtService;

    public AuthService(AppDbContext appDbContext, JwtService jwtService)
    {
        _databaseContext = appDbContext;
        _jwtService = jwtService;
    }
    
    public async Task<LoginResponse?> Login(LoginRequest loginRequest)
    {
        User? user = await _databaseContext.Users.FirstOrDefaultAsync(u => u.UserName == loginRequest.UserName);
        if(user == null) return null;
        bool res = PasswordHasherService.VerifyPassword(loginRequest.PassWord, user.PasswordHash);
        if(!res)return null;
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
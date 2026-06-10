using TraineeManagement.Models;
using TraineeManagement.Dtos;

namespace TraineeManagement.Services;


public interface IAuthService
{
    public Task<LoginResponse?> Login(LoginRequest loginRequest);
}
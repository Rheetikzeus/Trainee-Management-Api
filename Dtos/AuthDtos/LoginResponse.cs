using TraineeManagement.Models;
namespace TraineeManagement.Dtos;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public int ExpiresIn { get; set; }
    public UserResponse User {get; set;} = null!;
}
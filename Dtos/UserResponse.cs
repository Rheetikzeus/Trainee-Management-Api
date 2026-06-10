using TraineeManagement.Models;
namespace TraineeManagement.Dtos;

public class UserResponse
{

    public int Id { get; set; }
    public string UserName { get; set; } = "";
    public string Role { get; set; } = "";

}
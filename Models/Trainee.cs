

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class Trainee
{
    private static int UId = 1;
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string TechStack { get; set; } ="";
    public string Status { get; set; } = "";
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public Trainee(TraineeCreateRequest traineeCreateRequest)
    {
        Id = UId;
        FirstName = traineeCreateRequest.FirstName;
        LastName = traineeCreateRequest.LastName;
        Email = traineeCreateRequest.Email;
        TechStack = traineeCreateRequest.TechStack;
        Status = traineeCreateRequest.Status;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
        UId = UId + 1;
    }

    public Trainee() {}


}
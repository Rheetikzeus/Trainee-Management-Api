
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class Trainee
{
    [Key]
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
        FirstName = traineeCreateRequest.FirstName;
        LastName = traineeCreateRequest.LastName;
        Email = traineeCreateRequest.Email;
        TechStack = traineeCreateRequest.TechStack;
        Status = traineeCreateRequest.Status;
        CreatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
        UpdatedDate = DateTime.UtcNow.ToUtcSecondPrecision();    
    }

    public Trainee() {}


}
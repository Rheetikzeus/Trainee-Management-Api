
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class Trainee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]   
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string TechStack { get; set; } =null!;

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
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
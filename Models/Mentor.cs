
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class Mentor
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
    [MaxLength(200)]
    public string Expertise { get; set; } = null!;

    [Required]
    public string Status { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

    public Mentor(MentorCreateRequest mentorCreateRequest)
    {
        FirstName = mentorCreateRequest.FirstName;
        LastName = mentorCreateRequest.LastName;
        Email = mentorCreateRequest.Email;
        Expertise = mentorCreateRequest.Expertise;
        Status = mentorCreateRequest.Status;
        CreatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
        UpdatedDate = DateTime.UtcNow.ToUtcSecondPrecision();
    }


    public Mentor() {}

}
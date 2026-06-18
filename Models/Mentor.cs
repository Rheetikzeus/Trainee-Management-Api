
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;
using TraineeManagement.Extensions;

namespace TraineeManagement.Models;

public class Mentor
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Expertise { get; set; } ="";
    public string Status { get; set; } = "";
    public DateTime CreatedDate { get; set; }
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
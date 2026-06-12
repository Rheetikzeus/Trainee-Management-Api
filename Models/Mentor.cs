
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

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
        DateTime dt = DateTime.Now;
        DateTime cleanDt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        CreatedDate = cleanDt;
        UpdatedDate = cleanDt;
    }


public Mentor() {}

}
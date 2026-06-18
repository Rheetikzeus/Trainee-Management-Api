using TraineeManagement.Models;
namespace TraineeManagement.Dtos;

public class MentorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Expertise { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public MentorResponse(Mentor mentor)
    {
        Id = mentor.Id;
        FirstName = mentor.FirstName;
        LastName = mentor.LastName;
        Email = mentor.Email;
        Expertise = mentor.Expertise;
        Status = mentor.Status;
        CreatedDate = mentor.CreatedDate;
        UpdatedDate = mentor.UpdatedDate;
    }


}
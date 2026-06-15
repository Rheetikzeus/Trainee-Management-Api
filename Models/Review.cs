
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class Review
{
    [Key]
    public int Id { get; set; }

    public int SubmissionId { get; set; }
    public int MentorId { get; set; }
    public string Feedback { get; set; } = "";
    public int Score { get; set; } 
    public string ReviewStatus { get; set; } = "";
    public DateTime ReviewedDate { get; set; }
    public Review(ReviewCreateRequest reviewCreateRequest)
    {
        SubmissionId = reviewCreateRequest.SubmissionId;
        Feedback = reviewCreateRequest.Feedback;
        Score = reviewCreateRequest.Score;
        ReviewStatus = reviewCreateRequest.ReviewStatus;
        ReviewedDate = reviewCreateRequest.ReviewedDate;
    }


public Review() {}

}
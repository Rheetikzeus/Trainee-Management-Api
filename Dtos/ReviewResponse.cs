
using System.ComponentModel.DataAnnotations;
using TraineeManagement.Models;


namespace TraineeManagement.Dtos;

public class ReviewResponse
{
    [Key]
    public int Id { get; set; }

    public int SubmissionId { get; set; }
    public int MentorId { get; set; }
    public string Feedback { get; set; } 
    public int Score { get; set; } 
    public string ReviewStatus { get; set; } 
    public DateTime ReviewedDate { get; set; }
    public ReviewResponse(Review review)
    {
        Id = review.Id;
        SubmissionId = review.SubmissionId;
        Feedback = review.Feedback;
        Score = review.Score;
        ReviewStatus = review.ReviewStatus;
        ReviewedDate = review.ReviewedDate;
    }



}
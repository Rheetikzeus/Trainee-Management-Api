
using System.ComponentModel.DataAnnotations;

using TraineeManagement.Dtos;

namespace TraineeManagement.Models;

public class Review
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int SubmissionId { get; set; }
    
    [Required]
    public int MentorId { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Feedback { get; set; } = null!;
    
    public int Score { get; set; } 
    
    [Required]
    public string ReviewStatus { get; set; } = null!;
    
    [Required]
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
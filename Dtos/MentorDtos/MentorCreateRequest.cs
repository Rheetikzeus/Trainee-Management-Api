using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;
using TraineeManagement.Models;

namespace TraineeManagement.Dtos;


public class MentorCreateRequest
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Expertise { get; set; } = null!;

    [Required]
    [AllowedValues([StringConstants.STATUS_ACTIVE, StringConstants.STATUS_INACTIVE], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = null!;
    
}
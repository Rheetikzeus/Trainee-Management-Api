using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class TraineeUpdateRequest
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
    public string TechStack { get; set; } = null!;

    [Required]
    [AllowedValues([StringConstants.STATUS_ACTIVE, StringConstants.STATUS_INACTIVE, StringConstants.STATUS_COMPLETED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = null!;
    
}
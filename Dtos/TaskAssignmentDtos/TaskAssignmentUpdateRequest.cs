using System.ComponentModel.DataAnnotations;
using TraineeManagement.Api.Constants;

namespace TraineeManagement.Dtos;


public class TaskAssignmentUpdateRequest
{

    [Required]
    [AllowedValues([StringConstants.STATUS_ASSIGNED, StringConstants.STATUS_IN_PROGRESS, StringConstants.STATUS_SUBMITTED, StringConstants.STATUS_REVIEWED, StringConstants.STATUS_COMPLETED], ErrorMessage = StringConstants.INVALID_STATUS_VALUE)]
    public string Status { get; set; } = "";

    
}
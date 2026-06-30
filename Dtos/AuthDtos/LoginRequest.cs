using System.ComponentModel.DataAnnotations;
using TraineeManagement.Models;

namespace TraineeManagement.Dtos;


public class LoginRequest
{
    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    public string PassWord { get; set; } = null!;
    
}
using System.ComponentModel.DataAnnotations;
using TraineeManagement.Models;

namespace TraineeManagement.Dtos;


public class LoginRequest
{
    [Required(ErrorMessage = "username is required.")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "password is required.")]
    public string PassWord { get; set; } = "";
    
}
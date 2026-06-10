using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } ="";
    [Required]
    public string Role { get; set; } = "";
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

}
using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string PasswordHash { get; set; } =null!;

    [Required]    
    public string Role { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public DateTime UpdatedDate { get; set; }

}
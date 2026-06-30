
using TraineeManagement.Dtos;
using System.ComponentModel.DataAnnotations;

namespace TraineeManagement.Models;

public class SubmissionFile
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int SubmissionId { get; set; }
    
    [Required]
    public string OriginalFileName { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string GeneratedStorageName {get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string ContentType { get; set; } = null!;
    
    [Required]
    public long Size { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string CheckSum { get; set; } = null!;
    
    [Required]
    public int UploadedBy { get; set; }
    
    [Required]
    public DateTime CreatedDate { get; set; }

    public SubmissionFile () {}

}
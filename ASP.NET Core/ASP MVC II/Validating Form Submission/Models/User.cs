using System.ComponentModel.DataAnnotations;
namespace Validating_Form_Submission.Models;
public class User
{
    [Required]
    [MinLength(4)]
    public string firstname { get; set; }

    [Required]
    [MinLength(4)]
    public string lastname { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int age{get;set;}

    [Required]
    [EmailAddress]
    public string email { get; set; }

    [Required]
    [MinLength(8)]
    public string password { get; set; }
}

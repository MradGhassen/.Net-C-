using System.ComponentModel.DataAnnotations;
namespace Dojo_Survey_with_Validation.Models;
public class Survey
{
    [Required]
    [MinLength(2)]
    public string? Name { get; set; }

    [Required]
    public string? Locations { get; set; }
    

    [Required]
    public string? Languages { get; set; }

    public string? Comments { get; set; }
}

#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models;


public class Dishe
{
    [Key]
    public int DisheId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Calories {get;set;}
    [Required]
    public int Tastiness {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    public int ChefId { get; set; }
    // Navigation property that lets us see the whole Chef
    public Chef? Chef { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;

}
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_Categories.Models;
public class Categories
{
    [Key]
    public int CategorieId { get; set; }
    [Required]
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Assossiations> Cat { get; set; } = new List<Assossiations>();
}
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_Categories.Models;
public class Products
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required] 
    public string Description { get; set; }
    [Required]
    public int Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Assossiations> Prod { get; set; } = new List<Assossiations>();

}
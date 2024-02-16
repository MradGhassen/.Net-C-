#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Products_and_Categories.Models;
public class Assossiations
{
    [Key]
    public int AssossiationId { get; set; }
    public int ProductId { get; set; }
    public Products? Products { get; set; }
    public int CategorieId { get; set; }
    public Categories? Categories { get; set; }
}
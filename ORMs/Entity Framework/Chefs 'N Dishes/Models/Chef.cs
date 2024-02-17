#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models;


public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string FirstName{ get; set; }
    [Required]
    public string LastName {get;set;}
    [Required]
    public DateTime DOB {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdateAt { get; set; } = DateTime.Now;
    public List<Dishe> DishesOwned { get; set; } = new List<Dishe>();

}
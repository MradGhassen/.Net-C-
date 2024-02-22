#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models;


public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required]
    public string WedderOne {get;set;}
    [Required]
    public string WedderTwo {get;set;}
    [Required]
    public DateTime Date {get;set;}
    [Required]
    public string Address {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // navigation properties
    public int UserId{get;set;} 
    public User? Guest {get;set;} 
    public List<Rsvp> UsersAsGuest { get; set; } = new List<Rsvp>();
}
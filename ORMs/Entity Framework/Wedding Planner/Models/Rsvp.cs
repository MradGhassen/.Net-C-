#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models;


public class Rsvp

{
    [Key]
    public int RsvpId { get; set; }
    [Required]
    public int WeddingId { get; set; }
    public Wedding? MyRsvps { get; set; }
    [Required]
    public int UserId { get; set; }
    public User? UsersAsGuest { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Login_and_Registration.Models;
public class LoginUser
{
    // No other fields!
    [Required]
    public string LoginEmail { get; set; }
    [Required]
    public string LoginPassword { get; set; } 
}
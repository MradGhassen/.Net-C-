#pragma warning disable CS8600
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Login_and_Registration.Models;
using Microsoft.AspNetCore.Identity;

namespace Login_and_Registration.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    public HomeController(MyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser LogUser)
    {
    if(ModelState.IsValid)
    {
        // If initial ModelState is valid, query for a user with provided email
        User userInDb = _context.Users.FirstOrDefault(u => u.Email == LogUser.LoginEmail);
        // If no user exists with provided email
        if(userInDb == null)
        {
            // Add an error to ModelState and return to View!
            ModelState.AddModelError("Email", "Invalid Email/Password");
            return View("Index");
        }
        HttpContext.Session.SetInt32("userId", userInDb.UserId);
        return RedirectToAction ("Success");
    }
    else
    {
        return View("Index");
    }
    }
    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
                if(_context.Users.Any(u => u.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "Email already in use!");
            return View("Index");
        }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser , newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }
    
    [HttpGet("success")]
    public IActionResult Success()
    {
        return View( );
    }
    [HttpGet("Clear")]
        public RedirectToActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
}

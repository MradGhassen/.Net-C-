#pragma warning disable CS8600
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // We passed the validation
            // we need to check if the email is unique
            if (_context.Users.Any(a => a.Email == newUser.Email))
            {
                // we have a problem. this user already has this email in DB
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");

            }
            // import Identity
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser LogUser)
    {
        if (ModelState.IsValid)
        {
            // step 1 : find their email and if we can't find it throw an error
            User userInDb = _context.Users.FirstOrDefault(a => a.Email == LogUser.LoginEmail);
            if (userInDb == null)
            {
                // there was no Email in the database
                ModelState.AddModelError("LoginEmail", "Invalid Login Attempt");
                return View("Index");
            }
            PasswordHasher<LoginUser> PasswordHasher = new PasswordHasher<LoginUser>();

            var result = PasswordHasher.VerifyHashedPassword(LogUser, userInDb.Password, LogUser.LoginPassword);
            if (result == 0)
            {
                // this is a problem, we did not have any match of your password 
                ModelState.AddModelError("LoginEmail", "Invalid Login Attempt");
                return View("Index");
            }
            HttpContext.Session.SetInt32("userId", userInDb.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");

        }
    }
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
            ViewBag.userId = HttpContext.Session.GetInt32("userId");
            ViewBag.AllWeddings = _context.Weddings.Include(c => c.UsersAsGuest).ToList();
        return View("Dashboard");
    }
    [HttpGet("AddWedding")]
    public IActionResult AddWedding()
    {
        return View();
    }
    [HttpGet("Weddings")]
    public IActionResult Weddings()
    {
            return View();
    }
    [HttpPost("Wedding/add")]
    public IActionResult AddNewWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("userId");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View("AddWedding");
    }
    [HttpGet("Wedding/{WeddingId}")]
    public IActionResult ShowWedding(int WeddingId)
    {
        Wedding WeddingDetails = _context.Weddings
            .Include(w => w.UsersAsGuest)
            .ThenInclude(u => u.UsersAsGuest)
            .FirstOrDefault(i=> i.WeddingId == WeddingId);
            return View(WeddingDetails);
    }
    
    [HttpGet("/AddRsvp/{weddingId}")]
    public IActionResult AddRsvp(int weddingId)
    {
        int? currentUserId = HttpContext.Session.GetInt32("userId");

        if (currentUserId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Index");
        }

        // Check if the user has already RSVP'd
        if (_context.Rsvps.Any(r => r.WeddingId == weddingId && r.UserId == currentUserId))
        {
            // The user has already RSVP'd, handle accordingly
            // Maybe show a message or redirect to a different page
        }
        else
        {
            // Add a new RSVP
            Rsvp newRsvp = new Rsvp { WeddingId = weddingId, UserId = (int)currentUserId };
            _context.Rsvps.Add(newRsvp);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }
    [HttpGet("/RemoveRsvp/{weddingId}")]
    public IActionResult RemoveRsvp(int weddingId)
    {
        int? currentUserId = HttpContext.Session.GetInt32("userId");

        if (currentUserId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Index");
        }

        // Find the existing RSVP
        Rsvp existingRsvp = _context.Rsvps.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == currentUserId);

        if (existingRsvp != null)
        {
            // Remove the existing RSVP
            _context.Rsvps.Remove(existingRsvp);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }
    [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding Delete = _context.Weddings.FirstOrDefault(i => i.WeddingId == id);
            _context.Remove(Delete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("Clear")]
    public RedirectToActionResult Clear()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

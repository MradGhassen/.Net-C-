using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers;

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
        ViewBag.AllChefs = _context.Chefs.Include(a => a.DishesOwned).ToList();
        return View();
    }
    [HttpGet("AddChef")]
    public IActionResult AddChef()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }
    [HttpPost("Chefs/add")]
    public IActionResult AddChefs(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("AddChef");
        }
        else
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("AddChef");
        }
    }
    [HttpGet("Dishes")]
    public IActionResult Dishes()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        ViewBag.AllDishes = _context.Dishes.Include(a => a.Chef).ToList();
        return View();
    }
    [HttpGet("AddDishe")]
    public IActionResult AddDishe()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View();
    }
    [HttpPost("Dishes/add")]
    public IActionResult AddDishes(Dishe newDishe)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDishe);
            _context.SaveChanges();
            return RedirectToAction("AddDishe");
        }
        else
        {
            ViewBag.AllChefs = _context.Chefs.ToList();

            return View("AddDishe");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    // here we can "inject" our context service into the constructor
    public HomeController(MyContext context)
    {
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
        {
            return View(_context.Dishes.OrderByDescending(d => d.CreatedAt));
        }
        [HttpGet("new")]
        public IActionResult New() => View();
        
        [HttpGet("{dishesId}")]
        public IActionResult Show(int dishesId)
        {
            Dishe model = _context.Dishes.FirstOrDefault(d => d.DishesId == dishesId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet("{dishesId}/edit")]
        public IActionResult Edit(int dishesId)
        {
            Dishe model = _context.Dishes.FirstOrDefault(d => d.DishesId == dishesId);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpPost("create")]
        public IActionResult Create(Dishe newDishe)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDishe);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpPost("{dishesId}/update")]
        public IActionResult Update(Dishe dishe, int dishesId)
        {
            Dishe toUpdate = _context.Dishes.FirstOrDefault(d => d.DishesId == dishesId);
            if(ModelState.IsValid)
            {
                toUpdate.Name = dishe.Name;
                toUpdate.Chef = dishe.Chef;
                toUpdate.Tastiness = dishe.Tastiness;
                toUpdate.Calories = dishe.Calories;
                toUpdate.Description = dishe.Description;
                toUpdate.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", dishe);
        }
        
        [HttpGet("{dishesId}/delete")]
        public IActionResult Delete(int dishesId)
        {
            Dishe toDelete = _context.Dishes.FirstOrDefault(d => d.DishesId == dishesId);
            if(toDelete == null)
                return RedirectToAction("Index");
            _context.Dishes.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products_and_Categories.Models;
using Microsoft.AspNetCore.Identity;

namespace Products_and_Categories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        //List<Products> AllProducts = _context.Products.ToList();
        return View();
    }
    [HttpGet("product/new")]
        public IActionResult AddProduct()
        {
            ViewBag.AllProducts=_context.Products.ToList();
            return View();
        }
    [HttpPost("Product/add")]
        public IActionResult Create(Products newProduct)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AllProducts=_context.Products.ToList();
                return View("AddProduct");
            }
        }
    [HttpGet("Product/{ProductId}")]
    public IActionResult ShowProducts(int ProductId)
        {
        ViewBag.AllProducts = _context.Products.ToList();
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }
    [HttpPost("ProdCat/add")]
    public IActionResult AddProdCat(Assossiations newProdCat)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProdCat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddProduct");
    }
    [HttpGet("Categorie/new")]
        public IActionResult AddCategories()
        {
            ViewBag.AllCategories=_context.Categories.ToList();
            return View();
        }
    [HttpPost("Categories/add")]
        public IActionResult Create(Categories newCategorie)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(newCategorie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AllCategories=_context.Categories.ToList();
                return View("AddCategories");
            }
        }
    [HttpGet("Categories/{CategorieId}")]
    public IActionResult ShowCategories(int CategorieId)
    {
        ViewBag.AllProducts = _context.Products.ToList();
        ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }
    [HttpPost("CatProd/add")]
    public IActionResult AddCatProd(Assossiations newCatProd)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCatProd);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddCategories");
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

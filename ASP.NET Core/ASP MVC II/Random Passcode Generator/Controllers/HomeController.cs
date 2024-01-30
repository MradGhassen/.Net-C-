using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Random_Passcode_Generator.Models;
using Microsoft.AspNetCore.Http;


namespace Random_Passcode_Generator.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if(HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            int? count = HttpContext.Session.GetInt32("Count");
        ViewBag.Count = count;
        ViewBag.Code = TempData["Code"];
        CreateRandomPassword();
        return View();
    }
    [HttpGet("generate")]
        public IActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", (Int32) count);
            return RedirectToAction("Index");
        }

    public void CreateRandomPassword()
    {
        // Create a string of characters, numbers, and special characters that are allowed in the password
        string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();

        // Select one random character at a time from the string
        // and create an array of chars
        char[] chars = new char[15];
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = validChars[random.Next(0, validChars.Length)];
        }
        TempData["Code"] = new string(chars);
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

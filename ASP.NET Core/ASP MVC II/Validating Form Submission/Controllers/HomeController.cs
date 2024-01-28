using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Validating_Form_Submission.Models;

namespace Validating_Form_Submission.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    [HttpPost("user/create")]
    public IActionResult Create(User user)
    {            
    if(ModelState.IsValid)
    {
        // do somethng!  maybe insert into db?  then we will redirect
        return RedirectToAction("Action");
    }
    {
        // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
        ViewBag.errors = ModelState.Values;
        return View("NewUser");
    }
    }
    [HttpGet("Action")]
    public IActionResult Action()
    {
        return View();
    }
}

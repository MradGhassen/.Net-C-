using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_with_Validation.Models;

namespace Dojo_Survey_with_Validation.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    [HttpPost("create")]
    public IActionResult Create(Survey survey)
    {            
    if(ModelState.IsValid)
    {
        return RedirectToAction("Action", survey);
        // do somethng!  maybe insert into db?  then we will redirect
    }
    {
        // Oh no!  We need to return a ViewResponse to preserve the ModelState, and the errors it now contains!
        return View("Index", survey);
    }
    }
    [HttpGet("Action")] 
    public IActionResult Action(Survey survey)
    {
        return View(survey);
    }
}

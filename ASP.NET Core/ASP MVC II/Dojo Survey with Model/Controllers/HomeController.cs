using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_with_Model.Models;

namespace Dojo_Survey_with_Model.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    [HttpPost("survey")]
        public IActionResult Submission(Survey yourSurvey)
        {
            // Handle your form submission here
            return View(yourSurvey);
        }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojosurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("userformsubmit")]
        public IActionResult UserFormSubmit(string  username, string location, string language, string comments)
        {
            ViewBag.username = username;
            ViewBag.location = location; 
            ViewBag.language = language; 
            ViewBag.comments = comments;
            return View("Result");
        }

    }
}
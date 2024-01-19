using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        ViewBag.CurrentTime = DateTime.Now;
        return View("Index");
    }

}
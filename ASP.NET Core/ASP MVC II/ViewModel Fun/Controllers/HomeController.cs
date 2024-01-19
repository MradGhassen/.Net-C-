using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModel_Fun.Controllers
{
    public class HomeController : Controller
    {
        public List<User> GenerateUsers()
        {
            return new List<User>()
            {
                new User(){ FirstName="Moose", LastName="Phillips"},
                new User(){ FirstName="Sarah"},
                new User(){ FirstName="Jerry"},
                new User(){ FirstName="Rene", LastName="Ricky"},
                new User(){ FirstName="Barbarah"},
            };
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string stringModel = "My message is here, this is a simple string that I am using as a model";

            return View("Index", stringModel);
        }
        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[]{1,2,3,10,43,5};
            return View(numbers);
        }
        [HttpGet("users")]
        public IActionResult AllUsers()
        {
            var users = GenerateUsers();
            return View(users);
        }
        [HttpGet("user")]
        public IActionResult OneUser()
        {
            var rand = new Random();
            var users = GenerateUsers();

            // grab random user (could just create one, grab first, etc...)
            var user = users[rand.Next(users.Count)];
            return View(user);
        }
    }
}
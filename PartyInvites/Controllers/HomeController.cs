
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System;
using System.Linq;
namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private ResponseContext _context;

        public HomeController(ResponseContext context) => _context = context; 

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 13 ? "Good morning" : "Good afternoon";
            return View("Myview");
        }

        public ViewResult Thanks(GuestResponse response)
        {
            return View("Thanks", response);
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guestResponse);
                _context.SaveChanges();
                return RedirectToAction(nameof(Thanks),
                new { Name = guestResponse.Name, WillAttend = guestResponse.WillAttend });
                //  return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(_context.Responses.Where(r => r.WillAttend == true));
        }
        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

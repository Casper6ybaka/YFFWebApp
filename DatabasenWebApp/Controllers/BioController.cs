using Microsoft.AspNetCore.Mvc;

namespace DatabasenWebApp.Controllers
{
    public class BioController : Controller
    {
        [HttpGet]
        public IActionResult SubmitGet(string text)
        {
            Console.WriteLine(text);
            return Ok();
        }

        [HttpPost]
        public IActionResult Submit(string text)
        {
            Console.WriteLine(text);
            return RedirectToAction("Index");
        }
    }
}

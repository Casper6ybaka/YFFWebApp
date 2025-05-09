using System.Diagnostics;
using DatabasenWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatabasenWebApp.Controllers
{
    public class EditBioController : Controller
    {
        private readonly ILogger<EditBioController> _logger;

        public EditBioController(ILogger<EditBioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

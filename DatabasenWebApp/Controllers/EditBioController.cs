using System.Diagnostics;
using DatabasenWebApp.Models;
using DatabasenWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabasenWebApp.Controllers
{
    [ApiController]
    [Route("api/EditBio")]
    public class EditBioController : Controller
    {
        private readonly ILogger<EditBioController> _logger;
        GetUserData getUserData = new GetUserData();

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

        [HttpPost("edit-bio")]
        public IActionResult editBio([FromBody] string bio, int userId)
        {
            getUserData.FuckSecurity(userId, bio);
            return Ok();
        }
    }
}

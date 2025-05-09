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
        GetUserData getUserData = new GetUserData();

        [HttpPost("edit-bio")]
        public IActionResult editBio([FromBody] editBioClass data)
        {
            getUserData.FuckSecurity(data.userId, data.bio);
            return Ok();
        }

        public class editBioClass
        {
            public string bio { get; set; }
            public int userId { get; set; }
        }
    }
}

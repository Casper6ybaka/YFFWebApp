using DatabasenWebApp.Models;
using DatabasenWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatabasenWebApp.Controllers
{
    public class LoginController : Controller
    {
        SecurityService securityService = new SecurityService();
        GetUserData getUserData = new GetUserData();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(UserModel usermodel)
        {
            if (securityService.IsValid(usermodel))
            {
                usermodel = getUserData.GetUserModelFromUsernameAndPassword(usermodel.UserName, usermodel.Password);
                Response.Cookies.Append("RememberMe", usermodel.UserName, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(7)
                });
                string CurrentUser = usermodel.UserName;
                return View("LoginSuccess", usermodel);
            } else
            {
                ViewBag.Error = "Wrong password or username";
                return View("Index");
            }
            
        }
    }
}

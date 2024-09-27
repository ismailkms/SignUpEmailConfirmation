using Microsoft.AspNetCore.Mvc;
using SignUpEmailConfirmation.Models;
using SignUpEmailConfirmation.ViewModels;
using System.Diagnostics;

namespace SignUpEmailConfirmation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(User user)
        {
            return View(user);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using SignUpEmailConfirmation.Abstraction.Services;
using SignUpEmailConfirmation.Helpers;
using SignUpEmailConfirmation.ViewModels;
using System.Text.Json;

namespace SignUpEmailConfirmation.Controllers
{
    public class SignUpController : Controller
    {
        readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if(ModelState.IsValid) //Model istediğimiz şekilde geliyor mu ona bakıyoruz(Yani validation'ları uyguluyor mu). Bu kontrolü yapmazsak validation'ları uygulamadan RedirectToAction çalışıyor ve hatalara bakmaksızın sayfaya yönleniyor.
             //ModelState => Model üzerinde belirlenen Validation'ları kontol eder ve doğrulama yapar.
            {
                await _signUpService.SendConfirmationEmailAsync(user);
                return RedirectToAction("WaitingConfirmation");
            }
            
            return View();
        }

        public IActionResult WaitingConfirmation()
        {
            return View();
        }

        public IActionResult RegisterUser(string id)
        {
            User user = _signUpService.JsonDeserializeUser(id);
            return RedirectToAction("Index", "Home", user);
        }
    }
}

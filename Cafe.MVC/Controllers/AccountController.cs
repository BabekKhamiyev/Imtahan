using Cafe.BL.Services;
using Cafe.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            string result= await _accountService.Register(vm);
            if (result !="OK")
            {
                ModelState.AddModelError(string.Empty, result);
                return View();
            }

            return RedirectToAction("Index","Home");

        }


    }
}

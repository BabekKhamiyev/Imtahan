using Cafe.BL.Services;
using Cafe.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChefService _service;

        public HomeController(ChefService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Chef> chefs =_service.GetAllChef();
            return View(chefs);
        }
    }
}

using Cafe.BL.Services;
using Cafe.BL.ViewModels;
using Cafe.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class ChefController : Controller
{
    private readonly ChefService _service;

    public ChefController(ChefService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        
        return View(_service.GetAllChef());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(CreateChefVM vm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _service.Create(vm);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
        
        return View(_service.GetChefById(id));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Chef c = _service.GetChefById(id);
        UpdateChefVM vm = new UpdateChefVM()
        {
            Field = c.Field,
            Id = c.Id,
            Name = c.Name,
        };
        return View(vm);
    }


    [HttpPost]
    public IActionResult Update(int id, UpdateChefVM vm)
    {
      
        _service.Update(id, vm);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

public class ExhibitionsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
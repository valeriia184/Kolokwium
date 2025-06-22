using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;

public class GalleriesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
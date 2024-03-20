using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission11McNatt.Models;

namespace Mission11McNatt.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}

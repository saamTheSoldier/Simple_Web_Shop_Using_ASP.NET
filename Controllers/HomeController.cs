using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PajoPhone.Models;

namespace PajoPhone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(PhoneModel.GetPhoneList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        var phone = PhoneModel.GetPhoneList().FirstOrDefault(p => p.Id == id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
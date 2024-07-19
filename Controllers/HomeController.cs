using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PajoPhone.Data;
using PajoPhone.Models;

namespace PajoPhone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.PhoneModels.ToList());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        var phone = _context.PhoneModels.Find(id);    
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
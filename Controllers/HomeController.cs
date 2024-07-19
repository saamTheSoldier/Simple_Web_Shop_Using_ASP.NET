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

    public IActionResult Index(string searchString, decimal? minPrice, decimal? maxPrice)
    {
        ViewData["CurrentFilter"] = searchString;

        var minPriceDb = _context.PhoneModels.Min(p => p.Price);
        var maxPriceDb = _context.PhoneModels.Max(p => p.Price);

        ViewData["MinPrice"] = minPrice ?? minPriceDb;
        ViewData["MaxPrice"] = maxPrice ?? maxPriceDb;

        var phones = from p in _context.PhoneModels
            select p;

        if (!string.IsNullOrEmpty(searchString))
        {
            phones = phones.Where(p => p.Name.ToLower().Contains(searchString.ToLower()));
        }

        if (minPrice.HasValue && maxPrice.HasValue)
        {
            phones = phones.Where(p => p.Price >= minPrice.Value && p.Price <= maxPrice.Value);
        }

        return View(phones.ToList());
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
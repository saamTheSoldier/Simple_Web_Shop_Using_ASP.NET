using Microsoft.AspNetCore.Mvc;
using PajoPhone.Data;
using PajoPhone.Models;

namespace PajoPhone.Controllers;

public class AdminPanelController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminPanelController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult AdminPanel()
    {
        var phones = _context.PhoneModels.ToList();
        return View(phones);
    }

    public IActionResult Edit(int id)
    {
        var phone = _context.PhoneModels.Find(id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }

    public IActionResult EditPost(int id, PhoneModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        var phone = _context.PhoneModels.Find(id);
        if (phone == null)
        {
            return NotFound();
        }

        if (model.ImageFile != null)
        {
            using var memoryStream = new MemoryStream();
            model.ImageFile.CopyToAsync(memoryStream);
            model.ImageData = memoryStream.ToArray();
            phone.ImageData = model.ImageData;

        }

        phone.Name = model.Name;
        phone.Explanations = model.Explanations;
        phone.Color = model.Color;
        phone.Price = model.Price;

        _context.Update(phone);
        _context.SaveChanges();

        return RedirectToAction(nameof(AdminPanel));
    }


    public IActionResult Delete(int id)
    {
        var phone = _context.PhoneModels.Find(id);
        if (phone == null)
        {
            return NotFound();
        }

        return View(phone);
    }

    public IActionResult DeleteConfirmed(int id)
    {
        var phone = _context.PhoneModels.Find(id);
        if (phone == null)
        {
            return NotFound();
        }

        _context.PhoneModels.Remove(phone);
        _context.SaveChanges();

        return RedirectToAction(nameof(AdminPanel));
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreatePost(PhoneModel model)
    {
        if (model.ImageFile != null)
        {
            using (var memoryStream = new MemoryStream())
            {
                model.ImageFile.CopyToAsync(memoryStream);
                model.ImageData = memoryStream.ToArray();
            }
        }

        _context.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(AdminPanel));
    }
}
using Microsoft.AspNetCore.Mvc;
using PajoPhone.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace PajoPhone.Controllers;


public class AdminPanelController : Controller
{
    private static readonly List<PhoneModel> PhoneList =
    [
        new PhoneModel { Id = 1, Name = "Phone A", Explanations = "Description A", Color = "Black", Price = 700 },
        new PhoneModel { Id = 2, Name = "Phone B", Explanations = "Description B", Color = "White", Price = 800 }
    ];

    private static int _currentId = 3;

    public int GetNewId()
    {
        var id = _currentId;
        _currentId++;
        return id;
    }
    public IActionResult AdminPanel()
    {
        var viewModel = new ListOfPhonesViewModel
        {
            Phones = PhoneList
        };
        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        var phone = PhoneList.FirstOrDefault(phone => phone.Id == id);
        if (phone == null)
        {
            return NotFound();
        }
        return View(phone);
    }

    public IActionResult EditPost(PhoneModel model)
    {
        var phone = PhoneList.FirstOrDefault(p => p.Id == model.Id);
        if (phone == null)
        {
            return NotFound();
        }
        phone.Name = model.Name;
        phone.Explanations = model.Explanations;
        phone.Color = model.Color;
        phone.Price = model.Price;
        return RedirectToAction("AdminPanel");
    }
    
    public IActionResult Delete(int id)
    {
        var phone = PhoneList.FirstOrDefault(p => p.Id == id);
        if (phone == null)
        {
            return NotFound();
        }
        return View(phone);
    }

    public IActionResult DeleteConfirmed(int id)
    {
        var phone = PhoneList.FirstOrDefault(p => p.Id == id);
        if (phone == null)
        {
            return NotFound();
        }

        PhoneList.Remove(phone);

        return RedirectToAction("AdminPanel");
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult CreatePost(PhoneModel model)
    {
        var phone = new PhoneModel
        {
            Id = GetNewId(), Name = model.Name, Color = model.Color, Explanations = model.Explanations,
            Price = model.Price
        };
        PhoneList.Add(phone);
        return RedirectToAction("AdminPanel");
    }
}
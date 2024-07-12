using Microsoft.AspNetCore.Mvc;
using PajoPhone.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace PajoPhone.Controllers;


public class AdminPanelController : Controller
{
    private static readonly List<PhoneModel> PhoneList =
    [
        new PhoneModel { Id = 1, Name = "Phone A", Explanations = "Description A", Color = "Black", Price = 700 },
        new PhoneModel
        {
            Id = 2, Name = "Phone B", Explanations = "Description B", Color = "White", Price = 800,
            ImagePath = "~/Images/58310e6f1f7829712ac07237cf5eddbcc24b6288_1690788174.webp"
        },
        new PhoneModel
        {
            Id = 3, Name = "samphone", Explanations = "a good phone", Color = "black", Price = 1000,
            ImagePath = "~/Images/aa6c900917f0cfb63c85c832d5ef68ccc8765209_1694525475.webp"
        }
    ];

    private static int _currentId = 4;

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
        if (model.ImageFile != null)
        {
            var fileName = Path.GetFileName(model.ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }
            phone.ImagePath = "~/Images/" + fileName;
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
        if (model.ImageFile != null)
        {
            var fileName = Path.GetFileName(model.ImageFile.FileName);
 
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }

            model.ImagePath = "~/Images/" + fileName;
        }

        var phone = new PhoneModel
        {
            Id = GetNewId(),
            Name = model.Name,
            Color = model.Color,
            Explanations = model.Explanations,
            Price = model.Price,
            ImagePath = model.ImagePath
        };
        PhoneList.Add(phone);
        return RedirectToAction("AdminPanel");
    }
}
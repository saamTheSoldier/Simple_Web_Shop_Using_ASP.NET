using Microsoft.AspNetCore.Mvc;
using PajoPhone.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using PajoPhone.Models;
namespace PajoPhone.Controllers;


public class AdminPanelController : Controller
{
    public IActionResult AdminPanel()
    {
        var viewModel = new PhoneModel
        {
            Phones = PhoneModel.GetPhoneList()
        };
        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        var phone = PhoneModel.GetPhoneList().FirstOrDefault(phone => phone.Id == id);
        if (phone == null)
        {
            return NotFound();
        }
        return View(phone);
    }

    public IActionResult EditPost(PhoneModel model)
    {
        var phone = PhoneModel.GetPhoneList().FirstOrDefault(p => p.Id == model.Id);
        if (phone == null)
        {
            return NotFound();
        }
        if (model.ImageFile != null)
        {
            var fileName = Path.GetFileName(model.ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }
            phone.ImagePath = "/Images/" + fileName;
        }

        phone.Name = model.Name;
        phone.Explanations = model.Explanations;
        phone.Color = model.Color;
        phone.Price = model.Price;
        return RedirectToAction("AdminPanel");
    }
    
    public IActionResult Delete(int id)
    {
        var phone = PhoneModel.GetPhoneList().FirstOrDefault(p => p.Id == id);
        if (phone == null)
        {
            return NotFound();
        }
        return View(phone);
    }

    public IActionResult DeleteConfirmed(int id)
    {
        var phone = PhoneModel.GetPhoneList().FirstOrDefault(p => p.Id == id);
        if (phone == null)
        {
            return NotFound();
        }

        PhoneModel.removePhoneFromPhoneList(phone);

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
 
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                model.ImageFile.CopyTo(stream);
            }

            model.ImagePath = "/Images/" + fileName;
        }

        var phone = new PhoneModel
        {
            Id = PhoneModel.GetNewId(),
            Name = model.Name,
            Color = model.Color,
            Explanations = model.Explanations,
            Price = model.Price,
            ImagePath = model.ImagePath
        };
        PhoneModel.AddPhoneToPhoneList(phone);
        return RedirectToAction("AdminPanel");
    }
}
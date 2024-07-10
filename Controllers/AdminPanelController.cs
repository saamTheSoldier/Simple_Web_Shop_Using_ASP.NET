using Microsoft.AspNetCore.Mvc;
using PajoPhone.Models;

namespace PajoPhone.Controllers;


public class AdminPanelController : Controller
{
    private static List<PhoneModel> phoneList = new List<PhoneModel>
    {
        //temporary for testing 
        new PhoneModel { Id = 1, Name = "Phone A", Explanations = "Description A", Color = "Black", Price = 700 },
        new PhoneModel { Id = 2, Name = "Phone B", Explanations = "Description B", Color = "White", Price = 800 },
    };
    public IActionResult AdminPanel()
    {
        var viewModel = new ListOfPhonesViewModel
        {
            Phones = phoneList
        };
        return View(viewModel);
    }
}
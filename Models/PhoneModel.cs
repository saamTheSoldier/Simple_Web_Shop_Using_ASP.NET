using System.ComponentModel.DataAnnotations.Schema;

namespace PajoPhone.Models;

public class PhoneModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Explanations { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    [NotMapped] public IFormFile ImageFile { get; set; }
    public byte[] ImageData { get; set; }
}
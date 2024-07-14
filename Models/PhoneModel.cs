namespace PajoPhone.Models;

public class PhoneModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Explanations { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public string ImagePath { get; set; } = "/Images/DefaultPhone.png";
    public IFormFile ImageFile { get; set; }
    public List<PhoneModel> Phones { get; set; }
    
    private static readonly List<PhoneModel> PhoneList =
    [
        new PhoneModel { Id = 1, Name = "PhoneModel A", Explanations = "Description A", Color = "Black", Price = 700 },
        new PhoneModel
        {
            Id = 2, Name = "PhoneModel B", Explanations = "Description B", Color = "White", Price = 800,
            ImagePath = "/Images/58310e6f1f7829712ac07237cf5eddbcc24b6288_1690788174.webp"
        },
        new PhoneModel
        {
            Id = 3, Name = "samphone", Explanations = "a good phone", Color = "black", Price = 1000,
            ImagePath = "/Images/aa6c900917f0cfb63c85c832d5ef68ccc8765209_1694525475.webp"
        }
    ];

    public static List<PhoneModel> GetPhoneList()
    {
        return PhoneList;
    }

    public static List<PhoneModel> AddPhoneToPhoneList(PhoneModel phoneModel)
    {
        PhoneList.Add(phoneModel);
        return PhoneList;
    }

    public static List<PhoneModel> removePhoneFromPhoneList(PhoneModel phoneModel)
    {
        PhoneList.Remove(phoneModel);
        return PhoneList;
    }
    

    public static int GetNewId()
    {
        var id = (PhoneList.Count + 1);
        return id;
    }
}
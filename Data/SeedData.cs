using Microsoft.EntityFrameworkCore;
using PajoPhone.Models;

namespace PajoPhone.Data;
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.PhoneModels.Any())
                {
                    return; // DB has been seeded
                }

                context.PhoneModels.AddRange(
                    new PhoneModel
                    {
                        Name = "Galaxy S21",
                        Explanations = "A powerful phone with a stunning display",
                        Color = ColorEnum.Black,
                        Price = 999.99M,
                        ImageData = GetImageBytes("Images/51ca4d6108835c0632fcae34d1f05a76081b8106_1707719127.webp")
                    },
                    new PhoneModel
                    {
                        Name = "iPhone 12",
                        Explanations = "Sleek design with advanced camera capabilities",
                        Color = ColorEnum.White,
                        Price = 1099.99M,
                        ImageData = GetImageBytes("Images/58310e6f1f7829712ac07237cf5eddbcc24b6288_1690788174.webp")
                    },
                    new PhoneModel
                    {
                        Name = "OnePlus 9",
                        Explanations = "Fast and smooth with a top-tier camera",
                        Color = ColorEnum.Red,
                        Price = 729.99M,
                        ImageData = GetImageBytes("Images/95e9a7327d1f8650f13794a7c33917d9d130b987_1660478804.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Pixel 5",
                        Explanations = "Google's flagship phone with pure Android experience",
                        Color = ColorEnum.Green,
                        Price = 699.99M,
                        ImageData = GetImageBytes("Images/aa6c900917f0cfb63c85c832d5ef68ccc8765209_1694525475.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Sony Xperia 1",
                        Explanations = "4K display with professional-grade camera",
                        Color = ColorEnum.Blue,
                        Price = 949.99M,
                        ImageData = GetImageBytes("Images/b3d660fd6a3946de6f822dc28455af8a9e22cd67_1691477422.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Nokia 8.3",
                        Explanations = "5G connectivity with a durable build",
                        Color = ColorEnum.Black,
                        Price = 599.99M,
                        ImageData = GetImageBytes("Images/bd7648d55ffe49a0596ac3668f4db41f7c790f6a_1696760508.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Huawei P40 Pro",
                        Explanations = "Exceptional camera system with powerful performance",
                        Color = ColorEnum.White,
                        Price = 899.99M,
                        ImageData = GetImageBytes("Images/e2dfa5857f437ae654721f8046b928583e430db8_1708358300.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Motorola Edge Plus",
                        Explanations = "Edge display with high-end specs",
                        Color = ColorEnum.Yellow,
                        Price = 799.99M,
                        ImageData = GetImageBytes("Images/ec9a962187e1f82cc47e7a148ef99ec1c6fd024d_1656423336.webp")
                    },
                    new PhoneModel
                    {
                        Name = "Xiaomi Mi 11",
                        Explanations = "High-end features at an affordable price",
                        Color = ColorEnum.Red,
                        Price = 749.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Oppo Find X3 Pro",
                        Explanations = "Innovative design with excellent camera",
                        Color = ColorEnum.Blue,
                        Price = 1149.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Realme GT",
                        Explanations = "Performance-oriented with a stylish design",
                        Color = ColorEnum.Black,
                        Price = 599.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "LG Wing",
                        Explanations = "Unique swiveling design for multitasking",
                        Color = ColorEnum.White,
                        Price = 999.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Asus ROG Phone 5",
                        Explanations = "Gaming-focused phone with high refresh rate display",
                        Color = ColorEnum.Green,
                        Price = 1099.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Nokia 7.2",
                        Explanations = "Affordable option with decent performance",
                        Color = ColorEnum.Black,
                        Price = 399.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Honor V40",
                        Explanations = "Feature-packed phone with a sleek design",
                        Color = ColorEnum.Red,
                        Price = 799.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Samsung A52",
                        Explanations = "Mid-range phone with solid performance",
                        Color = ColorEnum.Blue,
                        Price = 499.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Sony Xperia 10 III",
                        Explanations = "Compact and durable with good specs",
                        Color = ColorEnum.Green,
                        Price = 449.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Apple iPhone SE",
                        Explanations = "Compact and powerful, ideal for iOS users",
                        Color = ColorEnum.White,
                        Price = 399.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Google Pixel 4a",
                        Explanations = "Excellent camera performance in a compact size",
                        Color = ColorEnum.Black,
                        Price = 349.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Xiaomi Redmi Note 10 Pro",
                        Explanations = "Great performance with a high-resolution display",
                        Color = ColorEnum.Red,
                        Price = 279.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Samsung Galaxy Z Fold 3",
                        Explanations = "Cutting-edge foldable phone with flexible display",
                        Color = ColorEnum.Blue,
                        Price = 1799.99M,
                        ImageData = GetImageBytes("Images/DefaultPhone.png")
                    },
                    new PhoneModel
                    {
                        Name = "Huawei Mate 40 Pro",
                        Explanations = "Flagship phone with advanced camera system",
                        Color = ColorEnum.Green,
                        Price = 1199.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "OnePlus Nord N200",
                        Explanations = "Budget-friendly 5G phone with decent specs",
                        Color = ColorEnum.Black,
                        Price = 239.99M
                        // No image data
                    },
                    new PhoneModel
                    {
                        Name = "Google Pixel 6 Pro",
                        Explanations = "Latest flagship with top features",
                        Color = ColorEnum.White,
                        Price = 899.99M,
                        ImageData = GetImageBytes("Images/DefaultPhone.png")
                    },
                    new PhoneModel
                    {
                        Name = "Apple iPhone 13 Mini",
                        Explanations = "Compact and powerful, ideal for Apple fans",
                        Color = ColorEnum.Red,
                        Price = 699.99M
                    }
                );

                context.SaveChanges();
            }
        }

        private static byte[] GetImageBytes(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                return null;
            }

            return File.ReadAllBytes(imagePath);
        }
    }

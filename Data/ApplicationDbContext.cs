using Microsoft.EntityFrameworkCore;
using PajoPhone.Models;

namespace PajoPhone.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PhoneModel> PhoneModels { get; set; }
}
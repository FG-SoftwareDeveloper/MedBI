using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedBI.Data.Models;

public class MedBIContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public MedBIContext(DbContextOptions<MedBIContext> options)
        : base(options)
    {
    }

    public DbSet<Claim> Claims { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Document> Documents { get; set; }
}

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
    public DbSet<NavigationItem> NavigationItems { get; set; }
    public DbSet<NavigationItemRole> NavigationItemRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<NavigationItem>()
            .HasMany(n => n.NavigationItemRoles)
            .WithOne(r => r.NavigationItem)
            .HasForeignKey(r => r.NavigationItemId);

        // Optional: Configure max lengths, required fields, etc.
        modelBuilder.Entity<NavigationItem>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(255).IsRequired();
            entity.Property(e => e.IconCssClass).HasMaxLength(255);
            entity.Property(e => e.PageUrl).HasMaxLength(255);
        });

        modelBuilder.Entity<NavigationItemRole>(entity =>
        {
            entity.Property(e => e.RoleName).HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<NavigationItem>().HasData(
    new NavigationItem { Id = 1, Title = "Dashboard", IconCssClass = "bi bi-speedometer2", PageUrl = "/Admin/Dashboard", Order = 1 },
    new NavigationItem { Id = 2, Title = "Manage Users", IconCssClass = "bi bi-people", PageUrl = "/Admin/ManageUsers", Order = 2 }
);

        modelBuilder.Entity<NavigationItemRole>().HasData(
            new NavigationItemRole { Id = 1, NavigationItemId = 1, RoleName = "Admin" },
            new NavigationItemRole { Id = 2, NavigationItemId = 2, RoleName = "Customer" },
            new NavigationItemRole { Id = 3, NavigationItemId = 1, RoleName = "Analyst" }
        );
    }


}

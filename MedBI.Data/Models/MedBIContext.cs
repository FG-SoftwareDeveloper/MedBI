using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedBI.Data.Models
{
    public class MedBIContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public MedBIContext(DbContextOptions<MedBIContext> options)
            : base(options)
        {
        }

        // Identity Tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<NavigationItemRole> NavigationItemRoles { get; set; }
        public DbSet<NavigationItem> NavigationItems { get; set; }
        // App Entities
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<PatientAllergies> PatientAllergies { get; set; }
        public DbSet<PatientVitals> PatientVitals { get; set; }
        public DbSet<PatientChronicConditions> PatientChronicConditions { get; set; }
        public DbSet<PatientLifestyle> PatientLifestyle { get; set; }
        public DbSet<PatientLabResults> PatientLabResults { get; set; }
        public DbSet<ErrorLogs> ErrorLogs { get; set; }
        public DbSet<AuditLogs> AuditLogs { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Analyst> Analyst { get; set; }
        public DbSet<SystemLogs> SystemLogs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Medicine> Medicines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NavigationItem>(entity =>
            {
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(e => e.IconCssClass)
                    .HasMaxLength(255);

                entity.Property(e => e.PageUrl)
                    .HasMaxLength(255);

                entity.HasMany(n => n.NavigationItemRoles)
                    .WithOne(r => r.NavigationItem)
                    .HasForeignKey(r => r.NavigationItemId);
            });

            modelBuilder.Entity<NavigationItemRole>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasMaxLength(450)
                    .IsRequired();
            });
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(m => m.Sender)
                    .WithMany(u => u.SentMessages)
                    .HasForeignKey(m => m.SenderUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Recipient)
                    .WithMany(u => u.ReceivedMessages)
                    .HasForeignKey(m => m.RecipientUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            SeedNavigationData(modelBuilder);
        }
       
        private void SeedNavigationData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NavigationItem>().HasData(
                new NavigationItem
                {
                    Id = 1,
                    Title = "Dashboard",
                    IconCssClass = "bi bi-speedometer2",
                    PageUrl = "/Admin/Dashboard",
                    Order = 1
                },
                new NavigationItem
                {
                    Id = 2,
                    Title = "Manage Users",
                    IconCssClass = "bi bi-people",
                    PageUrl = "/Admin/ManageUsers",
                    Order = 2
                }
            );

            modelBuilder.Entity<NavigationItemRole>().HasData(
                new NavigationItemRole { Id = 1, NavigationItemId = 1, RoleId = "Admin" },
                new NavigationItemRole { Id = 2, NavigationItemId = 2, RoleId = "Admin" },
                new NavigationItemRole { Id = 3, NavigationItemId = 1, RoleId = "Doctor" },
                new NavigationItemRole { Id = 4, NavigationItemId = 2, RoleId = "Doctor" },
                new NavigationItemRole { Id = 5, NavigationItemId = 1, RoleId = "Nurse" },
                new NavigationItemRole { Id = 6, NavigationItemId = 2, RoleId = "Nurse" }
            );
        }
    }
}

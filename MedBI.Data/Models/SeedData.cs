using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MedBIContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //context.Database.Migrate();

            // -----------------------
            // Seed Roles
            // -----------------------
            string[] roles = { "Admin", "Doctor", "Nurse", "Analyst", "Customer", "Patient", "IT" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // -----------------------
            // Seed Users
            // -----------------------
            async Task<ApplicationUser> CreateUser(string username, string email, string role)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = username,
                        Email = email,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, "Password@123");
                    await userManager.AddToRoleAsync(user, role);
                }
                return user;
            }

            var adminUser = await CreateUser("adminuser", "admin@medbi.com", "Admin");
            var doctorUser = await CreateUser("doctoruser", "doctor@medbi.com", "Doctor");
            var nurseUser = await CreateUser("nurseuser", "nurse@medbi.com", "Nurse");
            var analystUser = await CreateUser("analystuser", "analyst@medbi.com", "Analyst");
            var patientUser = await CreateUser("patientuser", "patient@medbi.com", "Patient");
            var itUser = await CreateUser("ituser", "it@medbi.com", "IT");

            await context.SaveChangesAsync();

            // -----------------------
            // Seed Staff
            // -----------------------
            var staff = context.Staff.FirstOrDefault(s => s.Email == "sarah.miller@medbi.com");
            if (staff == null)
            {
                staff = new Staff
                {
                    FirstName = "Sarah",
                    LastName = "Miller",
                    Role = "Nurse",
                    ContactNumber = "555-9999",
                    Email = "sarah.miller@medbi.com",
                    Address = "456 Hospital Way",
                    HireDate = DateTime.Now,
                    UserId = nurseUser.Id
                };
                context.Staff.Add(staff);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Nurse
            // -----------------------
            var nurse = context.Nurses.FirstOrDefault(n => n.FullName == "Jane Doe");
            if (nurse == null)
            {
                nurse = new Nurse
                {
                    FullName = "Jane Doe",
                    Department = "Cardiology",
                    UserId = nurseUser.Id,
                    Staff_Id = staff.StaffId,
                    Specialization = "Cardiology",
                    ShiftHours = 40
                };
                context.Nurses.Add(nurse);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Doctor
            // -----------------------
            var doctor = context.Doctors.FirstOrDefault(d => d.Email == "doctor@medbi.com");
            if (doctor == null)
            {
                doctor = new Doctor
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Specialty = "Cardiology",
                    Email = "doctor@medbi.com",
                    PhoneNumber = "555-2222",
                    UserId = doctorUser.Id,
                    AvailableSchedule = "Mon-Fri 9-5"
                };
                context.Doctors.Add(doctor);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Analyst
            // -----------------------
            var analyst = context.Analyst.FirstOrDefault();
            if (analyst == null)
            {
                context.Analyst.Add(new Analyst
                {
                    UserId = analystUser.Id,
                    User = analystUser, // Fix for CS9035: Required member 'Analyst.User' must be set
                    Department = "Analytics",
                    Specialty = "Data Science",
                    CreatedDate = DateTime.Now
                });     
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Patient
            // -----------------------
            var patient = context.Patients.FirstOrDefault(p => p.Email == "patient@medbi.com");
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Gender = "Female",
                    Email = "patient@medbi.com",
                    PhoneNumber = "555-3333",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    MedicalHistory = "Asthma",
                    UserId = patientUser.Id
                };
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Patient Details
            // -----------------------

            if (!context.PatientVitals.Any())
            {
                context.PatientVitals.Add(new PatientVitals
                {
                    PatientId = patient.PatientId,
                    RecordedAt = DateTime.Now,
                    HeightCm = 165.5m,
                    WeightKg = 65.0m,
                    SystolicBp = 118,
                    DiastolicBp = 78,
                    HeartRate = 72,
                    Temperature = 36.6m,
                    OxygenSaturation = 98,
                    RespirationRate = 16
                });
            }

            if (!context.PatientAllergies.Any())
            {
                context.PatientAllergies.Add(new PatientAllergies
                {
                    PatientId = patient.PatientId,
                    AllergyName = "Peanuts",
                    Severity = "Severe",
                    Notes = "Carries EpiPen",
                    Patient = patient // Fix for CS9035: Required member 'PatientAllergies.Patient' must be set
                });

            }

            if (!context.PatientChronicConditions.Any())
            {
                context.PatientChronicConditions.Add(new PatientChronicConditions
                {
                    PatientId = patient.PatientId,
                    ConditionName = "Hypertension",
                    DiagnosisDate = new DateTime(2015, 5, 1),
                    Status = "Controlled",
                    Notes = "Regular monitoring"
                });
            }

            if (!context.PatientLabResults.Any())
            {
                context.PatientLabResults.Add(new PatientLabResults
                {
                    PatientId = patient.PatientId,
                    TestName = "Glucose",
                    ResultValue = "95",
                    Unit = "mg/dL",
                    ReferenceRange = "70-100",
                    ResultDate = DateTime.Now
                });
            }

            if (!context.PatientLifestyle.Any())
            {
                context.PatientLifestyle.Add(new PatientLifestyle
                {
                    PatientId = patient.PatientId,
                    SmokingStatus = "Non-smoker",
                    AlcoholUse = "Occasional",
                    ExerciseFrequency = "Weekly",
                    DietQuality = "Good",
                    Notes = "Healthy lifestyle"
                });
            }

            await context.SaveChangesAsync();

            // -----------------------
            // Seed Medicine
            // -----------------------

            var medicine = context.Medicines.FirstOrDefault(m => m.Name == "Aspirin");
            if (medicine == null)
            {
                medicine = new Medicine
                {
                    Name = "Aspirin",
                    Brand = "Bayer",
                    Type = "Tablet",
                    Dosage = "100mg",
                    StockQuantity = 100,
                    ExpiryDate = DateTime.Now.AddYears(2),
                    CreatedAt = DateTime.Now
                };
                context.Medicines.Add(medicine);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Pharmacy
            // -----------------------

            var pharmacy = context.Pharmacy.FirstOrDefault();
            if (pharmacy == null)
            {
                pharmacy = new Pharmacy
                {
                    MedicineId = medicine.MedicineId,
                    PatientId = patient.PatientId,
                    Quantity = 30,
                    PrescriptionDate = DateTime.Now
                };
                context.Pharmacy.Add(pharmacy);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Appointment
            // -----------------------
            if (!context.Appointments.Any())
            {
                var appointment = new Appointment
                {
                    PatientId = patient.PatientId,
                    DoctorId = doctor.DoctorId,
                    AppointmentDate = DateTime.Now.AddDays(3),
                    Status = "Scheduled"
                };
                context.Appointments.Add(appointment);
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Billing
            // -----------------------
            
                // Fix for CS9035: Required member 'Billing.Patient' must be set in the object initializer or attribute constructor.
                if (!context.Billings.Any())
                {
                    context.Billings.Add(new Billing
                    {
                        PatientId = patient.PatientId,
                        Patient = patient, // Required member 'Billing.Patient' is now set
                        AppointmentId = context.Appointments.First().Id,
                        TotalAmount = 250.0m,
                        PaymentStatus = "Pending",
                        CreatedAt = DateTime.Now
                    });
                    await context.SaveChangesAsync();
                }
              
            

            // -----------------------
            // Seed Claim
            // -----------------------
            if (!context.Claims.Any())
            {
                context.Claims.Add(new Claim
                {
                    PatientId = patient.PatientId,
                    DoctorId = doctor.DoctorId,
                    Diagnosis = "Routine Checkup",
                    ProcedureCode = "99213",
                    Amount = 150.0m,
                    Status = "Submitted",
                    DateOfService = DateTime.Today
                });
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Document
            // -----------------------
            if (!context.Documents.Any())
            {
                context.Documents.Add(new Document
                {
                    FileName = "report.pdf",
                    ContentType = "application/pdf",
                    FileSize = 1024,
                    UploadedOn = DateTime.Now,
                    PatientId = patient.PatientId
                });
                await context.SaveChangesAsync();
            }

            // -----------------------
            // Seed Messages
            // -----------------------

            if (!context.Messages.Any())
            {
                var message1 = new Message
                {
                    SenderUserId = adminUser.Id,
                    RecipientUserId = doctorUser.Id,
                    Subject = "Welcome to MedBI",
                    Body = "Hello Doctor Smith, welcome aboard the MedBI platform!",
                    SentDate = DateTime.Now,
                    Status = "Sent"
                };

                var message2 = new Message
                {
                    SenderUserId = doctorUser.Id,
                    RecipientUserId = patientUser.Id,
                    Subject = "Upcoming Appointment Reminder",
                    Body = "Dear Jane Doe, you have an appointment scheduled for next week.",
                    SentDate = DateTime.Now,
                    Status = "Sent"
                };

                context.Messages.AddRange(message1, message2);
                await context.SaveChangesAsync();
            }


            // -----------------------
            // Seed Logs
            // -----------------------

            if (!context.SystemLogs.Any())
            {
                context.SystemLogs.Add(new SystemLogs
                {
                    LogLevel = "Info",
                    Message = "System initialized.",
                    Timestamp = DateTime.Now
                });
                await context.SaveChangesAsync();
            }

            if (!context.ErrorLogs.Any())
            {
                context.ErrorLogs.Add(new ErrorLogs
                {
                    Timestamp = DateTime.Now,
                    Message = "Sample error log.",
                    Path = "/api/test",
                    QueryString = "",
                    StackTrace = "Sample stack trace"
                });
                await context.SaveChangesAsync();
            }
        }
    }
}

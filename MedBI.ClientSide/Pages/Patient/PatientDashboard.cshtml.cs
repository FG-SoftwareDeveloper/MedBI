using MedBI.ClientSide.Models;
using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace MedBI.ClientSide.Pages.Patient
{
    public class PatientDashboardModel : DashboardLayoutModel
    {
        private readonly NavigationApiService _navApiService;
        private readonly IHttpClientFactory _httpClientFactory;

        public PatientDashboardModel(
            NavigationApiService navApiService,
            IHttpClientFactory httpClientFactory)
        {
            _navApiService = navApiService;
            _httpClientFactory = httpClientFactory;
        }

        public List<NavigationItem> NavItems { get; set; } = new();
        public List<PatientViewModel> Patients { get; set; } = new();
        public List<PatientVitals> PatientVitals { get; set; } = new();
        public List<PatientAllergies> PatientAllergies { get; set; } = new();

        public async Task OnGetAsync()
        {
            NavItems = await _navApiService.GetNavigationForRoleAsync("Patient");

            await LoadPatientsAsync();
            await LoadVitalsAsync();
            await LoadAllergiesAsync();

            await LoadDashboardCardsAsync();
        }

        private async Task LoadPatientsAsync()
        {
            var client = _httpClientFactory.CreateClient("MedBI.API");

            var response = await client.GetAsync("api/patients");

            if (response.IsSuccessStatusCode)
            {
                var patients = await response.Content.ReadFromJsonAsync<List<PatientViewModel>>();
                Patients = patients ?? new List<PatientViewModel>();
                Console.WriteLine($"[PatientDashboard] Fetched {Patients.Count} patients.");
            }
            else
            {
                Console.WriteLine($"[PatientDashboard] Failed to fetch patients: {response.StatusCode}");
            }
        }

        private async Task LoadVitalsAsync()
        {
            var client = _httpClientFactory.CreateClient("MedBI.API");

            var response = await client.GetAsync("api/patientvitals");

            Console.WriteLine($"[PatientDashboard] Patient Vitals API returned status code: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var vitals = await response.Content.ReadFromJsonAsync<List<PatientVitals>>();
                PatientVitals = vitals ?? new List<PatientVitals>();
                Console.WriteLine($"[PatientDashboard] Fetched {PatientVitals.Count} patient vitals.");
            }
            else
            {
                Console.WriteLine($"[PatientDashboard] Failed to fetch patient vitals: {response.StatusCode}");
            }
        }

        private async Task LoadAllergiesAsync()
        {
            var client = _httpClientFactory.CreateClient("MedBI.API");

            var response = await client.GetAsync("api/patientallergies");

            Console.WriteLine($"[PatientDashboard] Patient Allergies API returned status code: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var allergies = await response.Content.ReadFromJsonAsync<List<PatientAllergies>>();
                PatientAllergies = allergies ?? new List<PatientAllergies>();
                Console.WriteLine($"[PatientDashboard] Fetched {PatientAllergies.Count} patient allergies.");
            }
            else
            {
                Console.WriteLine($"[PatientDashboard] Failed to fetch patient allergies: {response.StatusCode}");
            }
        }

        public override async Task LoadDashboardCardsAsync()
        {
            var patientHtml = Patients.Any()
                ? string.Join("", Patients.Select(p =>
                    $"<li><strong>{p.FirstName} {p.LastName}</strong> - {p.Email}</li>"))
                : "<li>No patients found.</li>";

            var latestVitals = PatientVitals
        .OrderByDescending(v => v.RecordedAt)
        .FirstOrDefault();

            var vitalsHtml = PatientVitals.Any()
                ? string.Join("<br/>", PatientVitals.Select(v =>
              $"<strong>Recorded:</strong> {v.RecordedAt:g} | BP: {v.SystolicBp}/{v.DiastolicBp} | HR: {v.HeartRate}"))
                : "<p>No vitals recorded.</p>";

            var allergiesHtml = PatientAllergies.Any()
                ? string.Join("<br/>", PatientAllergies.Select(a =>
                    $"{a.AllergyName} (Severity: {a.Severity}) - {a.Notes}"))
                : "<p>No allergies recorded.</p>";

            
                DashboardCards = new List<DashboardCardModel>
            {
                new DashboardCardModel
                {
                    Title = "Patient Overview",
                    ContentHtml = $"<ul>{patientHtml}</ul>",
                    Width = 6
                },
                new DashboardCardModel
                {
                    Title = "Patient Allergies",
                    ContentHtml = allergiesHtml,
                    Width = 6
                },
                new DashboardCardModel
        {
            Title = "Blood Pressure",
            ContentHtml = $"<strong>Systolic:</strong> {latestVitals.SystolicBp ?? 0} mmHg<br/><strong>Diastolic:</strong> {latestVitals.DiastolicBp ?? 0} mmHg",
            Width = 4
        },

       new DashboardCardModel
        {
            Title = "Heart Rate",
            ContentHtml = $"<strong>Heart Rate:</strong> {latestVitals.HeartRate ?? 0} bpm",
            Width = 4
        },

        new DashboardCardModel
        {
            Title = "Temperature",
            ContentHtml = $"<strong>Temperature:</strong> {latestVitals.Temperature?.ToString("F1") ?? "N/A"} °C",
            Width = 4
        },
        new DashboardCardModel
        {
            Title = "Oxygen Saturation",
            ContentHtml = $"<strong>Saturation:</strong> {latestVitals.OxygenSaturation ?? 0} %",
            Width = 4
        },
        new DashboardCardModel
        {
            Title = "Respiration Rate",
            ContentHtml = $"<strong>Respiration Rate:</strong> {latestVitals.RespirationRate ?? 0} /min",
            Width = 4
        },
        new DashboardCardModel
        {
            Title = "Height & Weight",
            ContentHtml = $"<strong>Height:</strong> {latestVitals.HeightCm?.ToString("F1") ?? "N/A"} cm<br/><strong>Weight:</strong> {latestVitals.WeightKg?.ToString("F1") ?? "N/A"} kg",
            Width = 4
        }
        


        };

            await Task.CompletedTask;
        }
    }

    public class PatientViewModel
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}

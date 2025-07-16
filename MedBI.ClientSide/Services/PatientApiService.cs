using MedBI.ClientSide.Models;

namespace MedBI.ClientSide.Services
{
    public class PatientApiService
    {
        private readonly HttpClient _http;

        public PatientApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("MedBI.API");
        }

        public async Task<int> GetUpcomingAppointmentsCount(int patientId)
        {
            var result = await _http.GetFromJsonAsync<int>(
                $"api/Appointments/count/upcoming/{patientId}");
            return result;
        }

        public async Task<Patient?> GetPatientByUserId(string userId)
        {
            return await _http.GetFromJsonAsync<Patient>(
                $"api/Patients/by-user/{userId}");
        }


        public async Task<List<Appointment>> GetAppointmentsByPatientId(int patientId)
        {
            return await _http.GetFromJsonAsync<List<Appointment>>(
                $"api/Appointments?patientId={patientId}") ?? new List<Appointment>();
        }

        public async Task<Patient?> GetPatientById(int patientId)
        {
            return await _http.GetFromJsonAsync<Patient>(
                $"api/Patients/{patientId}");
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _http.GetFromJsonAsync<List<Patient>>(
                $"api/Patients") ?? new List<Patient>();
        }
    }
}

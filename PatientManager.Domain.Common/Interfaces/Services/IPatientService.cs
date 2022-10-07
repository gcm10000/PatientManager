using PatientManager.Domain.Common.DTOs;
using PatientManager.Domain.Common.Entities;

namespace PatientManager.Domain.Common.Interfaces.Services
{
    public interface IPatientService
    {
        Task<Patient?> GetAsync(int id);
        Task<PaginatedList<Patient>> SearchAsync(FilterInput filterInput);
        Task<List<string>> AddAsync(Patient patient);
        Task<List<string>> UpdateAsync(Patient patient);
        Task<string?> GetPhotoNameAsync(int patientId);
        Task AttendPatientAsync(int patientId);
        Task<PaginatedList<Attendance>> GetAttendancesAsync(int patientId, FilterInput filterInput);
        Task RemoveAttendFromPatientAsync(int patientId, int attendId);
        Task<List<string>> UpdateAttendPatientAsync(int patientId, int attendId, DateTime date);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId);
    }
}

using PatientManager.Domain.Common.Entities;
using System.Linq.Expressions;

namespace PatientManager.Domain.Common.Interfaces.Repositories
{
    public interface IPatientRepository : IRepositoryReader<Patient>, IRepositoryWriter<Patient>
    {
        Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId, int page, int pageSize);
        Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId, Expression<Func<Attendance, Attendance>> selector = null);
        Task<int> CountAttendancesAsync(int patientId);
    }
}

using Microsoft.EntityFrameworkCore;
using PatientManager.Domain.Common.Entities;
using PatientManager.Domain.Common.Interfaces.Repositories;
using PatientManager.Sql.DbContexts;
using PatientManager.Sql.Extensions;
using System.Linq.Expressions;

namespace PatientManager.Sql.Repositories
{
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(DataContext coreDbContext) : base(coreDbContext)
        {

        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId, int page, int pageSize)
        {
            var attendances = await _coreDbContext.Attendances.AsNoTracking()
                .Where(attendance => attendance.PatientId.Equals(patientId))
                .OrderByDescending(x => x.Id)
                .Paging(page, pageSize)
                .ToListAsync();

            return attendances;
        }

        public async Task<int> CountAttendancesAsync(int patientId)
        {
            var count = await _coreDbContext.Attendances.AsNoTracking()
                .CountAsync(attendance => attendance.PatientId.Equals(patientId));

            return count;
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesAsync(int patientId, Expression<Func<Attendance, Attendance>> selector = null)
        {
            var attendances = await _coreDbContext.Attendances.AsNoTracking()
                .Selecting()
                .Where(attendance => attendance.PatientId.Equals(patientId))
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return attendances;
        }
    }
}

using PatientManager.Domain.Common.Entities;

namespace PatientManager.Application.Interfaces.XLSX
{
    public interface IExportFileXLSX : IExportFile
    {
        Task<byte[]> WriteDataPatientsAsync(IList<Patient> models);
        Task<byte[]> WriteDataAttendancesAsync(IList<Attendance> models);
    }
}

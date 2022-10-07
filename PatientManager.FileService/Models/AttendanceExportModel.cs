using PatientManager.Domain.Common.Entities;
using PatientManager.FileService.Attributes;

namespace PatientManager.FileService.Models
{
    public class AttendanceExportModel : ExportModel
    {
        [Header(Name = "Data da Presença")]
        public string Date { get; }
        public AttendanceExportModel(Attendance attendance)
        {
            Date = attendance.Date.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}

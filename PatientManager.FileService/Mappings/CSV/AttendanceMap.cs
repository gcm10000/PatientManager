using CsvHelper.Configuration;
using PatientManager.Domain.Common.Entities;

namespace PatientManager.FileService.Mappings.CSV
{
    public class AttendanceMap : ClassMap<Attendance>
    {
        public AttendanceMap()
        {
            Map(m => m.Date).Name("Data e Hora da Presença");
        }
    }
}

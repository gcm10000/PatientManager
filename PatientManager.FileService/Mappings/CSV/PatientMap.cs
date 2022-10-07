using CsvHelper.Configuration;
using PatientManager.Domain.Common.Entities;

namespace PatientManager.FileService.Mappings.CSV
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Map(m => m.Person.Name).Name("Nome");
            Map(m => m.Person.CPF).Name("CPF");
            Map(m => m.Person.RG).Name("RG");
            Map(m => m.HealthInsurance).Name("Convênio");
            Map(m => m.MedicalRecordNumber).Name("Número do Prontuário");
        }
    }
}

using PatientManager.Domain.Common.Entities;
using PatientManager.FileService.Attributes;

namespace PatientManager.FileService.Models
{
    public class PatientExportModel : ExportModel
    {
        [Header(Name = "Nome")]
        public string? Name { get; }
        [Header(Name = "CPF")]
        public string? CPF { get; } 
        [Header(Name = "RG")]
        public string? RG { get; }
        [Header(Name = "Número do Prontuário")]
        public long MedicalRecordNumber { get; }
        [Header(Name = "Convênio")]
        public string HealthInsurance { get; }
        public PatientExportModel(Patient patient)
        {
            Name = patient.Person.Name;
            CPF = patient.Person.CPF;
            RG = patient.Person.RG;
            MedicalRecordNumber = patient.MedicalRecordNumber;
            HealthInsurance = patient.HealthInsurance;
        }
    }
}

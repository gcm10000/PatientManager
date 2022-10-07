using PatientManager.Domain.Common.Interfaces;
using PatientManager.Domain.Common.ValueObjects;

namespace PatientManager.Domain.Common.Entities
{
    public class Patient : Entity, IAggregateRoot
    {
        public Person Person { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public long MedicalRecordNumber { get; set; }
        public string HealthInsurance { get; set; }


        public Patient()
        {
            Attendances = new HashSet<Attendance>();
        }
    }
}

namespace PatientManager.Domain.Common.Entities
{
    public class Attendance : Entity
    {
        public DateTime Date { get; set; }
        public int PatientId { get; set; }

        public Attendance()
        {
            Date = DateTime.Now;
        }
    }
}

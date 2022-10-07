namespace PatientManager.WinFormsApp.ViewModels
{
    public record AttendanceViewModel : ViewModel
    {
        public string Date { get; private set; }
        public AttendanceViewModel(int Id, string Date)
        {
            base.Id = Id;
            this.Date = Date;
        }
    }
}

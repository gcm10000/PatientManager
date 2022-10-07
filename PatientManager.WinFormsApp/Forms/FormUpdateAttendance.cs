using PatientManager.WinFormsApp.Controllers;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormUpdateAttendance : Form
    {
        private readonly PatientController _patientController;
        private int _patientId;
        private int _attendaceId;

        public FormUpdateAttendance(PatientController patientController)
        {
            InitializeComponent();
            _patientController = patientController;
        }

        public void SetAttendance(int patientId, int attendanceId, DateTime dateTime)
        {
            _patientId = patientId;
            _attendaceId = attendanceId;

            FillUI(dateTime);
        }

        private async void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var date = _dateTimePicker.Value;
            var success = await _patientController.UpdateAttendPatientAsync(new() 
            { 
                PatientId = _patientId, 
                AttendId = _attendaceId, 
                Date = date 
            });

            if (success)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FillUI(DateTime dateTime)
        {
            _dateTimePicker.Value = dateTime;
        }
    }
}

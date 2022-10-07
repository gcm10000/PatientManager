using PatientManager.WinFormsApp.Controllers;
using PatientManager.WinFormsApp.Extensions;
using PatientManager.WinFormsApp.Helpers;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormViewPatient : Form
    {
        private readonly PatientController _patientController;
        private readonly IServiceProvider _serviceProvider;
        private int _patientId;
        public FormViewPatient(PatientController patientController, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _patientController = patientController;
            _serviceProvider = serviceProvider;
        }

        public void SetPatient(int patientId)
        {
            _patientId = patientId;
            FillUI(patientId);
        }

        private async void FillUI(int patientId)
        {
            var patient = await _patientController.GetAsync(new(patientId));

            if (patient is null)
                return;

            var photoArrayAsync = _patientController.GetPhotoAsync(new(patient.Id));

            _textBoxName.Text = patient.Person.Name;
            _textBoxCPF.Text = patient.Person.CPF;
            _textBoxRG.Text = patient.Person.RG;
            _textBoxHealthInsurance.Text = patient.HealthInsurance;
            _textBoxMedicalRecordNumber.Text = patient.MedicalRecordNumber.ToString();
            _textBoxCreatedDate.Text = patient.CreatedAt.ToString();
            _textBoxUpdatedDate.Text = patient.UpdatedAt.ToString();

            _pictureBox.Image = GetImageOrDefault(await photoArrayAsync);
        }

        private static Image? GetImageOrDefault(byte[]? data)
        {
            if (data is not null && !data.Equals(Array.Empty<byte>()))
                return ImageHelper.FromBytes(data);
            
            return default;
        }

        private void ButtonUpdateData_Click(object sender, EventArgs e)
        {
            using var form = _serviceProvider.GetForm<FormAddOrUpdatePatient>();
            if (form is null)
            {
                MessageBox.Show("Não foi possível carregar o formulário de visualização.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            form.SetPatientId(_patientId);
            if (form.ShowDialog() == DialogResult.OK)
                FillUI(_patientId);
        }

        private async void ButtonSubmitPresent_Click(object sender, EventArgs e)
        {
            await _patientController.AttendPatientAsync(new(_patientId));
        }

        private void ButtonViewPresents_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetForm<FormAttendances>();
            if (form is null)
                return;
            form.SetPatient(_patientId);
            form.ShowDialog();
        }
    }
}

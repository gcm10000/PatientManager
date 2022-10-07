using PatientManager.WinFormsApp.DTOs;
using PatientManager.WinFormsApp.Helpers;
using PatientManager.WinFormsApp.Interfaces;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormConfigureCamera : Form
    {
        private readonly ICameraConfigurationService _cameraConfigurationService;

        public FormConfigureCamera(ICameraConfigurationService cameraConfigurationService)
        {
            InitializeComponent();
            InitializeCombobox();
            _cameraConfigurationService = cameraConfigurationService;
        }

        private void InitializeCombobox()
        {
            _comboBox.DataSource = LocalWebcam.GetCameraInformations().ToList();
            _comboBox.DisplayMember = "FriendlyName";
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var information = _comboBox.SelectedValue as CameraInformation;
            if (information is null)
                return;
            _cameraConfigurationService.SetIndexCameraAsync(information.Index);
            MessageBox.Show("Alteração feita com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

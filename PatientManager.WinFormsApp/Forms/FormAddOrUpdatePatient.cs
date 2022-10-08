using PatientManager.Application.Commands.Patient;
using PatientManager.Domain.Common.Entities;
using PatientManager.WinFormsApp.Controllers;
using PatientManager.WinFormsApp.DTOs;
using PatientManager.WinFormsApp.Enums;
using PatientManager.WinFormsApp.Helpers;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.Services;

namespace PatientManager.WinFormsApp.Forms
{
    public partial class FormAddOrUpdatePatient : Form, IDisposable
    {
        private int? _patientId;
        private string? _photoName;
        private readonly ICameraConfigurationService _cameraConfigurationService;
        private readonly PatientController _patientController;
        private readonly CameraService _cameraService;
        private EMode _mode = EMode.Webcam;
        private bool _photoTaken = false;


        public FormAddOrUpdatePatient(ICameraConfigurationService cameraConfigurationService,
                                      PatientController patientController,
                                      CameraService cameraService)
        {
            InitializeComponent();
            _cameraConfigurationService = cameraConfigurationService;
            _patientController = patientController;
            _cameraService = cameraService;
        }

        public async void SetPatientId(int patientId)
        {
            _patientId = patientId;
            var patient = await _patientController.GetAsync(new(patientId));
            if (patient is not null)
                FillUI(patient);
        }

        private async void FillUI(Patient patient)
        {
            var photoArrayAsync = _patientController.GetPhotoAsync(new(patient.Id));
            _textBoxName.Text = patient.Person.Name;
            _textBoxCPF.Text = patient.Person.CPF;
            _textBoxRG.Text = patient.Person.RG;
            _textBoxHealthInsurance.Text = patient?.HealthInsurance;
            _textBoxMedicalRecordNumber.Text = patient?.MedicalRecordNumber.ToString();
            _textBoxPhoto.Text = patient?.Person.Photo;
            _photoName = patient?.Person.Photo;

            var photoArray = await photoArrayAsync;
            if (photoArray is not null && !photoArray.Equals(Array.Empty<byte>()))
                _pictureBox.Image = ImageHelper.FromBytes(photoArray);

            _buttonEmptyPhoto.Enabled = _pictureBox.Image is not null;
        }

        private async void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_patientId is not null && _mode.Equals(EMode.Webcam))
            {
                var dialogResult = MessageBox.Show("A imagem será a mesma que já se encontra na base. Se você deseja que a imagem da câmera seja do paciente, então volte e clique no botão Capturar" + Environment.NewLine + "Deseja continuar?",
                                                   "Atenção",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Information);
                if (dialogResult == DialogResult.No)
                    return;
            }

            if (_patientId is not null && _mode.Equals(EMode.Webcam))
            {
                var dialogResult = MessageBox.Show("A imagem será a mesma que já se encontra na base. Se você deseja que a imagem da câmera seja do paciente, então volte e clique no botão Capturar" + Environment.NewLine + "Deseja continuar?",
                                                   "Atenção",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Information);
                if (dialogResult == DialogResult.No)
                    return;
            }
            var name = _textBoxName.Text;
            var cpf = _textBoxCPF.Text.Replace(".", "").Replace("-", "");
            var rg = _textBoxRG.Text.Replace(".", "").Replace("-", "");
            var healthInsurance = _textBoxHealthInsurance.Text;

            long.TryParse(_textBoxMedicalRecordNumber.Text, out long medicalRecordNumber);

            if (_patientId is null)
            {
                var createPatientCommand = new CreatePatientCommand()
                {
                    Name = name,
                    CPF = cpf,
                    RG = rg,
                    HealthInsurance = healthInsurance,
                    MedicalRecordNumber = medicalRecordNumber,
                    Photo = GetPhotoCommandOrDefault()
                };

                var resultAdded = await _patientController.AddAsync(createPatientCommand);
                if (resultAdded)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                return;
            }

            var updatePatientCommand = new UpdatePatientCommand()
            {
                Id = _patientId.GetValueOrDefault(),
                Name = name,
                CPF = cpf,
                RG = rg,
                HealthInsurance = healthInsurance,
                MedicalRecordNumber = medicalRecordNumber,
                Photo = GetPhotoCommandOrDefault(),
            };

            var resultUpdated = await _patientController.UpdateAsync(updatePatientCommand);
            if (resultUpdated)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private PhotoCommand? GetPhotoCommandOrDefault()
        {
            if (IsNewImageFile())
            {
                var extension = Path.GetExtension(_openFileDialog.FileName);
                var data = File.ReadAllBytes(_openFileDialog.FileName);

                return new(extension, data);
            }

            if (IsNewImageWebcam())
            {
                var data = ImageHelper.ToByteArray(_pictureBox.Image);
                return new(".bmp", data);
            }

            if (_pictureBox.Image is not null && string.IsNullOrWhiteSpace(_openFileDialog.FileName))
                return default;

            return new PhotoCommand(null, Array.Empty<byte>());
        }

        private bool IsNewImageWebcam()
        {
            return _pictureBox.Image is not null && _mode == EMode.Webcam && _photoTaken;
        }

        private bool IsNewImageFile()
        {
            return !string.IsNullOrWhiteSpace(_openFileDialog.FileName);
        }

        private void ButtonBrowserPhoto_Click(object sender, EventArgs e)
        {
            if (_mode == EMode.Webcam)
            {
                _cameraService.StopImagePreview();
                _pictureBox.Image = _cameraService.GetImageOrDefault();
                _buttonBrowserPhoto.Enabled = false;
                _buttonEmptyPhoto.Enabled = true;
                _photoTaken = true;
                _textBoxPhoto.Text = "Imagem da Câmera";
                return;
            }

            if (!_openFileDialog.ShowDialog().Equals(DialogResult.OK))
                return;

            _textBoxPhoto.Text = _openFileDialog.FileName;
            _pictureBox.Image = Image.FromFile(_openFileDialog.FileName);
            _photoTaken = false;
            _buttonEmptyPhoto.Enabled = _pictureBox.Image is not null;
        }

        private void ButtonEmptyPhoto_Click(object sender, EventArgs e)
        {
            _textBoxPhoto.Text = string.Empty;
            _pictureBox.Image = null;
            _pictureBox.Refresh();
            _buttonEmptyPhoto.Enabled = false;
            _photoTaken = false;
            if (_mode == EMode.Webcam)
                _cameraService.ContinueImagePreview();
            _buttonBrowserPhoto.Enabled = true;
        }

        private void TextBoxCPF_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_textBoxCPF.Text.Any(x => char.IsDigit(x)))
            {
                _textBoxCPF.SelectionStart = 0;
                return;
            }

            var index = _textBoxCPF.Text.IndexOf(' ');
            if (index > -1)
            {
                _textBoxCPF.SelectionStart = index;
                return;
            }
            _textBoxCPF.SelectionStart = _textBoxCPF.Text.Length;
        }

        private void ButtonChangeImageMode_Click(object sender, EventArgs e)
        {
            if (_mode == EMode.File)
            {
                SetModeWebcam();
                return;
            }

            SetModeFileAsync();
        }

        private void SetModeWebcam()
        {
            var cameraInfo = new CameraInformation(_cameraConfigurationService.Index, null);
            _cameraService.GetError = new Action<Exception>(
                (ex) =>
                {
                    MessageBox.Show(ex.Message,
                                    "Erro no Modo Câmera",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                });

            _cameraService.StartImagePreview(cameraInfo, _pictureBox);
            _buttonBrowserPhoto.Text = "Capturar";
            _buttonChangeMode.Text = "Modo Arquivo";
            _buttonEmptyPhoto.Enabled = false;
            _textBoxPhoto.Text = string.IsNullOrEmpty(_photoName) ? _photoName : string.Empty;
            _photoTaken = false;
            _mode = EMode.Webcam;
        }

        private async void SetModeFileAsync()
        {
            _cameraService.StopImagePreview();
            if (_patientId is not null)
            {
                var photoArray = await _patientController.GetPhotoAsync(new(_patientId.GetValueOrDefault()));
                if (photoArray is not null && !photoArray.Equals(Array.Empty<byte>()))
                    _pictureBox.Image = ImageHelper.FromBytes(photoArray);
                _textBoxPhoto.Text = _photoName;
            }
            _buttonBrowserPhoto.Text = "Procurar";
            _buttonChangeMode.Text = "Modo Câmera";
            _buttonBrowserPhoto.Enabled = true;
            _photoTaken = false;
            _buttonEmptyPhoto.Enabled = !string.IsNullOrEmpty(_photoName);
            _mode = EMode.File;
        }

        private void FormAddOrUpdatePatient_Load(object sender, EventArgs e)
        {
            if (_patientId is null)
            {
                SetModeWebcam();
                return;
            }
            SetModeFileAsync();
        }

        public new void Dispose()
        {
            GC.SuppressFinalize(this);
            _cameraService.Dispose();
            base.Dispose();
        }
    }
}

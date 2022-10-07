using OpenCvSharp;
using OpenCvSharp.Extensions;
using PatientManager.WinFormsApp.DTOs;

namespace PatientManager.WinFormsApp.Services
{
    public class CameraService : IDisposable
    {
        private readonly VideoCapture _capture;
        private readonly Mat _frame;
        private Image? _image;
        private bool _continue;
        private PictureBox? _pictureBox;

        public Action<Exception> GetError { get; set; } = null!;

        public CameraService()
        {
            _capture = new VideoCapture(0);
            _frame = new Mat();
        }

        public void StartImagePreview(CameraInformation cameraInformation, PictureBox pictureBox)
        {
            _capture.Open(cameraInformation.Index);
            if (!_capture.IsOpened())
                return;
            _continue = true;
            _pictureBox = pictureBox;
            System.Windows.Forms.Application.Idle += RunEvent(pictureBox, _frame);
        }

        public void ContinueImagePreview()
        {
            _continue = true;
        }

        public void StopImagePreview()
        {
            _continue = false;
            if (_pictureBox is not null)
                _pictureBox.Image = null;
        }

        private EventHandler RunEvent(PictureBox pictureBox, Mat frame)
        {
            return (sender, e) =>
            {
                if (!_continue || _capture.IsDisposed)
                    return;

                _capture.Read(frame);
                try
                {
                    _image = BitmapConverter.ToBitmap(frame);

                }
                catch (ArgumentException)
                {
                    if (GetError is not null)
                        GetError(new InvalidOperationException(message: "Câmera já se encontra utilizada."));
                    Dispose();
                    return;
                }
                if (pictureBox.Image is not null)
                    pictureBox.Image.Dispose();
                pictureBox.Image = _image;
            };
        }

        public Image? GetImageOrDefault() => _image;

        public void Dispose()
        {
            _capture.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

namespace PatientManager.WinFormsApp.Interfaces
{
    public interface ICameraConfigurationService
    {
        Guid File { get; }
        int Index { get; }

        Task SetIndexCameraAsync(int index);
    }
}

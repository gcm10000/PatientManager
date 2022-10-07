namespace PatientManager.Application.Interfaces
{
    public interface IExportFile
    {
        Task<byte[]> WriteDataAsync<T>(IList<T> list);
    }
}

using System.Text;

namespace PatientManager.Application.Interfaces
{
    public interface IImportFile
    {
        void SetConfiguration(Encoding encoding);
        Task<IList<T>> ReadDataAsync<T>(string path);
    }
}

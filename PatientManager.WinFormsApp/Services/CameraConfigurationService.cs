using PatientManager.Application.Interfaces;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.Statics;

namespace PatientManager.WinFormsApp.Services
{
    public class CameraConfigurationService : ConfigurationServiceBase, ICameraConfigurationService
    {

        public Guid File => GuidStatics.GuidCameraIndex;

        public int Index 
        { 
            get
            {
                return int.Parse(GetVariableOrDefaultByGuid(File) ?? "0");
            }
        }

        public CameraConfigurationService(IReaderFileService readerFileService,
                                          IWriterFileService writerFileService)
            : base(readerFileService, writerFileService)
        {
        }

        public Task SetIndexCameraAsync(int index)
        {
            return SetVariableAsync(File, index);
        }
    }
}

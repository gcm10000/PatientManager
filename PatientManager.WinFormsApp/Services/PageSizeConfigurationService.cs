using PatientManager.Application.DTOs;
using PatientManager.Application.Interfaces;
using PatientManager.WinFormsApp.Interfaces;
using PatientManager.WinFormsApp.Statics;
using System.Text;

namespace PatientManager.WinFormsApp.Services
{
    public class PageSizeConfigurationService : ConfigurationServiceBase, IPageSizeService
    {

        public Guid File => GuidStatics.GuidPageSize;
        public int PageSize
        {
            get
            {
                return int.Parse(GetVariableOrDefaultByGuid(File) ?? "10");
            }
        }

        public PageSizeConfigurationService(IReaderFileService readerFileService, IWriterFileService writerFileService)
            : base(readerFileService, writerFileService)
        {

        }

        public Task SetPageSizeAsync(int pageSize)
        {
            return SetVariableAsync(File, pageSize);
        }
    }
}

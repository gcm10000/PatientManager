namespace PatientManager.WinFormsApp.Interfaces
{
    public interface IPageSizeService
    {
        Guid File { get; }
        int PageSize { get; }

        Task SetPageSizeAsync(int pageSize);
    }
}

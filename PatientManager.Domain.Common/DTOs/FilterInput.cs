namespace PatientManager.Domain.Common.DTOs
{
    public record FilterInput(int CurrentPage, int ItemsPerPage, string Query);
}

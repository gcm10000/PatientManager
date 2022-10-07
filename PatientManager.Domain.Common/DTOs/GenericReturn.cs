namespace PatientManager.Domain.Common.DTOs
{
    public record GenericReturn<TResponse>(TResponse? Item, ICollection<string> Messages);
}

namespace PatientManager.Application.Models
{
    public class Response
    {
        public ICollection<string> Errors { get; private set; }
        public bool Success { get; private set; }

        public Response(ICollection<string>? errors)
        {
            Success = errors == null || !errors.Any();
            Errors = errors ?? Array.Empty<string>();
        }

        public Response(bool success)
        {
            Errors = Array.Empty<string>();
            Success = success;
        }
    }
}

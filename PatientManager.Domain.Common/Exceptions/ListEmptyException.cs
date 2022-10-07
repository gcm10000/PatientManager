namespace PatientManager.Domain.Common.Exceptions
{
    public class ListEmptyException : Exception
    {
        public ListEmptyException(string message) : base(message)
        {

        }
    }
}

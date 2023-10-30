namespace Core.ViewModels.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public ErrorResponse(string errorMessage) : this(new List<string> { errorMessage }) { }

        public ErrorResponse(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}

namespace NationalAuthorization.SDK
{
    public class ValidationMessage
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

        public ValidationMessage(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }
    }
}
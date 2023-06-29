namespace CustomVisionEngine.Exceptions
{
    public class ClassifierException : Exception
    {
        public ClassifierException(string message) : base(message)
        {
        }

        public ClassifierException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

namespace TCM.Core.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException()
             : base()
        {
        }

        public KeyNotFoundException(string message)
            : base(message)
        {
        }

        public KeyNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

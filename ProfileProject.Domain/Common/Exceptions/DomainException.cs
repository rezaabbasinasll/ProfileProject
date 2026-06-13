namespace ProfileProject.Domain.Common.Exceptions
{
    public class DomainException : BaseException
    {
        public DomainException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
        {
        }

        public DomainException(ErrorModel errors, Exception? innerException = null) : base(errors.message, errors.code, innerException)
        {
        }
    }
}

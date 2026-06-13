namespace ProfileProject.Domain.Common.Exceptions;

public abstract class BaseException : Exception
{
    protected BaseException(string message, string code, Exception? innerException) : base(message, innerException)
    {
        Code = code;
    }
    public string Code { get; private set; }
}
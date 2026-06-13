using ProfileProject.Domain.Common.Exceptions;

namespace ProfileProject.Application.Common.Exceptions;

public class BaseApplicationException : BaseException
{
    public BaseApplicationException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
    public BaseApplicationException(ErrorModel error, Exception? innerException = null) : base(error.message, error.code, innerException)
    {
    }
}

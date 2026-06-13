using ProfileProject.Domain.Common.Exceptions;

namespace ProfileProject.Application.Common.Exceptions;

public class DuplicateException : BaseApplicationException
{
    public DuplicateException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
    public DuplicateException(ErrorModel error, Exception? innerException = null) : base(error.message, error.code, innerException)
    {
    }
}

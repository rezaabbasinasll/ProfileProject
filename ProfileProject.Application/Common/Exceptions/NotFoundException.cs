using ProfileProject.Domain.Common.Exceptions;

namespace ProfileProject.Application.Common.Exceptions;

public class NotFoundException : BaseApplicationException
{
    public NotFoundException(string message, string code, Exception? innerException = null) : base(message, code, innerException)
    {
    }
    public NotFoundException(ErrorModel error, Exception? innerException = null) : base(error.message, error.code, innerException)
    {
    }
}

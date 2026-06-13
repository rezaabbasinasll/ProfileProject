using ProfileProject.Domain.Common.Exceptions;

namespace ProfileProject.Api.Contracts.Models;

public class BaseResult<TData>
{
    public TData? Data { get; set; }
    public bool IsSuccess { get; set; }
    public ErrorModel? Error { get; set; }

    public static BaseResult<TData>Success(TData data)
    {
        return new BaseResult<TData>
        {
            IsSuccess = true,
            Data = data,
            Error = null
        };
    }

    public static BaseResult<TData> Failure(ErrorModel error)
    {
        return new BaseResult<TData>
        {
            IsSuccess = false,            
            Error = error
        };
    }
}

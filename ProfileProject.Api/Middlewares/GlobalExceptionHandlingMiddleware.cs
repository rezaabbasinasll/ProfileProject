using ProfileProject.Api.Contracts.Models;
using ProfileProject.Application.Common.Exceptions;
using ProfileProject.Domain.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace ProfileProject.Api.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch(Exception ex)
        {
            await HandelException(context, ex);
        }
    }

    private async Task HandelException(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case NotFoundException ex:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsJsonAsync<BaseResult<string>>(BaseResult<string>.Failure(new ErrorModel(ex.Message, ex.Code)));         
                break;

            case DomainException ex:
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsJsonAsync<BaseResult<string>>(BaseResult<string>.Failure(new ErrorModel(ex.Message, ex.Code)));
                break;

            case DuplicateException ex:
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsJsonAsync<BaseResult<string>>(BaseResult<string>.Failure(new ErrorModel(ex.Message, ex.Code)));
                break;

            default:                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync<BaseResult<string>>(BaseResult<string>.Failure(new ErrorModel("خطایی رخ داده است ،لطفا مجددا تلاش کنید", "Internal_Server_Error_500")));
                break;
        }
    }
    private string GenerateResponse(string message, string code)
    {
        return JsonSerializer.Serialize(BaseResult<string>.Failure(new ErrorModel(message, code)));
    }
}

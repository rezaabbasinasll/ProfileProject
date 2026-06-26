using ProfileProject.Domain.Common.Exceptions;

namespace ProfileProject.Application.Common.Exceptions;

public static class ApplicationErrors
{
    public static ErrorModel EmailAlreadyExists => new ErrorModel("این قبلا ثبت شده.", "Application_1000");

    public static ErrorModel ProfileNotFound => new ErrorModel("پروفایل یافت نشد.", "Application_1001");

    public static ErrorModel SkillNotFound => new ErrorModel("مهارت مورد نظر یافت نشد.", "Application_1002");
}    

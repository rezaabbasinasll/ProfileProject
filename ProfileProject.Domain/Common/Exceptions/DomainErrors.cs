namespace ProfileProject.Domain.Common.Exceptions;

public static class DomainErrors
{
    public static ErrorModel FullNameIsRequired => new ErrorModel("نام و نام خانوادگی اجباری است.", "Domain_1000");
    public static ErrorModel EmailIsRequired => new ErrorModel("ایمیل اجباری است.", "Domain_1001");
    public static ErrorModel SkilAllreadyExist => new ErrorModel("این مهارت قبلا وارد شده است.", "Domain_1002");
    public static ErrorModel SkillNotFound => new ErrorModel("مهارت مورد نظر یافت نشد.", "Domain_1003");
}

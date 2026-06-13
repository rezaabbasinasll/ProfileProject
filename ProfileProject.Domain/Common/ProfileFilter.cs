namespace ProfileProject.Domain.Common;

public class ProfileFilter
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
    public string? FullName { get;  set; } = null;
    public string? Email { get; set; } = null;
    public string? Bio { get; set; } = null;
}

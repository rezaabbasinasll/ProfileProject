using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.Api.Contracts.Models
{
    public class GetProfilePagedRequst
    {
        public int PageSize { get; set; }
        public int PagNumber { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Bio { get; set; }
        public SkillLevel? SkillLevel { get; set; }
    }
}
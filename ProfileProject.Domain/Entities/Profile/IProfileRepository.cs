using ProfileProject.Domain.Common;
using ProfileProject.Domain.Common.Interfaces;
using System.Linq.Expressions;

namespace ProfileProject.Domain.Entities.Profile;

public interface IProfileRepository : IBaseRepository<ProfileEntity>
{
    Task<ProfileEntity?> GetProfileWithSkillsAsync(
        Guid profileId);

    Task<bool> EmailExistsAsync(
        string email);
}

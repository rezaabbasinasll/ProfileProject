using ProfileProject.Application.Common.Models.ProfileDtos;
using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.Application.Services.Profile;

public interface IProfileService
{
    Task<Guid> CreateAsync(CreateProfileDto command);

    Task UpdateFullNameAsync(UpdateProfileDto command);

    Task AddSkillAsync(AddSkillDto command);

    Task UpdateSkillAsync(UpdateSkillRequest request);

    Task SoftDeleteAsync(Guid profileId);

    Task HardDeleteAsync(Guid profileId);


    /// <summary>
    /// Get Profile by id 
    /// </summary>
    /// <param name="profileId"></param>
    /// <returns></returns>
    Task<ProfileEntity> GetProfileByIdAsync(Guid profileId);
}

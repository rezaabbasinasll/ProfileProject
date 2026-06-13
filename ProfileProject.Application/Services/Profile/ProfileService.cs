using ProfileProject.Application.Common.Exceptions;
using ProfileProject.Application.Common.Models.ProfileDtos;
using ProfileProject.Domain.Entities.Profile;

namespace ProfileProject.Application.Services.Profile;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Guid> CreateAsync(
        CreateProfileDto command)
    {
        var exists = await _profileRepository.EmailExistsAsync(command.email);

        if (exists)
            throw new DuplicateException(ApplicationErrors.EmailAlreadyExists);

        var profile = new ProfileEntity(command.fullName, command.email, command.bio);

        await _profileRepository.AddAsync(profile);

        return profile.Id;
    }

    public async Task UpdateFullNameAsync(
       UpdateProfileDto command)
    {
        var profile = await _profileRepository.GetByIdAsync(command.profileId);

        if (profile is null)
            throw new NotFoundException(ApplicationErrors.ProfileNotFound);

        profile.UpdateFullName(command.fullName);
    }

    public async Task AddSkillAsync(
        AddSkillDto command)
    {
        var profile = await _profileRepository.GetProfileWithSkillsAsync(command.profileId);

        if (profile is null)
            throw new NotFoundException(ApplicationErrors.ProfileNotFound);

        profile.AddSkill(new Skill(command.name, command.skillLevel));
    }

    public async Task UpdateSkillAsync(
        UpdateSkillRequest request)
    {
        var profile = await _profileRepository.GetProfileWithSkillsAsync(request.profileId);

        if (profile is null)
            throw new NotFoundException(ApplicationErrors.ProfileNotFound);

        var skill = profile.Skills.FirstOrDefault(x => x.Id == request.skillId);

        if (skill is null)
            throw new NotFoundException(ApplicationErrors.SkillNotFound);

        skill.Update(request.name, request.skillLevel);
    }

    public async Task SoftDeleteAsync(Guid profileId)
    {
        var profile = await _profileRepository.GetByIdAsync(profileId);

        if (profile is null)
            throw new NotFoundException(ApplicationErrors.ProfileNotFound);

        profile.SoftDelete();
    }

    public async Task HardDeleteAsync(Guid profileId)
    {
        var profile = await _profileRepository.GetByIdAsync(profileId);

        if (profile is null)
            throw new NotFoundException(ApplicationErrors.ProfileNotFound);

        _profileRepository.HardDelete(profile);
    }

    public async Task<ProfileEntity> GetProfileByIdAsync(Guid profileId)
    {
        return await _profileRepository.GetByIdAsync(profileId) ?? throw new NotFoundException(ApplicationErrors.ProfileNotFound);
    }
}